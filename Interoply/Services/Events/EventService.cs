// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using System;
using System.Threading.Tasks;
using Interoply.Models.Events;
using Microsoft.JSInterop;

namespace Interoply.Services.Events
{
    internal partial class EventService : IEventService, IAsyncDisposable
    {
        private readonly DotNetObjectReference<EventService> dotNetRef;
        private readonly InteroplyEvent interoplyEvent;
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public EventService(IJSRuntime jsRuntime)
        {
            this.interoplyEvent = new InteroplyEvent();

            this.moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Interoply/interoplyEvents.js").AsTask());

            this.dotNetRef = DotNetObjectReference.Create(this);
        }

        public ValueTask OnResizeAsync(Func<int, ValueTask> callback) =>
        TryCatch(async () =>
        {
            ValidateInteroplyCallback(callback);
            var module = await moduleTask.Value;
            this.interoplyEvent.OnResizeCallback = callback;
            await module.InvokeVoidAsync("registerResize", dotNetRef);
        });

        public ValueTask OnScrollAsync(Func<double, ValueTask> callback) =>
        TryCatch(async () =>
        {
            ValidateInteroplyCallback(callback);
            var module = await moduleTask.Value;
            this.interoplyEvent.OnScrollCallback = callback;
            await module.InvokeVoidAsync("registerScroll", dotNetRef);
        });

        public ValueTask OnVisibilityChangeAsync(Func<bool, ValueTask> callback) =>
        TryCatch(async () =>
        {
            ValidateInteroplyCallback(callback);
            var module = await moduleTask.Value;
            this.interoplyEvent.OnVisibilityChangeCallback = callback;
            await module.InvokeVoidAsync("visibilitychange", dotNetRef);
        });

        public ValueTask OnOnlineStatusChangeAsync(Func<bool, ValueTask> callback) =>
        TryCatch(async () =>
        {
            ValidateInteroplyCallback(callback);
            var module = await moduleTask.Value;
            this.interoplyEvent.OnOnlineStatusChangeCallback = callback;
            await module.InvokeVoidAsync("registerOnlineStatus", dotNetRef);
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


        public async ValueTask DisposeAsync()
        {
            if (this.moduleTask.IsValueCreated)
            {
                try
                {
                    var module = await moduleTask.Value;

                    if (module != null)
                        await module.InvokeVoidAsync("cleanup");
                }
                catch (JSException)
                {
                    // JS not ready
                }
            }

            dotNetRef?.Dispose();
        }
    }
}
