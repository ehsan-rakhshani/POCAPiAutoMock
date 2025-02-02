using ApiDocumentation.Models.SwaggerModels.Enums;
using Newtonsoft.Json;

namespace ApiDocumentation.Models.SwaggerModels.Models;

public class Parameter
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("in")]
    public ParameterLocation In { get; set; }

    [JsonProperty("required")]
    public bool Required { get; set; }
}