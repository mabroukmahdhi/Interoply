// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using System;
using Xeptions;

namespace Interoply.Models.Events.Exceptions
{
    public class InteroplyEventServiceException : Xeption
    {
        public InteroplyEventServiceException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
