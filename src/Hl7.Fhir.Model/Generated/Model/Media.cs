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
    /// A photo, video, or audio recording acquired or used in healthcare. The actual content may be inline or provided by direct reference
    /// </summary>
    [FhirType("Media", IsResource=true)]
    [DataContract]
    public partial class Media : Hl7.Fhir.Model.Resource, System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Whether the Media is a photo, video, or audio
        /// </summary>
        [FhirEnumeration("MediaType")]
        public enum MediaType
        {
            [EnumLiteral("photo")]
            Photo, // The media consists of one or more unmoving images, including photographs, computer-generated graphs and charts, and scanned documents.
            [EnumLiteral("video")]
            Video, // The media consists of a series of frames that capture a moving image.
            [EnumLiteral("audio")]
            Audio, // The media consists of a sound recording.
        }
        
        /// <summary>
        /// photo | video | audio
        /// </summary>
        [FhirElement("type", InSummary=true, Order=70)]
        [Cardinality(Min=1,Max=1)]
        [DataMember]
        public Code<Hl7.Fhir.Model.Media.MediaType> TypeElement
        {
            get { return _TypeElement; }
            set { _TypeElement = value; OnPropertyChanged("TypeElement"); }
        }
        private Code<Hl7.Fhir.Model.Media.MediaType> _TypeElement;
        
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public Hl7.Fhir.Model.Media.MediaType? Type
        {
            get { return TypeElement != null ? TypeElement.Value : null; }
            set
            {
                if(value == null)
                  TypeElement = null; 
                else
                  TypeElement = new Code<Hl7.Fhir.Model.Media.MediaType>(value);
                OnPropertyChanged("Type");
            }
        }
        
        /// <summary>
        /// The type of acquisition equipment/process
        /// </summary>
        [FhirElement("subtype", InSummary=true, Order=80)]
        [DataMember]
        public Hl7.Fhir.Model.CodeableConcept Subtype
        {
            get { return _Subtype; }
            set { _Subtype = value; OnPropertyChanged("Subtype"); }
        }
        private Hl7.Fhir.Model.CodeableConcept _Subtype;
        
        /// <summary>
        /// Identifier(s) for the image
        /// </summary>
        [FhirElement("identifier", InSummary=true, Order=90)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.Identifier> Identifier
        {
            get { return _Identifier; }
            set { _Identifier = value; OnPropertyChanged("Identifier"); }
        }
        private List<Hl7.Fhir.Model.Identifier> _Identifier;
        
        /// <summary>
        /// When the media was taken/recorded (end)
        /// </summary>
        [FhirElement("dateTime", InSummary=true, Order=100)]
        [DataMember]
        public Hl7.Fhir.Model.FhirDateTime DateTimeElement
        {
            get { return _DateTimeElement; }
            set { _DateTimeElement = value; OnPropertyChanged("DateTimeElement"); }
        }
        private Hl7.Fhir.Model.FhirDateTime _DateTimeElement;
        
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public string DateTime
        {
            get { return DateTimeElement != null ? DateTimeElement.Value : null; }
            set
            {
                if(value == null)
                  DateTimeElement = null; 
                else
                  DateTimeElement = new Hl7.Fhir.Model.FhirDateTime(value);
                OnPropertyChanged("DateTime");
            }
        }
        
        /// <summary>
        /// Who/What this Media is a record of
        /// </summary>
        [FhirElement("subject", InSummary=true, Order=110)]
        [References("Patient","Practitioner","Group","Device","Specimen")]
        [DataMember]
        public Hl7.Fhir.Model.ResourceReference Subject
        {
            get { return _Subject; }
            set { _Subject = value; OnPropertyChanged("Subject"); }
        }
        private Hl7.Fhir.Model.ResourceReference _Subject;
        
        /// <summary>
        /// The person who generated the image
        /// </summary>
        [FhirElement("operator", InSummary=true, Order=120)]
        [References("Practitioner")]
        [DataMember]
        public Hl7.Fhir.Model.ResourceReference Operator
        {
            get { return _Operator; }
            set { _Operator = value; OnPropertyChanged("Operator"); }
        }
        private Hl7.Fhir.Model.ResourceReference _Operator;
        
        /// <summary>
        /// Imaging view e.g Lateral or Antero-posterior
        /// </summary>
        [FhirElement("view", InSummary=true, Order=130)]
        [DataMember]
        public Hl7.Fhir.Model.CodeableConcept View
        {
            get { return _View; }
            set { _View = value; OnPropertyChanged("View"); }
        }
        private Hl7.Fhir.Model.CodeableConcept _View;
        
        /// <summary>
        /// Name of the device/manufacturer
        /// </summary>
        [FhirElement("deviceName", InSummary=true, Order=140)]
        [DataMember]
        public Hl7.Fhir.Model.FhirString DeviceNameElement
        {
            get { return _DeviceNameElement; }
            set { _DeviceNameElement = value; OnPropertyChanged("DeviceNameElement"); }
        }
        private Hl7.Fhir.Model.FhirString _DeviceNameElement;
        
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public string DeviceName
        {
            get { return DeviceNameElement != null ? DeviceNameElement.Value : null; }
            set
            {
                if(value == null)
                  DeviceNameElement = null; 
                else
                  DeviceNameElement = new Hl7.Fhir.Model.FhirString(value);
                OnPropertyChanged("DeviceName");
            }
        }
        
        /// <summary>
        /// Height of the image in pixels(photo/video)
        /// </summary>
        [FhirElement("height", InSummary=true, Order=150)]
        [DataMember]
        public Hl7.Fhir.Model.Integer HeightElement
        {
            get { return _HeightElement; }
            set { _HeightElement = value; OnPropertyChanged("HeightElement"); }
        }
        private Hl7.Fhir.Model.Integer _HeightElement;
        
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public int? Height
        {
            get { return HeightElement != null ? HeightElement.Value : null; }
            set
            {
                if(value == null)
                  HeightElement = null; 
                else
                  HeightElement = new Hl7.Fhir.Model.Integer(value);
                OnPropertyChanged("Height");
            }
        }
        
        /// <summary>
        /// Width of the image in pixels (photo/video)
        /// </summary>
        [FhirElement("width", InSummary=true, Order=160)]
        [DataMember]
        public Hl7.Fhir.Model.Integer WidthElement
        {
            get { return _WidthElement; }
            set { _WidthElement = value; OnPropertyChanged("WidthElement"); }
        }
        private Hl7.Fhir.Model.Integer _WidthElement;
        
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public int? Width
        {
            get { return WidthElement != null ? WidthElement.Value : null; }
            set
            {
                if(value == null)
                  WidthElement = null; 
                else
                  WidthElement = new Hl7.Fhir.Model.Integer(value);
                OnPropertyChanged("Width");
            }
        }
        
        /// <summary>
        /// Number of frames if > 1 (photo)
        /// </summary>
        [FhirElement("frames", InSummary=true, Order=170)]
        [DataMember]
        public Hl7.Fhir.Model.Integer FramesElement
        {
            get { return _FramesElement; }
            set { _FramesElement = value; OnPropertyChanged("FramesElement"); }
        }
        private Hl7.Fhir.Model.Integer _FramesElement;
        
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public int? Frames
        {
            get { return FramesElement != null ? FramesElement.Value : null; }
            set
            {
                if(value == null)
                  FramesElement = null; 
                else
                  FramesElement = new Hl7.Fhir.Model.Integer(value);
                OnPropertyChanged("Frames");
            }
        }
        
        /// <summary>
        /// Length in seconds (audio / video)
        /// </summary>
        [FhirElement("length", InSummary=true, Order=180)]
        [DataMember]
        public Hl7.Fhir.Model.Integer LengthElement
        {
            get { return _LengthElement; }
            set { _LengthElement = value; OnPropertyChanged("LengthElement"); }
        }
        private Hl7.Fhir.Model.Integer _LengthElement;
        
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public int? Length
        {
            get { return LengthElement != null ? LengthElement.Value : null; }
            set
            {
                if(value == null)
                  LengthElement = null; 
                else
                  LengthElement = new Hl7.Fhir.Model.Integer(value);
                OnPropertyChanged("Length");
            }
        }
        
        /// <summary>
        /// Actual Media - reference or data
        /// </summary>
        [FhirElement("content", Order=190)]
        [Cardinality(Min=1,Max=1)]
        [DataMember]
        public Hl7.Fhir.Model.Attachment Content
        {
            get { return _Content; }
            set { _Content = value; OnPropertyChanged("Content"); }
        }
        private Hl7.Fhir.Model.Attachment _Content;
        
    }
    
}
