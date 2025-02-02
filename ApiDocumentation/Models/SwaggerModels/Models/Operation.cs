using System.Text.Json.Serialization;

namespace ApiDocumentation.Models.SwaggerModels.Models;

public class Operation
{
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    [JsonPropertyName("parameters")]
    public List<Parameter> Parameters { get; set; }

    [JsonPropertyName("requestBody")]
    public RequestBody RequestBody { get; set; }

    [JsonPropertyName("responses")]
    public Dictionary<string, SwaggerResponse> Responses { get; set; }
}

public class SchemaRef
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("format")]
    public string Format { get; set; }
}

public class RequestBody
{
    [JsonPropertyName("content")]
    public Dictionary<string, MediaType> Content { get; set; }
}
public class MediaType
{
    [JsonPropertyName("schema")]
    public MediaSchema Schema { get; set; }
}
public class MediaSchema
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("items")]
    public MediaSchema Items { get; set; }

    [JsonPropertyName("$ref")]
    public string Ref { get; set; }
}

public class Components
{
    [JsonPropertyName("schemas")]
    public Dictionary<string, Schema> Schemas { get; set; }
}

public class Schema
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("properties")]
    public Dictionary<string, SchemaProperty> Properties { get; set; }

    [JsonPropertyName("additionalProperties")]
    public bool AdditionalProperties { get; set; }
}

public class SchemaProperty
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("format")]
    public string Format { get; set; }

    [JsonPropertyName("nullable")]
    public bool? Nullable { get; set; }
}
public class SwaggerResponse
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("content")]
    public Dictionary<string, MediaType> Content { get; set; }
}