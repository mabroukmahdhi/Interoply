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

        [Fact]
        public async Task ShouldInvokeRegisterScrollForOnScrollAsync()
        {
            // given .. when
            await this.eventService.OnScrollAsync(scroll =>
            {
                return ValueTask.CompletedTask;
            });

            // then
            var invocation = this.JSInterop.VerifyInvoke("registerScroll");
            invocation.Arguments.Should().HaveCount(1);

            invocation.Arguments[0].Should()
                .BeOfType<DotNetObjectReference<EventService>>();
        }

        [Fact]
        public async Task ShouldInvokeResizeCallbackWhenTriggeredByInterop()
        {
            // given
            int receivedWidth = 0;
            int inputWidth = 1024;
            int expectedWidth = 1024;

            await this.eventService.OnResizeAsync(width =>
            {
                receivedWidth = width;
                return ValueTask.CompletedTask;
            });

            // when
            var raiseResizeMethod =
                typeof(EventService).GetMethod("RaiseResize")!;

            raiseResizeMethod.Invoke(this.eventService, [inputWidth]);

            // then
            receivedWidth.Should().Be(expectedWidth);
        }

        [Fact]
        public async Task ShouldInvokeScrollCallbackWhenTriggeredByInterop()
        {
            // given
            double receivedScrollY = 0;
            double inputScrollY = 140.5;
            double expectedScrollY = 140.5;

            await this.eventService.OnScrollAsync(scrollY =>
            {
                receivedScrollY = scrollY;
                return ValueTask.CompletedTask;
            });

            // when
            var raiseScrollMethod =
                typeof(EventService).GetMethod("RaiseScroll")!;

            raiseScrollMethod.Invoke(this.eventService, [inputScrollY]);

            // then
            receivedScrollY.Should().Be(expectedScrollY);
        }

    }
}
