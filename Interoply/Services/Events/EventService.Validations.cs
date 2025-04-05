// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using System;
using System.Threading.Tasks;
using Interoply.Models.Events.Exceptions;

namespace Interoply.Services.Events
{
    internal partial class EventService
    {
        private static void ValidateInteroplyCallback<T>(Func<T, ValueTask> callback)
        {
            if (callback == null)
            {
                throw new NullInteroplyEventException(
                    message: "Interoply Callback event is null");
            }
        }
    }
}
