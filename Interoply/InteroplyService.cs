// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using System;
using System.Threading.Tasks;
using Interoply.Services.Events;

namespace Interoply
{
    internal class InteroplyService : IInteroplyService
    {
        private readonly IEventService eventService;

        public InteroplyService(IEventService eventService) =>
            this.eventService = eventService;

        public async ValueTask RegisterOnResizeListnerAsync(Func<int, ValueTask> callback) =>
            await this.eventService.OnResizeAsync(callback);

        public async ValueTask RegisterOnOnlineStatusChangeListnerAsync(Func<bool, ValueTask> callback) =>
            await this.eventService.OnOnlineStatusChangeAsync(callback);

        public async ValueTask RegisterOnScrollListnerAsync(Func<double, ValueTask> callback) =>
            await this.eventService.OnScrollAsync(callback);

        public async ValueTask RegisterOnVisibilityChangeListnerAsync(Func<bool, ValueTask> callback) =>
            await this.eventService.OnVisibilityChangeAsync(callback);
    }
}
