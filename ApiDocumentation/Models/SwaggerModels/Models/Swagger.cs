using Newtonsoft.Json;

namespace ApiDocumentation.Models.SwaggerModels.Models;

public class Swagger
{
    [JsonProperty("paths")]
    public Dictionary<string, Dictionary<Enums.HttpMethod, Operation>> Paths { get; set; }
}