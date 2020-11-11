using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace IEvangelist.BlazingTranslations.Client.Pages
{
    public partial class Index
    {
        [Inject]
        public IStringLocalizer<Index> Localizer { get; set; }

        public string SurveyTitle => Localizer[nameof(SurveyTitle)];
        public string Greeting => Localizer[nameof(Greeting)];
        public string HelloWorld => Localizer[nameof(HelloWorld)];
    }
}
