// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------


using Interoply.Services.Bases;
using Microsoft.JSInterop;

namespace Interoply.Tests.Manual.Services.Toasts
{
    public class ToastService : InteroplyServiceBase, IToastService
    {
        protected override string JsModulePath => "./toast.js";

        public ToastService(IJSRuntime jsRuntime)
            : base(jsRuntime)
        { }

        public async ValueTask ShowToastAsync(string message)
        {
            await InvokeVoidAsync("showAlert", message);
        }
    }
}
