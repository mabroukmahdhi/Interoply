// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace Interoply.Models.Events
{
    internal class InteroplyEvent
    {
        public Func<int, ValueTask> OnResizeCallback { get; internal set; }
        public Func<double, ValueTask> OnScrollCallback { get; internal set; }
        public Func<bool, ValueTask> OnVisibilityChangeCallback { get; internal set; }
        public Func<bool, ValueTask> OnOnlineStatusChangeCallback { get; internal set; }
        public Func<bool, ValueTask> OnBeforeUnloadCallback { get; internal set; }
    }
}
