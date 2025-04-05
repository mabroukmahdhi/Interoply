export function registerResize(dotNetRef) {
    const onResize = () => {
        dotNetRef.invokeMethodAsync("RaiseResize", window.innerWidth);
    };
    window.addEventListener("resize", onResize);
    onResize();
}

export function registerScroll(dotNetRef) {
    const onScroll = () => {
        dotNetRef.invokeMethodAsync("RaiseScroll", window.scrollY);
    };
    window.addEventListener("scroll", onScroll);
}

export function cleanup() {
    window.removeEventListener("resize", onResize);
    window.removeEventListener("scroll", onScroll);
}
