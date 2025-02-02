using Newtonsoft.Json;

namespace ApiDocumentation.Models.SwaggerModels.Models;

public class SwaggerResponse
{
    [JsonProperty("description")]
    public string Description { get; set; }
}