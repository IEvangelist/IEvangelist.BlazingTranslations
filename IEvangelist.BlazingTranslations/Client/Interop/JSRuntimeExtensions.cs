using Microsoft.JSInterop;
using System.Globalization;
using System.Threading.Tasks;

namespace IEvangelist.BlazingTranslations.Client.Interop
{
    static class JSRuntimeExtensions
    {
        internal static ValueTask<string> GetCultureAsync(this IJSRuntime jSRuntime) =>
            jSRuntime.InvokeAsync<string>("blazorCulture.get");

        internal static string GetCulture(this IJSInProcessRuntime jSRuntime) =>
            jSRuntime.Invoke<string>("blazorCulture.get");

        internal static ValueTask SetCultureAsync(this IJSRuntime jSRuntime, CultureInfo culture) =>
            jSRuntime.InvokeVoidAsync("blazorCulture.set", culture.Name);

        internal static void SetCulture(this IJSInProcessRuntime jSRuntime, CultureInfo culture) =>
            jSRuntime.Invoke<string>("blazorCulture.set", culture.Name);
    }
}
