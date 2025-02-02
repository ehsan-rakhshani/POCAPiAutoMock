using Newtonsoft.Json;

namespace ApiDocumentation.Models.SwaggerModels.Models;

public class Definition
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("properties")]
    public Dictionary<string, Property> Properties { get; set; }

    [JsonProperty("required")]
    public List<string> Required { get; set; }
}

