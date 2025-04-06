// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using System;
using System.Threading.Tasks;
using Interoply.Models.Events;
using Interoply.Services.Bases;
using Microsoft.JSInterop;

namespace Interoply.Services.Events
{
    internal partial class EventService : InteroplyServiceBase, IEventService
    {
        private readonly InteroplyEvent interoplyEvent;
        private readonly DotNetObjectReference<InteroplyServiceBase> dotNetRef;

        protected override string JsModulePath =>
            "./_content/Interoply/interoplyEvents.js";

        public EventService(IJSRuntime jsRuntime)
            : base(jsRuntime)
        {
            this.interoplyEvent = new InteroplyEvent();
        }

        public ValueTask OnResizeAsync(Func<int, ValueTask> callback) =>
        TryCatch(async () =>
        {
            ValidateInteroplyCallback(callback);
            this.interoplyEvent.OnResizeCallback = callback;
            await InvokeVoidAsync("registerResize", dotNetRef);
        });

        public ValueTask OnScrollAsync(Func<double, ValueTask> callback) =>
        TryCatch(async () =>
        {
            ValidateInteroplyCallback(callback);
            this.interoplyEvent.OnScrollCallback = callback;
            await InvokeVoidAsync("registerScroll", dotNetRef);
        });

        public ValueTask OnVisibilityChangeAsync(Func<bool, ValueTask> callback) =>
        TryCatch(async () =>
        {
            ValidateInteroplyCallback(callback);
            this.interoplyEvent.OnVisibilityChangeCallback = callback;
            await InvokeVoidAsync("visibilitychange", dotNetRef);
        });

        public ValueTask OnOnlineStatusChangeAsync(Func<bool, ValueTask> callback) =>
        TryCatch(async () =>
        {
            ValidateInteroplyCallback(callback);
            this.interoplyEvent.OnOnlineStatusChangeCallback = callback;
            await InvokeVoidAsync("registerOnlineStatus", dotNetRef);
        });

        [JSInvokable]
        public async Task RaiseResize(int width)
        {
            if (this.interoplyEvent.OnResizeCallback != null)
                await this.interoplyEvent.OnResizeCallback(width);
        }

        [JSInvokable]
        public async Task RaiseScroll(double scrollY)
        {
            if (this.interoplyEvent.OnScrollCallback != null)
                await this.interoplyEvent.OnScrollCallback(scrollY);
        }

        [JSInvokable]
        public async Task RaiseVisibilityChange(bool isVisible)
        {
            if (this.interoplyEvent.OnVisibilityChangeCallback != null)
                await this.interoplyEvent.OnVisibilityChangeCallback(isVisible);
        }

        [JSInvokable]
        public async Task RaiseOnlineStatusChange(bool isOnline)
        {
            if (this.interoplyEvent.OnOnlineStatusChangeCallback != null)
                await this.interoplyEvent.OnOnlineStatusChangeCallback(isOnline);
        }


        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();

            dotNetRef?.Dispose();
        }
    }
}
