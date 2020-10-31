using IEvangelist.BlazingTranslations.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IEvangelist.BlazingTranslations.Client.Shared
{
    public partial class CultureSelector
    {
        [Inject] IJSRuntime JavaScript { get; set; }
        [Inject] NavigationManager Navigation { get; set; }
        [Inject] HttpClient Http { get; set; }

        IEnumerable<CultureInfo> _supportedCultures;
        CultureInfo _selectedCulture;

        CultureInfo Culture
        {
            get => CultureInfo.CurrentCulture;
            set
            {
                if (CultureInfo.CurrentCulture != value)
                {
                    var js = (IJSInProcessRuntime)JavaScript;
                    js.InvokeVoid("blazorCulture.set", value.Name);

                    Navigation.NavigateTo(Navigation.Uri, forceLoad: true);
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            _selectedCulture = Culture;

            var azureCultures =
                await Http.GetFromJsonAsync<AzureCultures>(
                    "api/cultures",
                    DefaultOptions.SerializerOptions);

            var supportedCultures =
                CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            _supportedCultures = supportedCultures.Where(
                culture => azureCultures.Translation.ContainsKey(culture.TwoLetterISOLanguageName));
        }
    }
}