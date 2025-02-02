using ApiDocumentation.Models.SwaggerModels.Enums;
using Newtonsoft.Json;

namespace ApiDocumentation.Models.SwaggerModels.Models;

public class Property
{
    [JsonProperty("type")]
    public DataType Type { get; set; }

    [JsonProperty("format")]
    public string Format { get; set; }
}

