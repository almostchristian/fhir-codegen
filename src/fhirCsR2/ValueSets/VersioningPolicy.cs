// <auto-generated />
// Built from: hl7.fhir.r2.core version: 1.0.2
  // Option: "NAMESPACE" = "fhirCsR2"

using fhirCsR2.Models;

namespace fhirCsR2.ValueSets
{
  /// <summary>
  /// How the system supports versioning for a resource.
  /// </summary>
  public static class VersioningPolicyCodes
  {
    /// <summary>
    /// VersionId meta-property is not supported (server) or used (client).
    /// </summary>
    public static readonly Coding NoVersionIdSupport = new Coding
    {
      Code = "no-version",
      Display = "No VersionId Support",
      System = "http://hl7.org/fhir/versioning-policy"
    };
    /// <summary>
    /// VersionId meta-property is supported (server) or used (client).
    /// </summary>
    public static readonly Coding Versioned = new Coding
    {
      Code = "versioned",
      Display = "Versioned",
      System = "http://hl7.org/fhir/versioning-policy"
    };
    /// <summary>
    /// VersionId is must be correct for updates (server) or will be specified (If-match header) for updates (client).
    /// </summary>
    public static readonly Coding VersionIdTrackedFully = new Coding
    {
      Code = "versioned-update",
      Display = "VersionId tracked fully",
      System = "http://hl7.org/fhir/versioning-policy"
    };

    /// <summary>
    /// Literal for code: NoVersionIdSupport
    /// </summary>
    public const string LiteralNoVersionIdSupport = "no-version";

    /// <summary>
    /// Literal for code: VersioningPolicyNoVersionIdSupport
    /// </summary>
    public const string LiteralVersioningPolicyNoVersionIdSupport = "http://hl7.org/fhir/versioning-policy#no-version";

    /// <summary>
    /// Literal for code: Versioned
    /// </summary>
    public const string LiteralVersioned = "versioned";

    /// <summary>
    /// Literal for code: VersioningPolicyVersioned
    /// </summary>
    public const string LiteralVersioningPolicyVersioned = "http://hl7.org/fhir/versioning-policy#versioned";

    /// <summary>
    /// Literal for code: VersionIdTrackedFully
    /// </summary>
    public const string LiteralVersionIdTrackedFully = "versioned-update";

    /// <summary>
    /// Literal for code: VersioningPolicyVersionIdTrackedFully
    /// </summary>
    public const string LiteralVersioningPolicyVersionIdTrackedFully = "http://hl7.org/fhir/versioning-policy#versioned-update";

    /// <summary>
    /// Dictionary for looking up VersioningPolicy Codings based on Codes
    /// </summary>
    public static Dictionary<string, Coding> Values = new Dictionary<string, Coding>() {
      { "no-version", NoVersionIdSupport }, 
      { "http://hl7.org/fhir/versioning-policy#no-version", NoVersionIdSupport }, 
      { "versioned", Versioned }, 
      { "http://hl7.org/fhir/versioning-policy#versioned", Versioned }, 
      { "versioned-update", VersionIdTrackedFully }, 
      { "http://hl7.org/fhir/versioning-policy#versioned-update", VersionIdTrackedFully }, 
    };
  };
}
