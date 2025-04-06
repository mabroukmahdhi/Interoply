# Interoply

**Interoply** is a lightweight, extensible library that makes JavaScript interop in Blazor **simple, intuitive, and plug-and-play**.  
It handles browser events like resize, scroll, visibility, and even custom DOM events — so you don't have to write any JavaScript.

[![Nuget](https://img.shields.io/nuget/v/Interoply)](https://www.nuget.org/packages/Interoply/)
[![Nuget](https://img.shields.io/nuget/dt/Interoply)](https://www.nuget.org/packages/Interoply/)
![.NET 7](https://img.shields.io/badge/.NET_7-COMPATIBLE-2ea44f)
![.NET 8](https://img.shields.io/badge/.NET_8-COMPATIBLE-2ea44f)
![.NET 9](https://img.shields.io/badge/.NET_9-COMPATIBLE-2ea44f)
---

## ✨ Features

- ✅ Listen to native browser events (`resize`, `scroll`, `visibilitychange`, etc.)
- 🔄 Register to custom DOM events on any element (Soming soon)
- ✅ Extend functionality with C#-only base services (zero JS knowledge required)
- ✅ Automatic cleanup & no JS interop errors during prerender
- ✅ Supports Blazor Server and WebAssembly

---

## 📦 Installation

```bash
dotnet add package Interoply
```

---

## 🛠️ Getting Started

### 1. Register Interoply

```csharp
builder.Services.AddInteroply();
```

---

### 2. Use in your component

```razor
@inject IInteroplyService Interoply

<p>Window width: @width px</p>

@code {
    private int width;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await Interoply.RegisterOnResizeListnerAsync(UpdateWidth);
        }
    }

    ValueTask UpdateWidth(int w)
    {
        width = w;
        StateHasChanged();
        return ValueTask.CompletedTask;
    }
}
```

---

## 🔌 Write your own service

Interoply provides a base service `InteroplyServiceBase` — you can write your own services **entirely in C#**:

```csharp
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
```

**Note:**
_You need to add the JavaScript file `toast.js` to your project under `wwwroot` folder with the following content:_
```javascript
export function showAlert(message) {
  return alert(message);
}
```

And register it like this:

```csharp
builder.Services.AddInteroply();
builder.Services.AddScoped<IToastService, ToastService>();
```

---

## ⚙️ Supported Events

| Event                  | Method                                 |
|------------------------|----------------------------------------|
| Window Resize          | `OnResizeAsync(Func<int, ValueTask>)`  |
| Scroll                 | `OnScrollAsync(Func<double, ValueTask>)` |
| Visibility Change      | `OnVisibilityChangeAsync(Func<bool, ValueTask>)` |
| Online/Offline Status  | `OnOnlineStatusChangeAsync(Func<bool, ValueTask>)` |
| Custom DOM Events (Coming soon)     | `OnDomEventAsync(elementId, eventName, callback)` |

---

## 💡 Why Interoply?

Blazor is powerful — but JavaScript interop can be painful. Interoply takes care of:

- 🔄 Bridging between JS and C# automatically
- 🧹 Cleanup to prevent memory leaks
- 🔧 Extensibility via base services
- 😌 Simplifying your codebase

---

## 📝 License

[License](https://github.com/mabroukmahdhi/Interoply/blob/main/LICENSE) © 2025 Mabrouk Mahdhi