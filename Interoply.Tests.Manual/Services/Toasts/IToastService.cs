// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

namespace Interoply.Tests.Manual.Services.Toasts
{
    public interface IToastService
    {
        ValueTask ShowToastAsync(string message);
    }
}
