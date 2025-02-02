using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ApiDocumentation.Models.SwaggerModels.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum HttpMethod
{
    [EnumMember(Value = "get")]
    GET,

    [EnumMember(Value = "post")]
    POST,

    [EnumMember(Value = "put")]
    PUT,

    [EnumMember(Value = "delete")]
    DELETE,

    [EnumMember(Value = "patch")]
    PATCH,

    [EnumMember(Value = "options")]
    OPTIONS,

    [EnumMember(Value = "head")]
    HEAD
}