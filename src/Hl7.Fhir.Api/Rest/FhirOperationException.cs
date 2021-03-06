﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hl7.Fhir;
using Hl7.Fhir.Model;
using Hl7.Fhir.Support;
using System.Net;
using System.IO;
using Newtonsoft.Json;



namespace Hl7.Fhir.Rest
{
    public class FhirOperationException : Exception
    {
        public OperationOutcome Outcome { get; set; }

        public FhirOperationException(string message) : base(message) 
        { 
        }


        public FhirOperationException(string message, Exception inner) : base(message, inner)
        { 
        }

        public FhirOperationException(string message, OperationOutcome outcome, Exception inner)
            : base(message, inner)
        {
            Outcome = outcome;
        }

        public FhirOperationException(string message, OperationOutcome outcome)
            : base(message)
        {
            Outcome = outcome;
        }

    }



}
