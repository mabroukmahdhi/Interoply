// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using System;

namespace Interoply.Models.Events.Exceptions
{
    public class InteroplyEventValidationException : Exception
    {
        public InteroplyEventValidationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
