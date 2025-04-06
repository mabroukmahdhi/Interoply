// --------------------------------------------------------
// Copyright (c) Mabrouk Mahdhi 2025. All rights reserved.
// --------------------------------------------------------

using Interoply.Services.Bases;
using Microsoft.JSInterop;

namespace Interoply.Tests.Manual.Services.Prints
{
    public class PrintService : InteroplyServiceBase, IPrintService
    {
        protected override string JsModulePath => "./print.js";

        public PrintService(IJSRuntime jsRuntime)
            : base(jsRuntime)
        { }

        public async ValueTask PrintAsync()
        {
            await InvokeVoidAsync("invokePrint");
        }
    }
}
