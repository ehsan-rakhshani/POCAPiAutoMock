using Newtonsoft.Json;

namespace ApiDocumentation.Models.SwaggerModels.Models;

public class Info
{
    [JsonProperty("version")]
    public string Version { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }
}

