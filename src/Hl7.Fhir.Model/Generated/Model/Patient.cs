﻿using System;
using System.Collections.Generic;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Validation;
using System.Linq;
using System.Runtime.Serialization;

/*
  Copyright (c) 2011-2013, HL7, Inc.
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

//
// Generated on Thu, Apr 17, 2014 11:39+0200 for FHIR v0.80
//
namespace Hl7.Fhir.Model
{
    /// <summary>
    /// Information about a person or animal receiving health care services
    /// </summary>
    [FhirType("Patient", IsResource=true)]
    [DataContract]
    public partial class Patient : Hl7.Fhir.Model.Resource, System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// The type of link between this patient resource and another patient resource.
        /// </summary>
        [FhirEnumeration("LinkType")]
        public enum LinkType
        {
            [EnumLiteral("replace")]
            Replace, // The patient resource containing this link must no longer be used. The link points forward to another patient resource that must be used in lieu of the patient resource that contains the link.
            [EnumLiteral("refer")]
            Refer, // The patient resource containing this link is in use and valid but not considered the main source of information about a patient. The link points forward to another patient resource that should be consulted to retrieve additional patient information.
            [EnumLiteral("seealso")]
            Seealso, // The patient resource containing this link is in use and valid, but points to another patient resource that is known to contain data about the same person. Data in this resource might overlap or contradict information found in the other patient resource. This link does not indicate any relative importance of the resources concerned, and both should be regarded as equally valid.
        }
        
        /// <summary>
        /// null
        /// </summary>
        [FhirType("ContactComponent")]
        [DataContract]
        public partial class ContactComponent : Hl7.Fhir.Model.Element, System.ComponentModel.INotifyPropertyChanged
        {
            /// <summary>
            /// The kind of relationship
            /// </summary>
            [FhirElement("relationship", InSummary=true, Order=40)]
            [Cardinality(Min=0,Max=-1)]
            [DataMember]
            public List<Hl7.Fhir.Model.CodeableConcept> Relationship
            {
                get { return _Relationship; }
                set { _Relationship = value; OnPropertyChanged("Relationship"); }
            }
            private List<Hl7.Fhir.Model.CodeableConcept> _Relationship;
            
            /// <summary>
            /// A name associated with the person
            /// </summary>
            [FhirElement("name", InSummary=true, Order=50)]
            [DataMember]
            public Hl7.Fhir.Model.HumanName Name
            {
                get { return _Name; }
                set { _Name = value; OnPropertyChanged("Name"); }
            }
            private Hl7.Fhir.Model.HumanName _Name;
            
            /// <summary>
            /// A contact detail for the person
            /// </summary>
            [FhirElement("telecom", InSummary=true, Order=60)]
            [Cardinality(Min=0,Max=-1)]
            [DataMember]
            public List<Hl7.Fhir.Model.Contact> Telecom
            {
                get { return _Telecom; }
                set { _Telecom = value; OnPropertyChanged("Telecom"); }
            }
            private List<Hl7.Fhir.Model.Contact> _Telecom;
            
            /// <summary>
            /// Address for the contact person
            /// </summary>
            [FhirElement("address", InSummary=true, Order=70)]
            [DataMember]
            public Hl7.Fhir.Model.Address Address
            {
                get { return _Address; }
                set { _Address = value; OnPropertyChanged("Address"); }
            }
            private Hl7.Fhir.Model.Address _Address;
            
            /// <summary>
            /// Gender for administrative purposes
            /// </summary>
            [FhirElement("gender", InSummary=true, Order=80)]
            [DataMember]
            public Hl7.Fhir.Model.CodeableConcept Gender
            {
                get { return _Gender; }
                set { _Gender = value; OnPropertyChanged("Gender"); }
            }
            private Hl7.Fhir.Model.CodeableConcept _Gender;
            
            /// <summary>
            /// Organization that is associated with the contact
            /// </summary>
            [FhirElement("organization", InSummary=true, Order=90)]
            [References("Organization")]
            [DataMember]
            public Hl7.Fhir.Model.ResourceReference Organization
            {
                get { return _Organization; }
                set { _Organization = value; OnPropertyChanged("Organization"); }
            }
            private Hl7.Fhir.Model.ResourceReference _Organization;
            
        }
        
        
        /// <summary>
        /// null
        /// </summary>
        [FhirType("AnimalComponent")]
        [DataContract]
        public partial class AnimalComponent : Hl7.Fhir.Model.Element, System.ComponentModel.INotifyPropertyChanged
        {
            /// <summary>
            /// E.g. Dog, Cow
            /// </summary>
            [FhirElement("species", InSummary=true, Order=40)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Hl7.Fhir.Model.CodeableConcept Species
            {
                get { return _Species; }
                set { _Species = value; OnPropertyChanged("Species"); }
            }
            private Hl7.Fhir.Model.CodeableConcept _Species;
            
            /// <summary>
            /// E.g. Poodle, Angus
            /// </summary>
            [FhirElement("breed", InSummary=true, Order=50)]
            [DataMember]
            public Hl7.Fhir.Model.CodeableConcept Breed
            {
                get { return _Breed; }
                set { _Breed = value; OnPropertyChanged("Breed"); }
            }
            private Hl7.Fhir.Model.CodeableConcept _Breed;
            
            /// <summary>
            /// E.g. Neutered, Intact
            /// </summary>
            [FhirElement("genderStatus", InSummary=true, Order=60)]
            [DataMember]
            public Hl7.Fhir.Model.CodeableConcept GenderStatus
            {
                get { return _GenderStatus; }
                set { _GenderStatus = value; OnPropertyChanged("GenderStatus"); }
            }
            private Hl7.Fhir.Model.CodeableConcept _GenderStatus;
            
        }
        
        
        /// <summary>
        /// null
        /// </summary>
        [FhirType("PatientLinkComponent")]
        [DataContract]
        public partial class PatientLinkComponent : Hl7.Fhir.Model.Element, System.ComponentModel.INotifyPropertyChanged
        {
            /// <summary>
            /// The other patient resource that the link refers to
            /// </summary>
            [FhirElement("other", InSummary=true, Order=40)]
            [References("Patient")]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Hl7.Fhir.Model.ResourceReference Other
            {
                get { return _Other; }
                set { _Other = value; OnPropertyChanged("Other"); }
            }
            private Hl7.Fhir.Model.ResourceReference _Other;
            
            /// <summary>
            /// replace | refer | seealso - type of link
            /// </summary>
            [FhirElement("type", InSummary=true, Order=50)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Code<Hl7.Fhir.Model.Patient.LinkType> TypeElement
            {
                get { return _TypeElement; }
                set { _TypeElement = value; OnPropertyChanged("TypeElement"); }
            }
            private Code<Hl7.Fhir.Model.Patient.LinkType> _TypeElement;
            
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public Hl7.Fhir.Model.Patient.LinkType? Type
            {
                get { return TypeElement != null ? TypeElement.Value : null; }
                set
                {
                    if(value == null)
                      TypeElement = null; 
                    else
                      TypeElement = new Code<Hl7.Fhir.Model.Patient.LinkType>(value);
                    OnPropertyChanged("Type");
                }
            }
            
        }
        
        
        /// <summary>
        /// An identifier for the person as this patient
        /// </summary>
        [FhirElement("identifier", InSummary=true, Order=70)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.Identifier> Identifier
        {
            get { return _Identifier; }
            set { _Identifier = value; OnPropertyChanged("Identifier"); }
        }
        private List<Hl7.Fhir.Model.Identifier> _Identifier;
        
        /// <summary>
        /// A name associated with the patient
        /// </summary>
        [FhirElement("name", InSummary=true, Order=80)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.HumanName> Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged("Name"); }
        }
        private List<Hl7.Fhir.Model.HumanName> _Name;
        
        /// <summary>
        /// A contact detail for the individual
        /// </summary>
        [FhirElement("telecom", InSummary=true, Order=90)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.Contact> Telecom
        {
            get { return _Telecom; }
            set { _Telecom = value; OnPropertyChanged("Telecom"); }
        }
        private List<Hl7.Fhir.Model.Contact> _Telecom;
        
        /// <summary>
        /// Gender for administrative purposes
        /// </summary>
        [FhirElement("gender", InSummary=true, Order=100)]
        [DataMember]
        public Hl7.Fhir.Model.CodeableConcept Gender
        {
            get { return _Gender; }
            set { _Gender = value; OnPropertyChanged("Gender"); }
        }
        private Hl7.Fhir.Model.CodeableConcept _Gender;
        
        /// <summary>
        /// The date and time of birth for the individual
        /// </summary>
        [FhirElement("birthDate", InSummary=true, Order=110)]
        [DataMember]
        public Hl7.Fhir.Model.FhirDateTime BirthDateElement
        {
            get { return _BirthDateElement; }
            set { _BirthDateElement = value; OnPropertyChanged("BirthDateElement"); }
        }
        private Hl7.Fhir.Model.FhirDateTime _BirthDateElement;
        
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public string BirthDate
        {
            get { return BirthDateElement != null ? BirthDateElement.Value : null; }
            set
            {
                if(value == null)
                  BirthDateElement = null; 
                else
                  BirthDateElement = new Hl7.Fhir.Model.FhirDateTime(value);
                OnPropertyChanged("BirthDate");
            }
        }
        
        /// <summary>
        /// Indicates if the individual is deceased or not
        /// </summary>
        [FhirElement("deceased", InSummary=true, Order=120, Choice=ChoiceType.DatatypeChoice)]
        [AllowedTypes(typeof(Hl7.Fhir.Model.FhirBoolean),typeof(Hl7.Fhir.Model.FhirDateTime))]
        [DataMember]
        public Hl7.Fhir.Model.Element Deceased
        {
            get { return _Deceased; }
            set { _Deceased = value; OnPropertyChanged("Deceased"); }
        }
        private Hl7.Fhir.Model.Element _Deceased;
        
        /// <summary>
        /// Addresses for the individual
        /// </summary>
        [FhirElement("address", InSummary=true, Order=130)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.Address> Address
        {
            get { return _Address; }
            set { _Address = value; OnPropertyChanged("Address"); }
        }
        private List<Hl7.Fhir.Model.Address> _Address;
        
        /// <summary>
        /// Marital (civil) status of a person
        /// </summary>
        [FhirElement("maritalStatus", InSummary=true, Order=140)]
        [DataMember]
        public Hl7.Fhir.Model.CodeableConcept MaritalStatus
        {
            get { return _MaritalStatus; }
            set { _MaritalStatus = value; OnPropertyChanged("MaritalStatus"); }
        }
        private Hl7.Fhir.Model.CodeableConcept _MaritalStatus;
        
        /// <summary>
        /// Whether patient is part of a multiple birth
        /// </summary>
        [FhirElement("multipleBirth", InSummary=true, Order=150, Choice=ChoiceType.DatatypeChoice)]
        [AllowedTypes(typeof(Hl7.Fhir.Model.FhirBoolean),typeof(Hl7.Fhir.Model.Integer))]
        [DataMember]
        public Hl7.Fhir.Model.Element MultipleBirth
        {
            get { return _MultipleBirth; }
            set { _MultipleBirth = value; OnPropertyChanged("MultipleBirth"); }
        }
        private Hl7.Fhir.Model.Element _MultipleBirth;
        
        /// <summary>
        /// Image of the person
        /// </summary>
        [FhirElement("photo", Order=160)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.Attachment> Photo
        {
            get { return _Photo; }
            set { _Photo = value; OnPropertyChanged("Photo"); }
        }
        private List<Hl7.Fhir.Model.Attachment> _Photo;
        
        /// <summary>
        /// A contact party (e.g. guardian, partner, friend) for the patient
        /// </summary>
        [FhirElement("contact", Order=170)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.Patient.ContactComponent> Contact
        {
            get { return _Contact; }
            set { _Contact = value; OnPropertyChanged("Contact"); }
        }
        private List<Hl7.Fhir.Model.Patient.ContactComponent> _Contact;
        
        /// <summary>
        /// If this patient is an animal (non-human)
        /// </summary>
        [FhirElement("animal", InSummary=true, Order=180)]
        [DataMember]
        public Hl7.Fhir.Model.Patient.AnimalComponent Animal
        {
            get { return _Animal; }
            set { _Animal = value; OnPropertyChanged("Animal"); }
        }
        private Hl7.Fhir.Model.Patient.AnimalComponent _Animal;
        
        /// <summary>
        /// Languages which may be used to communicate with the patient about his or her health
        /// </summary>
        [FhirElement("communication", Order=190)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.CodeableConcept> Communication
        {
            get { return _Communication; }
            set { _Communication = value; OnPropertyChanged("Communication"); }
        }
        private List<Hl7.Fhir.Model.CodeableConcept> _Communication;
        
        /// <summary>
        /// Patient's nominated care provider
        /// </summary>
        [FhirElement("careProvider", Order=200)]
        [References("Organization","Practitioner")]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.ResourceReference> CareProvider
        {
            get { return _CareProvider; }
            set { _CareProvider = value; OnPropertyChanged("CareProvider"); }
        }
        private List<Hl7.Fhir.Model.ResourceReference> _CareProvider;
        
        /// <summary>
        /// Organization that is the custodian of the patient record
        /// </summary>
        [FhirElement("managingOrganization", InSummary=true, Order=210)]
        [References("Organization")]
        [DataMember]
        public Hl7.Fhir.Model.ResourceReference ManagingOrganization
        {
            get { return _ManagingOrganization; }
            set { _ManagingOrganization = value; OnPropertyChanged("ManagingOrganization"); }
        }
        private Hl7.Fhir.Model.ResourceReference _ManagingOrganization;
        
        /// <summary>
        /// Link to another patient resource that concerns the same actual person
        /// </summary>
        [FhirElement("link", InSummary=true, Order=220)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.Patient.PatientLinkComponent> Link
        {
            get { return _Link; }
            set { _Link = value; OnPropertyChanged("Link"); }
        }
        private List<Hl7.Fhir.Model.Patient.PatientLinkComponent> _Link;
        
        /// <summary>
        /// Whether this patient's record is in active use
        /// </summary>
        [FhirElement("active", InSummary=true, Order=230)]
        [DataMember]
        public Hl7.Fhir.Model.FhirBoolean ActiveElement
        {
            get { return _ActiveElement; }
            set { _ActiveElement = value; OnPropertyChanged("ActiveElement"); }
        }
        private Hl7.Fhir.Model.FhirBoolean _ActiveElement;
        
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public bool? Active
        {
            get { return ActiveElement != null ? ActiveElement.Value : null; }
            set
            {
                if(value == null)
                  ActiveElement = null; 
                else
                  ActiveElement = new Hl7.Fhir.Model.FhirBoolean(value);
                OnPropertyChanged("Active");
            }
        }
        
    }
    
}
