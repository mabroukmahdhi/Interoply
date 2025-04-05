// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace Interoply.Services.Events
{
    public interface IEventService
    {
        ValueTask OnResizeAsync(Func<int, ValueTask> callback);
        ValueTask OnScrollAsync(Func<double, ValueTask> callback);
        ValueTask OnVisibilityChangeAsync(Func<bool, ValueTask> callback);
        ValueTask OnOnlineStatusChangeAsync(Func<bool, ValueTask> callback);
    }
}
