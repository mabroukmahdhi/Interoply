// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using Bunit;
using Interoply.Extensions;
using Interoply.Services.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Interoply.Tests.Unit.Services.Events
{
    public partial class EventServiceTests : TestContext
    {
        private readonly IEventService eventService;

        public EventServiceTests()
        {
            this.JSInterop.Mode = JSRuntimeMode.Loose;
            this.Services.AddInteroply();

            this.eventService =
                this.Services.GetRequiredService<IEventService>();
        }
    }
}
