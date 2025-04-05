// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using System;
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
            catch (Exception exception)
            {
                throw CreateInteroplyEventServiceException(exception);
            }
        }

        private static InteroplyEventValidationException CreateInteroplyEventValidationException(
            Xeption innerException)
        {
            return new InteroplyEventValidationException(
                message: "Interoply Callback event validation error occurred, fix the errors and try again.",
                innerException);
        }

        private static InteroplyEventServiceException CreateInteroplyEventServiceException(
            Exception innerException)
        {
            return new InteroplyEventServiceException(
                message: "Interoply Callback event service error occurred, fix the errors and try again.",
                innerException);
        }
    }
}
