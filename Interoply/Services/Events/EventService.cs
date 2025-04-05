// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using System;
using System.Threading.Tasks;
using Interoply.Models.Events;
using Microsoft.JSInterop;

namespace Interoply.Services.Events
{
    internal class EventService : IEventService, IAsyncDisposable
    {
        private DotNetObjectReference<EventService> dotNetRef;
        private readonly InteroplyEvent interoplyEvent;
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public EventService(IJSRuntime jsRuntime)
        {
            this.interoplyEvent = new InteroplyEvent();

            this.moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Interoply/interoplyEvents.js").AsTask());
        }

        public async ValueTask OnResizeAsync(Func<int, ValueTask> callback)
        {
            var module = await moduleTask.Value;
            this.interoplyEvent.OnResizeCallback = callback;
            this.dotNetRef ??= DotNetObjectReference.Create(this);
            await module.InvokeVoidAsync("registerResize", dotNetRef);
        }

        public async ValueTask OnScrollAsync(Func<double, ValueTask> callback)
        {
            var module = await moduleTask.Value;
            this.interoplyEvent.OnScrollCallback = callback;
            this.dotNetRef ??= DotNetObjectReference.Create(this);
            await module.InvokeVoidAsync("registerScroll", dotNetRef);
        }

        [JSInvokable]
        public async Task RaiseResize(int width)
        {
            if (this.interoplyEvent.OnResizeCallback != null)
                await this.interoplyEvent.OnResizeCallback(width);
        }

        [JSInvokable]
        public async Task RaiseScroll(double scrollY)
        {
            if (this.interoplyEvent.OnResizeCallback != null)
                await this.interoplyEvent.OnScrollCallback(scrollY);
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
