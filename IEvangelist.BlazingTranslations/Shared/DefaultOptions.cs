using System.Text.Json;
using System.Text.Json.Serialization;

namespace IEvangelist.BlazingTranslations.Shared
{
    public class DefaultOptions
    {
        public static JsonSerializerOptions SerializerOptions { get; set; } =
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters =
                {
                    new JsonStringEnumConverter()
                }
            };
    }
}
