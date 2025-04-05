let resizeHandler;
let scrollHandler;
let visibilityHandler;
let onlineHandler;
let offlineHandler;

export function registerResize(dotNetRef) {
    resizeHandler = () => {
        dotNetRef.invokeMethodAsync("RaiseResize", window.innerWidth);
    };
    window.addEventListener("resize", resizeHandler);
    resizeHandler();
}

export function registerScroll(dotNetRef) {
    scrollHandler = () => {
        dotNetRef.invokeMethodAsync("RaiseScroll", window.scrollY);
    };
    window.addEventListener("scroll", scrollHandler);
}

export function registerVisibilityChange(dotNetRef) {
    visibilityHandler = () => {
        const isVisible = !document.hidden;
        dotNetRef.invokeMethodAsync("RaiseVisibilityChange", isVisible);
    };
    document.addEventListener("visibilitychange", visibilityHandler);
}

export function registerOnlineStatus(dotNetRef) {
    onlineHandler = () => dotNetRef.invokeMethodAsync("RaiseOnlineStatusChange", true);
    offlineHandler = () => dotNetRef.invokeMethodAsync("RaiseOnlineStatusChange", false);

    window.addEventListener("online", onlineHandler);
    window.addEventListener("offline", offlineHandler);
}

export function cleanup() {
    if (resizeHandler) window.removeEventListener("resize", resizeHandler);
    if (scrollHandler) window.removeEventListener("scroll", scrollHandler);
    if (visibilityHandler) document.removeEventListener("visibilitychange", visibilityHandler);
    if (onlineHandler) window.removeEventListener("online", onlineHandler);
    if (offlineHandler) window.removeEventListener("offline", offlineHandler);
}
