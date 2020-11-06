using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace IEvangelist.BlazingTranslations.Client.Pages
{
    public partial class Index
    {
        [Inject]
        public IStringLocalizer<Index> Localizer { get; set; }

        public string SurveyTitle
        {
            get
            {
                var surveyTitle = Localizer[nameof(SurveyTitle)];
                return surveyTitle;
            }
        }

        public string Greeting
        {
            get
            {
                var greeting = Localizer[nameof(Greeting)];
                return greeting;
            }
        }

        public string HelloWorld
        {
            get
            {
                var helloWorld = Localizer[nameof(HelloWorld)];
                return helloWorld;
            }
        }
    }
}
