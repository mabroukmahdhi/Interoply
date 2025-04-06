// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Interoply.Services.Bases
{
    public abstract class InteroplyServiceBase : IAsyncDisposable
    {
        protected readonly Lazy<Task<IJSObjectReference>> moduleTask;
        protected abstract string JsModulePath { get; }

        public InteroplyServiceBase(IJSRuntime jsRuntime)
        {
            this.moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", JsModulePath).AsTask());
        }

        public virtual async ValueTask InvokeVoidAsync(string identifier, params object[] args) =>
           await InvokeVoidAsync(identifier, CancellationToken.None, args);

        public virtual async ValueTask<TValue> InvokeAsync<TValue>(string identifier, params object[] args) =>
           await InvokeAsync<TValue>(identifier, CancellationToken.None, args);

        public virtual async ValueTask<TValue> InvokeAsync<TValue>(
            string identifier,
            CancellationToken cancellationToken,
            params object[] args)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<TValue>(identifier, cancellationToken, args);
        }

        public virtual async ValueTask InvokeVoidAsync(
            string identifier,
            CancellationToken cancellationToken,
            params object[] args)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(identifier, cancellationToken, args);
        }

        public virtual async ValueTask<TValue> InvokeAsync<TValue>(
            string identifier,
            TimeSpan timeout,
            params object[] args)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<TValue>(identifier, timeout, args);
        }

        public virtual async ValueTask InvokeVoidAsync(
            string identifier,
            TimeSpan timeout,
            params object[] args)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync(identifier, timeout, args);
        }

        public virtual async ValueTask DisposeAsync()
        { }
    }
}
