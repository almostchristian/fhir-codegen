// <auto-generated />
// Built from: hl7.fhir.r2.core version: 1.0.2
  // Option: "NAMESPACE" = "fhirCsR2"

using fhirCsR2.Models;

namespace fhirCsR2.ValueSets
{
  /// <summary>
  /// Describes the state of a metric calibration.
  /// </summary>
  public static class MetricCalibrationStateCodes
  {
    /// <summary>
    /// The metric has been calibrated.
    /// </summary>
    public static readonly Coding Calibrated = new Coding
    {
      Code = "calibrated",
      Display = "Calibrated",
      System = "http://hl7.org/fhir/metric-calibration-state"
    };
    /// <summary>
    /// The metric needs to be calibrated.
    /// </summary>
    public static readonly Coding CalibrationRequired = new Coding
    {
      Code = "calibration-required",
      Display = "Calibration Required",
      System = "http://hl7.org/fhir/metric-calibration-state"
    };
    /// <summary>
    /// The metric has not been calibrated.
    /// </summary>
    public static readonly Coding NotCalibrated = new Coding
    {
      Code = "not-calibrated",
      Display = "Not Calibrated",
      System = "http://hl7.org/fhir/metric-calibration-state"
    };
    /// <summary>
    /// The state of calibration of this metric is unspecified.
    /// </summary>
    public static readonly Coding Unspecified = new Coding
    {
      Code = "unspecified",
      Display = "Unspecified",
      System = "http://hl7.org/fhir/metric-calibration-state"
    };

    /// <summary>
    /// Literal for code: Calibrated
    /// </summary>
    public const string LiteralCalibrated = "calibrated";

    /// <summary>
    /// Literal for code: MetricCalibrationStateCalibrated
    /// </summary>
    public const string LiteralMetricCalibrationStateCalibrated = "http://hl7.org/fhir/metric-calibration-state#calibrated";

    /// <summary>
    /// Literal for code: CalibrationRequired
    /// </summary>
    public const string LiteralCalibrationRequired = "calibration-required";

    /// <summary>
    /// Literal for code: MetricCalibrationStateCalibrationRequired
    /// </summary>
    public const string LiteralMetricCalibrationStateCalibrationRequired = "http://hl7.org/fhir/metric-calibration-state#calibration-required";

    /// <summary>
    /// Literal for code: NotCalibrated
    /// </summary>
    public const string LiteralNotCalibrated = "not-calibrated";

    /// <summary>
    /// Literal for code: MetricCalibrationStateNotCalibrated
    /// </summary>
    public const string LiteralMetricCalibrationStateNotCalibrated = "http://hl7.org/fhir/metric-calibration-state#not-calibrated";

    /// <summary>
    /// Literal for code: Unspecified
    /// </summary>
    public const string LiteralUnspecified = "unspecified";

    /// <summary>
    /// Literal for code: MetricCalibrationStateUnspecified
    /// </summary>
    public const string LiteralMetricCalibrationStateUnspecified = "http://hl7.org/fhir/metric-calibration-state#unspecified";

    /// <summary>
    /// Dictionary for looking up MetricCalibrationState Codings based on Codes
    /// </summary>
    public static Dictionary<string, Coding> Values = new Dictionary<string, Coding>() {
      { "calibrated", Calibrated }, 
      { "http://hl7.org/fhir/metric-calibration-state#calibrated", Calibrated }, 
      { "calibration-required", CalibrationRequired }, 
      { "http://hl7.org/fhir/metric-calibration-state#calibration-required", CalibrationRequired }, 
      { "not-calibrated", NotCalibrated }, 
      { "http://hl7.org/fhir/metric-calibration-state#not-calibrated", NotCalibrated }, 
      { "unspecified", Unspecified }, 
      { "http://hl7.org/fhir/metric-calibration-state#unspecified", Unspecified }, 
    };
  };
}
