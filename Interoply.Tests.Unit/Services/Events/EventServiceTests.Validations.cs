// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using FluentAssertions;
using Interoply.Models.Events.Exceptions;

namespace Interoply.Tests.Unit.Services.Events
{
    public partial class EventServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnResizeIfCallbackEventIsNullAsync()
        {
            // given
            Func<int, ValueTask> nullCallback = null;

            var nullInteroplyEventException = new NullInteroplyEventException(
                message: "Interoply Callback event cannot be null");

            var expectedInteroplyEventValidationException
                = new InteroplyEventValidationException(
                    message: "Interoply Callback event validation error occurred, fix the errors and try again.",
                    innerException: nullInteroplyEventException);

            // when
            ValueTask onResizeTask = this.eventService.OnResizeAsync(nullCallback);

            InteroplyEventValidationException actualParentProductValidationException =
                await Assert.ThrowsAsync<InteroplyEventValidationException>(
                    onResizeTask.AsTask);

            // then
            actualParentProductValidationException.Should().BeEquivalentTo(
                expectedInteroplyEventValidationException);
        }
    }
}
