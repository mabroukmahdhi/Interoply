// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace Interoply
{
    public interface IInteroplyService
    {
        ValueTask RegisterOnResizeListnerAsync(Func<int, ValueTask> callback);
        ValueTask RegisterOnScrollListnerAsync(Func<double, ValueTask> callback);
        ValueTask RegisterOnVisibilityChangeListnerAsync(Func<bool, ValueTask> callback);
        ValueTask RegisterOnOnlineStatusChangeListnerAsync(Func<bool, ValueTask> callback);
    }
}
