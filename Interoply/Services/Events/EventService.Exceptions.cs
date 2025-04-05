// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using System.Threading.Tasks;
using Interoply.Models.Events.Exceptions;
using Xeptions;

namespace Interoply.Services.Events
{
    internal partial class EventService
    {
        private delegate ValueTask ReturningNothingFunction();

        private async ValueTask TryCatch(ReturningNothingFunction returningNothingFunction)
        {
            try
            {
                await returningNothingFunction();
            }
            catch (NullInteroplyEventException nullInteroplyEventException)
            {
                throw CreateInteroplyEventValidationException(nullInteroplyEventException);
            }
        }

        private static InteroplyEventValidationException CreateInteroplyEventValidationException(
            Xeption innerException)
        {
            return new InteroplyEventValidationException(
                message: "Interoply Callback event validation error occurred, fix the errors and try again.",
                innerException);
        }
    }
}
