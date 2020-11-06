using Microsoft.JSInterop;
using System.Globalization;
using System.Threading.Tasks;

namespace IEvangelist.BlazingTranslations.Client.Interop
{
    public static class JSRuntimeExtensions
    {
        public static ValueTask<string> GetCultureAsync(this IJSRuntime jSRuntime) =>
            jSRuntime.InvokeAsync<string>("blazorCulture.get");

        public static string GetCulture(this IJSInProcessRuntime jSRuntime) =>
            jSRuntime.Invoke<string>("blazorCulture.get");

        public static ValueTask SetCultureAsync(this IJSRuntime jSRuntime, CultureInfo culture) =>
            jSRuntime.InvokeVoidAsync("blazorCulture.set", culture.Name);

        public static void SetCulture(this IJSInProcessRuntime jSRuntime, CultureInfo culture) =>
            jSRuntime.Invoke<string>("blazorCulture.set", culture.Name);
    }
}
