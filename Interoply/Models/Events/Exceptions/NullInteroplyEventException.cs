// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using System;

namespace Interoply.Models.Events.Exceptions
{
    internal class NullInteroplyEventException : Exception
    {
        internal NullInteroplyEventException(string message) : base(message)
        { }
    }
}
