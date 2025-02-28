// <auto-generated/>
// Contents of: hl7.fhir.r5.core version: 5.0.0-ballot

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Specification;
using Hl7.Fhir.Utility;
using Hl7.Fhir.Validation;

/*
  Copyright (c) 2011+, HL7, Inc.
  All rights reserved.
  
  Redistribution and use in source and binary forms, with or without modification, 
  are permitted provided that the following conditions are met:
  
   * Redistributions of source code must retain the above copyright notice, this 
     list of conditions and the following disclaimer.
   * Redistributions in binary form must reproduce the above copyright notice, 
     this list of conditions and the following disclaimer in the documentation 
     and/or other materials provided with the distribution.
   * Neither the name of HL7 nor the names of its contributors may be used to 
     endorse or promote products derived from this software without specific 
     prior written permission.
  
  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
  IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
  INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
  WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
  ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
  POSSIBILITY OF SUCH DAMAGE.
  
*/

namespace Hl7.Fhir.Model
{
  /// <summary>
  /// Contact information
  /// </summary>
  [FhirType("ExtendedContactDetail")]
  [DataContract]
  public partial class ExtendedContactDetail : Hl7.Fhir.Model.Element, System.ComponentModel.INotifyPropertyChanged
  {
    /// <summary>
    /// FHIR Type Name
    /// </summary>
    [NotMapped]
    public override string TypeName { get { return "ExtendedContactDetail"; } }

    /// <summary>
    /// The type of contact
    /// </summary>
    [FhirElement("purpose", InSummary=true, Order=30)]
    [DataMember]
    public Hl7.Fhir.Model.CodeableConcept Purpose
    {
      get { return _Purpose; }
      set { _Purpose = value; OnPropertyChanged("Purpose"); }
    }

    private Hl7.Fhir.Model.CodeableConcept _Purpose;

    /// <summary>
    /// Name of an individual to contact
    /// </summary>
    [FhirElement("name", InSummary=true, Order=40)]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.HumanName> Name
    {
      get { if(_Name==null) _Name = new List<Hl7.Fhir.Model.HumanName>(); return _Name; }
      set { _Name = value; OnPropertyChanged("Name"); }
    }

    private List<Hl7.Fhir.Model.HumanName> _Name;

    /// <summary>
    /// Contact details (e.g.phone/fax/url)
    /// </summary>
    [FhirElement("telecom", InSummary=true, Order=50)]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.ContactPoint> Telecom
    {
      get { if(_Telecom==null) _Telecom = new List<Hl7.Fhir.Model.ContactPoint>(); return _Telecom; }
      set { _Telecom = value; OnPropertyChanged("Telecom"); }
    }

    private List<Hl7.Fhir.Model.ContactPoint> _Telecom;

    /// <summary>
    /// Address for the contact
    /// </summary>
    [FhirElement("address", InSummary=true, Order=60)]
    [DataMember]
    public Hl7.Fhir.Model.Address Address
    {
      get { return _Address; }
      set { _Address = value; OnPropertyChanged("Address"); }
    }

    private Hl7.Fhir.Model.Address _Address;

    /// <summary>
    /// This contact detail is handled/monitored by a specific organization
    /// </summary>
    [FhirElement("organization", InSummary=true, Order=70)]
    [CLSCompliant(false)]
    [References("Organization")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference Organization
    {
      get { return _Organization; }
      set { _Organization = value; OnPropertyChanged("Organization"); }
    }

    private Hl7.Fhir.Model.ResourceReference _Organization;

    /// <summary>
    /// Period that this contact was valid for usage
    /// </summary>
    [FhirElement("period", InSummary=true, Order=80)]
    [DataMember]
    public Hl7.Fhir.Model.Period Period
    {
      get { return _Period; }
      set { _Period = value; OnPropertyChanged("Period"); }
    }

    private Hl7.Fhir.Model.Period _Period;

    public override IDeepCopyable CopyTo(IDeepCopyable other)
    {
      var dest = other as ExtendedContactDetail;

      if (dest == null)
      {
        throw new ArgumentException("Can only copy to an object of the same type", "other");
      }

      base.CopyTo(dest);
      if(Purpose != null) dest.Purpose = (Hl7.Fhir.Model.CodeableConcept)Purpose.DeepCopy();
      if(Name != null) dest.Name = new List<Hl7.Fhir.Model.HumanName>(Name.DeepCopy());
      if(Telecom != null) dest.Telecom = new List<Hl7.Fhir.Model.ContactPoint>(Telecom.DeepCopy());
      if(Address != null) dest.Address = (Hl7.Fhir.Model.Address)Address.DeepCopy();
      if(Organization != null) dest.Organization = (Hl7.Fhir.Model.ResourceReference)Organization.DeepCopy();
      if(Period != null) dest.Period = (Hl7.Fhir.Model.Period)Period.DeepCopy();
      return dest;
    }

    public override IDeepCopyable DeepCopy()
    {
      return CopyTo(new ExtendedContactDetail());
    }

    public override bool Matches(IDeepComparable other)
    {
      var otherT = other as ExtendedContactDetail;
      if(otherT == null) return false;

      if(!base.Matches(otherT)) return false;
      if( !DeepComparable.Matches(Purpose, otherT.Purpose)) return false;
      if( !DeepComparable.Matches(Name, otherT.Name)) return false;
      if( !DeepComparable.Matches(Telecom, otherT.Telecom)) return false;
      if( !DeepComparable.Matches(Address, otherT.Address)) return false;
      if( !DeepComparable.Matches(Organization, otherT.Organization)) return false;
      if( !DeepComparable.Matches(Period, otherT.Period)) return false;

      return true;
    }

    public override bool IsExactly(IDeepComparable other)
    {
      var otherT = other as ExtendedContactDetail;
      if(otherT == null) return false;

      if(!base.IsExactly(otherT)) return false;
      if( !DeepComparable.IsExactly(Purpose, otherT.Purpose)) return false;
      if( !DeepComparable.IsExactly(Name, otherT.Name)) return false;
      if( !DeepComparable.IsExactly(Telecom, otherT.Telecom)) return false;
      if( !DeepComparable.IsExactly(Address, otherT.Address)) return false;
      if( !DeepComparable.IsExactly(Organization, otherT.Organization)) return false;
      if( !DeepComparable.IsExactly(Period, otherT.Period)) return false;

      return true;
    }

    [NotMapped]
    public override IEnumerable<Base> Children
    {
      get
      {
        foreach (var item in base.Children) yield return item;
        if (Purpose != null) yield return Purpose;
        foreach (var elem in Name) { if (elem != null) yield return elem; }
        foreach (var elem in Telecom) { if (elem != null) yield return elem; }
        if (Address != null) yield return Address;
        if (Organization != null) yield return Organization;
        if (Period != null) yield return Period;
      }

    }

    [NotMapped]
    public override IEnumerable<ElementValue> NamedChildren
    {
      get
      {
        foreach (var item in base.NamedChildren) yield return item;
        if (Purpose != null) yield return new ElementValue("purpose", Purpose);
        foreach (var elem in Name) { if (elem != null) yield return new ElementValue("name", elem); }
        foreach (var elem in Telecom) { if (elem != null) yield return new ElementValue("telecom", elem); }
        if (Address != null) yield return new ElementValue("address", Address);
        if (Organization != null) yield return new ElementValue("organization", Organization);
        if (Period != null) yield return new ElementValue("period", Period);
      }

    }

  }

}

// end of file
