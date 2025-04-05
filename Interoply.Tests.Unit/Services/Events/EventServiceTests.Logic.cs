// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using Bunit;
using FluentAssertions;
using Interoply.Services.Events;
using Microsoft.JSInterop;

namespace Interoply.Tests.Unit.Services.Events
{
    public partial class EventServiceTests
    {
        [Fact]
        public async Task ShouldInvokeRegisterResizeForOnResizeAsync()
        {
            // given .. when
            await this.eventService.OnResizeAsync(width =>
            {
                return ValueTask.CompletedTask;
            });

            // then
            var invocation = this.JSInterop.VerifyInvoke("registerResize");
            invocation.Arguments.Should().HaveCount(1);

            invocation.Arguments[0].Should()
                .BeOfType<DotNetObjectReference<EventService>>();
        }
    }
}
