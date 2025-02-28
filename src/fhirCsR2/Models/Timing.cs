// <auto-generated />
// Built from: hl7.fhir.r2.core version: 1.0.2
  // Option: "NAMESPACE" = "fhirCsR2"

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using fhirCsR2.Serialization;

namespace fhirCsR2.Models
{
  /// <summary>
  /// Many timing schedules are determined by regular repetitions.
  /// </summary>
  [JsonConverter(typeof(fhirCsR2.Serialization.JsonStreamComponentConverter<TimingRepeat>))]
  public class TimingRepeat : Element,  IFhirJsonSerializable {
    /// <summary>
    /// Either a duration for the length of the timing schedule, a range of possible length, or outer bounds for start and/or end limits of the timing schedule.
    /// </summary>
    public Quantity BoundsQuantity { get; set; }
    /// <summary>
    /// Either a duration for the length of the timing schedule, a range of possible length, or outer bounds for start and/or end limits of the timing schedule.
    /// </summary>
    public Range BoundsRange { get; set; }
    /// <summary>
    /// Either a duration for the length of the timing schedule, a range of possible length, or outer bounds for start and/or end limits of the timing schedule.
    /// </summary>
    public Period BoundsPeriod { get; set; }
    /// <summary>
    /// Repetitions may be limited by end time or total occurrences.
    /// </summary>
    public int? Count { get; set; }
    /// <summary>
    /// Extension container element for Count
    /// </summary>
    public Element _Count { get; set; }
    /// <summary>
    /// Some activities are not instantaneous and need to be maintained for a period of time.
    /// </summary>
    public decimal? Duration { get; set; }
    /// <summary>
    /// Extension container element for Duration
    /// </summary>
    public Element _Duration { get; set; }
    /// <summary>
    /// Some activities are not instantaneous and need to be maintained for a period of time.
    /// </summary>
    public decimal? DurationMax { get; set; }
    /// <summary>
    /// Extension container element for DurationMax
    /// </summary>
    public Element _DurationMax { get; set; }
    /// <summary>
    /// The units of time for the duration, in UCUM units.
    /// </summary>
    public string DurationUnits { get; set; }
    /// <summary>
    /// Extension container element for DurationUnits
    /// </summary>
    public Element _DurationUnits { get; set; }
    /// <summary>
    /// The number of times to repeat the action within the specified period / period range (i.e. both period and periodMax provided).
    /// </summary>
    public int? Frequency { get; set; }
    /// <summary>
    /// Extension container element for Frequency
    /// </summary>
    public Element _Frequency { get; set; }
    /// <summary>
    /// If present, indicates that the frequency is a range - so repeat between [frequency] and [frequencyMax] times within the period or period range.
    /// </summary>
    public int? FrequencyMax { get; set; }
    /// <summary>
    /// Extension container element for FrequencyMax
    /// </summary>
    public Element _FrequencyMax { get; set; }
    /// <summary>
    /// Indicates the duration of time over which repetitions are to occur; e.g. to express "3 times per day", 3 would be the frequency and "1 day" would be the period.
    /// </summary>
    public decimal? Period { get; set; }
    /// <summary>
    /// Extension container element for Period
    /// </summary>
    public Element _Period { get; set; }
    /// <summary>
    /// If present, indicates that the period is a range from [period] to [periodMax], allowing expressing concepts such as "do this once every 3-5 days.
    /// </summary>
    public decimal? PeriodMax { get; set; }
    /// <summary>
    /// Extension container element for PeriodMax
    /// </summary>
    public Element _PeriodMax { get; set; }
    /// <summary>
    /// The units of time for the period in UCUM units.
    /// </summary>
    public string PeriodUnits { get; set; }
    /// <summary>
    /// Extension container element for PeriodUnits
    /// </summary>
    public Element _PeriodUnits { get; set; }
    /// <summary>
    /// Timings are frequently determined by occurrences such as waking, eating and sleep.
    /// </summary>
    public string When { get; set; }
    /// <summary>
    /// Extension container element for When
    /// </summary>
    public Element _When { get; set; }
    /// <summary>
    /// Serialize to a JSON object
    /// </summary>
    public new void SerializeJson(Utf8JsonWriter writer, JsonSerializerOptions options, bool includeStartObject = true)
    {
      if (includeStartObject)
      {
        writer.WriteStartObject();
      }
      ((fhirCsR2.Models.Element)this).SerializeJson(writer, options, false);

      if (BoundsQuantity != null)
      {
        writer.WritePropertyName("boundsQuantity");
        BoundsQuantity.SerializeJson(writer, options);
      }

      if (BoundsRange != null)
      {
        writer.WritePropertyName("boundsRange");
        BoundsRange.SerializeJson(writer, options);
      }

      if (BoundsPeriod != null)
      {
        writer.WritePropertyName("boundsPeriod");
        BoundsPeriod.SerializeJson(writer, options);
      }

      if (Count != null)
      {
        writer.WriteNumber("count", (int)Count!);
      }

      if (_Count != null)
      {
        writer.WritePropertyName("_count");
        _Count.SerializeJson(writer, options);
      }

      if (Duration != null)
      {
        writer.WriteNumber("duration", (decimal)Duration!);
      }

      if (_Duration != null)
      {
        writer.WritePropertyName("_duration");
        _Duration.SerializeJson(writer, options);
      }

      if (DurationMax != null)
      {
        writer.WriteNumber("durationMax", (decimal)DurationMax!);
      }

      if (_DurationMax != null)
      {
        writer.WritePropertyName("_durationMax");
        _DurationMax.SerializeJson(writer, options);
      }

      if (!string.IsNullOrEmpty(DurationUnits))
      {
        writer.WriteString("durationUnits", (string)DurationUnits!);
      }

      if (_DurationUnits != null)
      {
        writer.WritePropertyName("_durationUnits");
        _DurationUnits.SerializeJson(writer, options);
      }

      if (Frequency != null)
      {
        writer.WriteNumber("frequency", (int)Frequency!);
      }

      if (_Frequency != null)
      {
        writer.WritePropertyName("_frequency");
        _Frequency.SerializeJson(writer, options);
      }

      if (FrequencyMax != null)
      {
        writer.WriteNumber("frequencyMax", (int)FrequencyMax!);
      }

      if (_FrequencyMax != null)
      {
        writer.WritePropertyName("_frequencyMax");
        _FrequencyMax.SerializeJson(writer, options);
      }

      if (Period != null)
      {
        writer.WriteNumber("period", (decimal)Period!);
      }

      if (_Period != null)
      {
        writer.WritePropertyName("_period");
        _Period.SerializeJson(writer, options);
      }

      if (PeriodMax != null)
      {
        writer.WriteNumber("periodMax", (decimal)PeriodMax!);
      }

      if (_PeriodMax != null)
      {
        writer.WritePropertyName("_periodMax");
        _PeriodMax.SerializeJson(writer, options);
      }

      if (!string.IsNullOrEmpty(PeriodUnits))
      {
        writer.WriteString("periodUnits", (string)PeriodUnits!);
      }

      if (_PeriodUnits != null)
      {
        writer.WritePropertyName("_periodUnits");
        _PeriodUnits.SerializeJson(writer, options);
      }

      if (!string.IsNullOrEmpty(When))
      {
        writer.WriteString("when", (string)When!);
      }

      if (_When != null)
      {
        writer.WritePropertyName("_when");
        _When.SerializeJson(writer, options);
      }

      if (includeStartObject)
      {
        writer.WriteEndObject();
      }
    }
    /// <summary>
    /// Deserialize a JSON property
    /// </summary>
    public new void DeserializeJsonProperty(ref Utf8JsonReader reader, JsonSerializerOptions options, string propertyName)
    {
      switch (propertyName)
      {
        case "boundsQuantity":
          BoundsQuantity = new fhirCsR2.Models.Quantity();
          BoundsQuantity.DeserializeJson(ref reader, options);
          break;

        case "boundsRange":
          BoundsRange = new fhirCsR2.Models.Range();
          BoundsRange.DeserializeJson(ref reader, options);
          break;

        case "boundsPeriod":
          BoundsPeriod = new fhirCsR2.Models.Period();
          BoundsPeriod.DeserializeJson(ref reader, options);
          break;

        case "count":
          Count = reader.GetInt32();
          break;

        case "_count":
          _Count = new fhirCsR2.Models.Element();
          _Count.DeserializeJson(ref reader, options);
          break;

        case "duration":
          Duration = reader.GetDecimal();
          break;

        case "_duration":
          _Duration = new fhirCsR2.Models.Element();
          _Duration.DeserializeJson(ref reader, options);
          break;

        case "durationMax":
          DurationMax = reader.GetDecimal();
          break;

        case "_durationMax":
          _DurationMax = new fhirCsR2.Models.Element();
          _DurationMax.DeserializeJson(ref reader, options);
          break;

        case "durationUnits":
          DurationUnits = reader.GetString();
          break;

        case "_durationUnits":
          _DurationUnits = new fhirCsR2.Models.Element();
          _DurationUnits.DeserializeJson(ref reader, options);
          break;

        case "frequency":
          Frequency = reader.GetInt32();
          break;

        case "_frequency":
          _Frequency = new fhirCsR2.Models.Element();
          _Frequency.DeserializeJson(ref reader, options);
          break;

        case "frequencyMax":
          FrequencyMax = reader.GetInt32();
          break;

        case "_frequencyMax":
          _FrequencyMax = new fhirCsR2.Models.Element();
          _FrequencyMax.DeserializeJson(ref reader, options);
          break;

        case "period":
          Period = reader.GetDecimal();
          break;

        case "_period":
          _Period = new fhirCsR2.Models.Element();
          _Period.DeserializeJson(ref reader, options);
          break;

        case "periodMax":
          PeriodMax = reader.GetDecimal();
          break;

        case "_periodMax":
          _PeriodMax = new fhirCsR2.Models.Element();
          _PeriodMax.DeserializeJson(ref reader, options);
          break;

        case "periodUnits":
          PeriodUnits = reader.GetString();
          break;

        case "_periodUnits":
          _PeriodUnits = new fhirCsR2.Models.Element();
          _PeriodUnits.DeserializeJson(ref reader, options);
          break;

        case "when":
          When = reader.GetString();
          break;

        case "_when":
          _When = new fhirCsR2.Models.Element();
          _When.DeserializeJson(ref reader, options);
          break;

        default:
          ((fhirCsR2.Models.Element)this).DeserializeJsonProperty(ref reader, options, propertyName);
          break;
      }
    }

    /// <summary>
    /// Deserialize a JSON object
    /// </summary>
    public new void DeserializeJson(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
      string propertyName;

      while (reader.Read())
      {
        if (reader.TokenType == JsonTokenType.EndObject)
        {
          return;
        }

        if (reader.TokenType == JsonTokenType.PropertyName)
        {
          propertyName = reader.GetString();
          reader.Read();
          this.DeserializeJsonProperty(ref reader, options, propertyName);
        }
      }

      throw new JsonException();
    }
  }
  /// <summary>
  /// Code Values for the Timing.repeat.durationUnits field
  /// </summary>
  public static class TimingRepeatDurationUnitsCodes {
    public const string S = "s";
    public const string MIN = "min";
    public const string H = "h";
    public const string D = "d";
    public const string WK = "wk";
    public const string MO = "mo";
    public const string A = "a";
    public static HashSet<string> Values = new HashSet<string>() {
      "s",
      "min",
      "h",
      "d",
      "wk",
      "mo",
      "a",
    };
  }
  /// <summary>
  /// Code Values for the Timing.repeat.periodUnits field
  /// </summary>
  public static class TimingRepeatPeriodUnitsCodes {
    public const string S = "s";
    public const string MIN = "min";
    public const string H = "h";
    public const string D = "d";
    public const string WK = "wk";
    public const string MO = "mo";
    public const string A = "a";
    public static HashSet<string> Values = new HashSet<string>() {
      "s",
      "min",
      "h",
      "d",
      "wk",
      "mo",
      "a",
    };
  }
  /// <summary>
  /// Specifies an event that may occur multiple times. Timing schedules are used to record when things are expected or requested to occur. The most common usage is in dosage instructions for medications. They are also used when planning care of various kinds.
  /// </summary>
  [JsonConverter(typeof(fhirCsR2.Serialization.JsonStreamComponentConverter<Timing>))]
  public class Timing : Element,  IFhirJsonSerializable {
    /// <summary>
    /// A code for the timing pattern. Some codes such as BID are ubiquitous, but many institutions define their own additional codes.
    /// </summary>
    public CodeableConcept Code { get; set; }
    /// <summary>
    /// In an MAR, for instance, you need to take a general specification, and turn it into a precise specification.
    /// </summary>
    public List<string> Event { get; set; }
    /// <summary>
    /// Extension container element for Event
    /// </summary>
    public List<Element> _Event { get; set; }
    /// <summary>
    /// Many timing schedules are determined by regular repetitions.
    /// </summary>
    public TimingRepeat Repeat { get; set; }
    /// <summary>
    /// Serialize to a JSON object
    /// </summary>
    public new void SerializeJson(Utf8JsonWriter writer, JsonSerializerOptions options, bool includeStartObject = true)
    {
      if (includeStartObject)
      {
        writer.WriteStartObject();
      }
      ((fhirCsR2.Models.Element)this).SerializeJson(writer, options, false);

      if ((Event != null) && (Event.Count != 0))
      {
        writer.WritePropertyName("event");
        writer.WriteStartArray();

        foreach (string valEvent in Event)
        {
          writer.WriteStringValue(valEvent);
        }

        writer.WriteEndArray();
      }

      if ((_Event != null) && (_Event.Count != 0))
      {
        writer.WritePropertyName("_event");
        writer.WriteStartArray();

        foreach (Element val_Event in _Event)
        {
          val_Event.SerializeJson(writer, options, true);
        }

        writer.WriteEndArray();
      }

      if (Repeat != null)
      {
        writer.WritePropertyName("repeat");
        Repeat.SerializeJson(writer, options);
      }

      if (Code != null)
      {
        writer.WritePropertyName("code");
        Code.SerializeJson(writer, options);
      }

      if (includeStartObject)
      {
        writer.WriteEndObject();
      }
    }
    /// <summary>
    /// Deserialize a JSON property
    /// </summary>
    public new void DeserializeJsonProperty(ref Utf8JsonReader reader, JsonSerializerOptions options, string propertyName)
    {
      switch (propertyName)
      {
        case "code":
          Code = new fhirCsR2.Models.CodeableConcept();
          Code.DeserializeJson(ref reader, options);
          break;

        case "event":
          if ((reader.TokenType != JsonTokenType.StartArray) || (!reader.Read()))
          {
            throw new JsonException();
          }

          Event = new List<string>();

          while (reader.TokenType != JsonTokenType.EndArray)
          {
            Event.Add(reader.GetString());

            if (!reader.Read())
            {
              throw new JsonException();
            }
          }

          if (Event.Count == 0)
          {
            Event = null;
          }

          break;

        case "_event":
          if ((reader.TokenType != JsonTokenType.StartArray) || (!reader.Read()))
          {
            throw new JsonException();
          }

          _Event = new List<Element>();

          while (reader.TokenType != JsonTokenType.EndArray)
          {
            fhirCsR2.Models.Element obj_Event = new fhirCsR2.Models.Element();
            obj_Event.DeserializeJson(ref reader, options);
            _Event.Add(obj_Event);

            if (!reader.Read())
            {
              throw new JsonException();
            }
          }

          if (_Event.Count == 0)
          {
            _Event = null;
          }

          break;

        case "repeat":
          Repeat = new fhirCsR2.Models.TimingRepeat();
          Repeat.DeserializeJson(ref reader, options);
          break;

        default:
          ((fhirCsR2.Models.Element)this).DeserializeJsonProperty(ref reader, options, propertyName);
          break;
      }
    }

    /// <summary>
    /// Deserialize a JSON object
    /// </summary>
    public new void DeserializeJson(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
      string propertyName;

      while (reader.Read())
      {
        if (reader.TokenType == JsonTokenType.EndObject)
        {
          return;
        }

        if (reader.TokenType == JsonTokenType.PropertyName)
        {
          propertyName = reader.GetString();
          reader.Read();
          this.DeserializeJsonProperty(ref reader, options, propertyName);
        }
      }

      throw new JsonException();
    }
  }
}
