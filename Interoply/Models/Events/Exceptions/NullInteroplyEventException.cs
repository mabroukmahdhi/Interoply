// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using Xeptions;

namespace Interoply.Models.Events.Exceptions
{
    internal class NullInteroplyEventException : Xeption
    {
        internal NullInteroplyEventException(string message) : base(message)
        { }
    }
}
