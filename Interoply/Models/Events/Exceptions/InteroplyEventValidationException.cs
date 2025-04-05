// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using Xeptions;

namespace Interoply.Models.Events.Exceptions
{
    public class InteroplyEventValidationException : Xeption
    {
        public InteroplyEventValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
