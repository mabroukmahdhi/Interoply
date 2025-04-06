// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Interoply.Services.Bases
{
    internal interface IInteroplyServiceBase
    {
        ValueTask InvokeVoidAsync(string identifier, params object[] args);
        ValueTask<TValue> InvokeAsync<TValue>(string identifier, params object[] args);

        ValueTask<TValue> InvokeAsync<TValue>(
            string identifier,
            CancellationToken cancellationToken,
            params object[] args);

        ValueTask InvokeVoidAsync(
            string identifier,
            CancellationToken cancellationToken,
            params object[] args);

        ValueTask<TValue> InvokeAsync<TValue>(string identifier, TimeSpan timeout, params object[] args);

        ValueTask InvokeVoidAsync(string identifier, TimeSpan timeout, params object[] args);
    }
}
