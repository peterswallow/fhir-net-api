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
    /// A request for a diagnostic service
    /// </summary>
    [FhirType("DiagnosticOrder", IsResource=true)]
    [DataContract]
    public partial class DiagnosticOrder : Hl7.Fhir.Model.Resource, System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// The status of a diagnostic order
        /// </summary>
        [FhirEnumeration("DiagnosticOrderStatus")]
        public enum DiagnosticOrderStatus
        {
            [EnumLiteral("requested")]
            Requested, // The request has been placed.
            [EnumLiteral("received")]
            Received, // The receiving system has received the order, but not yet decided whether it will be performed.
            [EnumLiteral("accepted")]
            Accepted, // The receiving system has accepted the order, but work has not yet commenced.
            [EnumLiteral("in progress")]
            InProgress, // The work to fulfill the order is happening.
            [EnumLiteral("review")]
            Review, // The work is complete, and the outcomes are being reviewed for approval.
            [EnumLiteral("completed")]
            Completed, // The work has been complete, the report(s) released, and no further work is planned.
            [EnumLiteral("suspended")]
            Suspended, // The request has been held by originating system/user request.
            [EnumLiteral("rejected")]
            Rejected, // The receiving system has declined to fulfill the request.
            [EnumLiteral("failed")]
            Failed, // The diagnostic investigation was attempted, but due to some procedural error, it could not be completed.
        }
        
        /// <summary>
        /// The clinical priority of a diagnostic order
        /// </summary>
        [FhirEnumeration("DiagnosticOrderPriority")]
        public enum DiagnosticOrderPriority
        {
            [EnumLiteral("routine")]
            Routine, // The order has a normal priority.
            [EnumLiteral("urgent")]
            Urgent, // The order should be urgently.
            [EnumLiteral("stat")]
            Stat, // The order is time-critical.
            [EnumLiteral("asap")]
            Asap, // The order should be acted on as soon as possible.
        }
        
        /// <summary>
        /// null
        /// </summary>
        [FhirType("DiagnosticOrderItemComponent")]
        [DataContract]
        public partial class DiagnosticOrderItemComponent : Hl7.Fhir.Model.Element, System.ComponentModel.INotifyPropertyChanged
        {
            /// <summary>
            /// Code to indicate the item (test or panel) being ordered
            /// </summary>
            [FhirElement("code", InSummary=true, Order=40)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Hl7.Fhir.Model.CodeableConcept Code
            {
                get { return _Code; }
                set { _Code = value; OnPropertyChanged("Code"); }
            }
            private Hl7.Fhir.Model.CodeableConcept _Code;
            
            /// <summary>
            /// If this item relates to specific specimens
            /// </summary>
            [FhirElement("specimen", InSummary=true, Order=50)]
            [References("Specimen")]
            [Cardinality(Min=0,Max=-1)]
            [DataMember]
            public List<Hl7.Fhir.Model.ResourceReference> Specimen
            {
                get { return _Specimen; }
                set { _Specimen = value; OnPropertyChanged("Specimen"); }
            }
            private List<Hl7.Fhir.Model.ResourceReference> _Specimen;
            
            /// <summary>
            /// Location of requested test (if applicable)
            /// </summary>
            [FhirElement("bodySite", InSummary=true, Order=60)]
            [DataMember]
            public Hl7.Fhir.Model.CodeableConcept BodySite
            {
                get { return _BodySite; }
                set { _BodySite = value; OnPropertyChanged("BodySite"); }
            }
            private Hl7.Fhir.Model.CodeableConcept _BodySite;
            
            /// <summary>
            /// requested | received | accepted | in progress | review | completed | suspended | rejected | failed
            /// </summary>
            [FhirElement("status", InSummary=true, Order=70)]
            [DataMember]
            public Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus> StatusElement
            {
                get { return _StatusElement; }
                set { _StatusElement = value; OnPropertyChanged("StatusElement"); }
            }
            private Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus> _StatusElement;
            
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus? Status
            {
                get { return StatusElement != null ? StatusElement.Value : null; }
                set
                {
                    if(value == null)
                      StatusElement = null; 
                    else
                      StatusElement = new Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus>(value);
                    OnPropertyChanged("Status");
                }
            }
            
            /// <summary>
            /// Events specific to this item
            /// </summary>
            [FhirElement("event", InSummary=true, Order=80)]
            [Cardinality(Min=0,Max=-1)]
            [DataMember]
            public List<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderEventComponent> Event
            {
                get { return _Event; }
                set { _Event = value; OnPropertyChanged("Event"); }
            }
            private List<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderEventComponent> _Event;
            
        }
        
        
        /// <summary>
        /// null
        /// </summary>
        [FhirType("DiagnosticOrderEventComponent")]
        [DataContract]
        public partial class DiagnosticOrderEventComponent : Hl7.Fhir.Model.Element, System.ComponentModel.INotifyPropertyChanged
        {
            /// <summary>
            /// requested | received | accepted | in progress | review | completed | suspended | rejected | failed
            /// </summary>
            [FhirElement("status", InSummary=true, Order=40)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus> StatusElement
            {
                get { return _StatusElement; }
                set { _StatusElement = value; OnPropertyChanged("StatusElement"); }
            }
            private Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus> _StatusElement;
            
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus? Status
            {
                get { return StatusElement != null ? StatusElement.Value : null; }
                set
                {
                    if(value == null)
                      StatusElement = null; 
                    else
                      StatusElement = new Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus>(value);
                    OnPropertyChanged("Status");
                }
            }
            
            /// <summary>
            /// More information about the event and it's context
            /// </summary>
            [FhirElement("description", InSummary=true, Order=50)]
            [DataMember]
            public Hl7.Fhir.Model.CodeableConcept Description
            {
                get { return _Description; }
                set { _Description = value; OnPropertyChanged("Description"); }
            }
            private Hl7.Fhir.Model.CodeableConcept _Description;
            
            /// <summary>
            /// The date at which the event happened
            /// </summary>
            [FhirElement("dateTime", InSummary=true, Order=60)]
            [Cardinality(Min=1,Max=1)]
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
            /// Who recorded or did this
            /// </summary>
            [FhirElement("actor", InSummary=true, Order=70)]
            [References("Practitioner","Device")]
            [DataMember]
            public Hl7.Fhir.Model.ResourceReference Actor
            {
                get { return _Actor; }
                set { _Actor = value; OnPropertyChanged("Actor"); }
            }
            private Hl7.Fhir.Model.ResourceReference _Actor;
            
        }
        
        
        /// <summary>
        /// Who and/or what test is about
        /// </summary>
        [FhirElement("subject", Order=70)]
        [References("Patient","Group","Location","Device")]
        [Cardinality(Min=1,Max=1)]
        [DataMember]
        public Hl7.Fhir.Model.ResourceReference Subject
        {
            get { return _Subject; }
            set { _Subject = value; OnPropertyChanged("Subject"); }
        }
        private Hl7.Fhir.Model.ResourceReference _Subject;
        
        /// <summary>
        /// Who ordered the test
        /// </summary>
        [FhirElement("orderer", Order=80)]
        [References("Practitioner")]
        [DataMember]
        public Hl7.Fhir.Model.ResourceReference Orderer
        {
            get { return _Orderer; }
            set { _Orderer = value; OnPropertyChanged("Orderer"); }
        }
        private Hl7.Fhir.Model.ResourceReference _Orderer;
        
        /// <summary>
        /// Identifiers assigned to this order
        /// </summary>
        [FhirElement("identifier", Order=90)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.Identifier> Identifier
        {
            get { return _Identifier; }
            set { _Identifier = value; OnPropertyChanged("Identifier"); }
        }
        private List<Hl7.Fhir.Model.Identifier> _Identifier;
        
        /// <summary>
        /// The encounter that this diagnostic order is associated with
        /// </summary>
        [FhirElement("encounter", Order=100)]
        [References("Encounter")]
        [DataMember]
        public Hl7.Fhir.Model.ResourceReference Encounter
        {
            get { return _Encounter; }
            set { _Encounter = value; OnPropertyChanged("Encounter"); }
        }
        private Hl7.Fhir.Model.ResourceReference _Encounter;
        
        /// <summary>
        /// Explanation/Justification for test
        /// </summary>
        [FhirElement("clinicalNotes", Order=110)]
        [DataMember]
        public Hl7.Fhir.Model.FhirString ClinicalNotesElement
        {
            get { return _ClinicalNotesElement; }
            set { _ClinicalNotesElement = value; OnPropertyChanged("ClinicalNotesElement"); }
        }
        private Hl7.Fhir.Model.FhirString _ClinicalNotesElement;
        
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public string ClinicalNotes
        {
            get { return ClinicalNotesElement != null ? ClinicalNotesElement.Value : null; }
            set
            {
                if(value == null)
                  ClinicalNotesElement = null; 
                else
                  ClinicalNotesElement = new Hl7.Fhir.Model.FhirString(value);
                OnPropertyChanged("ClinicalNotes");
            }
        }
        
        /// <summary>
        /// If the whole order relates to specific specimens
        /// </summary>
        [FhirElement("specimen", Order=120)]
        [References("Specimen")]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.ResourceReference> Specimen
        {
            get { return _Specimen; }
            set { _Specimen = value; OnPropertyChanged("Specimen"); }
        }
        private List<Hl7.Fhir.Model.ResourceReference> _Specimen;
        
        /// <summary>
        /// requested | received | accepted | in progress | review | completed | suspended | rejected | failed
        /// </summary>
        [FhirElement("status", Order=130)]
        [DataMember]
        public Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus> StatusElement
        {
            get { return _StatusElement; }
            set { _StatusElement = value; OnPropertyChanged("StatusElement"); }
        }
        private Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus> _StatusElement;
        
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus? Status
        {
            get { return StatusElement != null ? StatusElement.Value : null; }
            set
            {
                if(value == null)
                  StatusElement = null; 
                else
                  StatusElement = new Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus>(value);
                OnPropertyChanged("Status");
            }
        }
        
        /// <summary>
        /// routine | urgent | stat | asap
        /// </summary>
        [FhirElement("priority", Order=140)]
        [DataMember]
        public Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderPriority> PriorityElement
        {
            get { return _PriorityElement; }
            set { _PriorityElement = value; OnPropertyChanged("PriorityElement"); }
        }
        private Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderPriority> _PriorityElement;
        
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderPriority? Priority
        {
            get { return PriorityElement != null ? PriorityElement.Value : null; }
            set
            {
                if(value == null)
                  PriorityElement = null; 
                else
                  PriorityElement = new Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderPriority>(value);
                OnPropertyChanged("Priority");
            }
        }
        
        /// <summary>
        /// A list of events of interest in the lifecycle
        /// </summary>
        [FhirElement("event", Order=150)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderEventComponent> Event
        {
            get { return _Event; }
            set { _Event = value; OnPropertyChanged("Event"); }
        }
        private List<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderEventComponent> _Event;
        
        /// <summary>
        /// The items the orderer requested
        /// </summary>
        [FhirElement("item", Order=160)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderItemComponent> Item
        {
            get { return _Item; }
            set { _Item = value; OnPropertyChanged("Item"); }
        }
        private List<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderItemComponent> _Item;
        
    }
    
}
