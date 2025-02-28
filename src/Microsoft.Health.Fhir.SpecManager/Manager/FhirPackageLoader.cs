﻿// <copyright file="FhirPackageLoader.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
//     Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// </copyright>

using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Health.Fhir.SpecManager.Models;
using Microsoft.Health.Fhir.SpecManager.PackageManager;

namespace Microsoft.Health.Fhir.SpecManager.Manager;

/// <summary>A FHIR package loader (e.g., hl7.fhir.us.core).</summary>
public static class FhirPackageLoader
{
    /// <summary>(Immutable) The definitional resource types to load.</summary>
    public static readonly string[] DefinitionalResourceTypesToLoad = new string[]
    {
        "CodeSystem",
        "ValueSet",
        "StructureDefinition",
        "SearchParameter",
        "OperationDefinition",
        "ImplementationGuide",
    };

    /// <summary>Loads.</summary>
    /// <exception cref="ArgumentNullException">     Thrown when one or more required arguments are
    ///  null.</exception>
    /// <exception cref="DirectoryNotFoundException">Thrown when the requested directory is not
    ///  present.</exception>
    /// <param name="directive">  The directive.</param>
    /// <param name="directory">  Pathname of the directory.</param>
    /// <param name="packageInfo">[out] The information.</param>
    public static void Load(
        string directive,
        string directory,
        out FhirVersionInfo packageInfo)
    {
        if (string.IsNullOrEmpty(directive))
        {
            throw new ArgumentNullException(nameof(directive));
        }

        if (string.IsNullOrEmpty(directory))
        {
            throw new ArgumentNullException(nameof(directory));
        }

        string contentDirectory = Path.Combine(directory, "package");

        if (!Directory.Exists(contentDirectory))
        {
            throw new DirectoryNotFoundException($"Missing package content directory: {contentDirectory}");
        }

        packageInfo = new FhirVersionInfo(directory);

        HashSet<string> processedFiles = new HashSet<string>();

        bool checkUnescaped = false;

        if (packageInfo.VersionString.Equals("3.5.0", StringComparison.Ordinal))
        {
            checkUnescaped = true;
        }

        FhirPackageIndex fhirPackageIndex = FhirPackageIndex.Load(directory);

        if (fhirPackageIndex != null)
        {
            if (fhirPackageIndex.FilesByResourceType.ContainsKey("CodeSystem"))
            {
                ProcessFileGroup(
                    contentDirectory,
                    fhirPackageIndex.FilesByResourceType["CodeSystem"],
                    packageInfo,
                    processedFiles,
                    checkUnescaped);
            }

            if (fhirPackageIndex.FilesByResourceType.ContainsKey("ValueSet"))
            {
                ProcessFileGroup(
                    contentDirectory,
                    fhirPackageIndex.FilesByResourceType["ValueSet"],
                    packageInfo,
                    processedFiles,
                    checkUnescaped);
            }

            foreach ((string resourceType, List<FhirPackageIndex.PackageIndexFile> files) in fhirPackageIndex.FilesByResourceType)
            {
                switch (resourceType)
                {
                    case "CodeSystem":
                    case "ValueSet":
                        // already processed
                        break;

                    default:
                        if (packageInfo.ShouldProcessResource(resourceType))
                        {
                            ProcessFileGroup(
                                contentDirectory,
                                files,
                                packageInfo,
                                processedFiles,
                                checkUnescaped);
                        }
                        break;
                }
            }
        }
        else
        {
            //// process Code Systems
            //ProcessFileGroup(contentDirectory, "CodeSystem", packageInfo, processedFiles, checkUnescaped);

            //// process Value Set expansions
            //ProcessFileGroup(contentDirectory, "ValueSet", packageInfo, processedFiles, checkUnescaped);

            //// process structure definitions
            //ProcessFileGroup(contentDirectory, "StructureDefinition", packageInfo, processedFiles, checkUnescaped);

            //// process search parameters (adds to resources)
            //ProcessFileGroup(contentDirectory, "SearchParameter", packageInfo, processedFiles, checkUnescaped);

            //// process operations (adds to resources and version info (server level))
            //ProcessFileGroup(contentDirectory, "OperationDefinition", packageInfo, processedFiles, checkUnescaped);

            // try to load every json file
            ProcessFileGroup(contentDirectory, string.Empty, packageInfo, processedFiles, checkUnescaped);
        }

        if (packageInfo.ConverterHasIssues(out int errorCount, out int warningCount))
        {
            // make sure we cleared the last line
            Console.WriteLine($"LoadCached <<< Loaded and Parsed {directive}" +
                $" with {errorCount} errors" +
                $" and {warningCount} warnings" +
                $"{new string(' ', 100)}");
            packageInfo.DisplayConverterIssues();
        }
        else
        {
            // make sure we cleared the last line
            Console.WriteLine($"LoadCached <<< Loaded and Parsed {directive}{new string(' ', 100)}");
        }
    }

    /// <summary>
    /// Process a file group, specified by the file prefix (e.g., StructureDefinition).
    /// </summary>
    /// <param name="packageDir">    The package dir.</param>
    /// <param name="prefix">        The prefix.</param>
    /// <param name="fhirInfo">  Information describing the fhir version.</param>
    /// <param name="processedFiles">The processed files.</param>
    /// <param name="checkUnescaped">True if check unescaped.</param>
    private static void ProcessFileGroup(
        string packageDir,
        string prefix,
        IPackageImportable fhirInfo,
        HashSet<string> processedFiles,
        bool checkUnescaped)
    {
        // get the files in this directory
        string[] files = Directory.GetFiles(packageDir, $"{prefix}*.json", SearchOption.TopDirectoryOnly);

        // process these files
        ProcessPackageFiles(files, fhirInfo, processedFiles, checkUnescaped);
    }

    /// <summary>Process a file group.</summary>
    /// <param name="packageDir">    The package dir.</param>
    /// <param name="indexFiles">    The index files.</param>
    /// <param name="fhirInfo">      Information describing the fhir version.</param>
    /// <param name="processedFiles">The processed files.</param>
    /// <param name="checkUnescaped">True if check unescaped.</param>
    private static void ProcessFileGroup(
        string packageDir,
        List<FhirPackageIndex.PackageIndexFile> indexFiles,
        IPackageImportable fhirInfo,
        HashSet<string> processedFiles,
        bool checkUnescaped)
    {
        // grab the filenames and prefix with the package directory
        IEnumerable<string> files = indexFiles.Select(pif => Path.Combine(packageDir, pif.Filename));

        ProcessPackageFiles(files, fhirInfo, processedFiles, checkUnescaped);
    }

    /// <summary>Process the package files.</summary>
    /// <exception cref="InvalidDataException">Thrown when an Invalid Data error condition occurs.</exception>
    /// <param name="files">         The files.</param>
    /// <param name="fhirInfo">      FHIR information structure.</param>
    /// <param name="processedFiles">The processed files.</param>
    /// <param name="checkUnescaped">True if check unescaped.</param>
    private static void ProcessPackageFiles(
        IEnumerable<string> files,
        IPackageImportable fhirInfo,
        HashSet<string> processedFiles,
        bool checkUnescaped)
    {
        // traverse the files
        foreach (string filename in files)
        {
            // check for skipping file
            if (fhirInfo.ShouldSkipFile(Path.GetFileName(filename)))
            {
                // skip this file
                continue;
            }

            // parse the name into parts we want
            string shortName = Path.GetFileNameWithoutExtension(filename);
            string[] components = shortName.Split('-');

            // attempt to load this file
            try
            {
                Console.Write($"{fhirInfo.FhirSequence}: {shortName,-85}\r");

                if (processedFiles.Contains(shortName))
                {
                    // skip
                    continue;
                }

                processedFiles.Add(shortName);

                // read the file
                string contents = File.ReadAllText(filename);

                if (checkUnescaped)
                {
                    Regex regex = new Regex("[\\s]");
                    contents = regex.Replace(contents, " ");
                }

                // parse the file - note: using var here is siginificantly more performant than object
                if (fhirInfo.TryParseResource(contents, out var resource, out string rt) &&
                    fhirInfo.ShouldProcessResource(rt))
                {
                    // process this resource
                    fhirInfo.ProcessResource(resource);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine($"nProcessPackageFiles <<< Failed to process file: {filename}: \n{ex}\n--------------");
                throw;
            }
        }
    }
}
