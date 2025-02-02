using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ApiDocumentation.Models.SwaggerModels.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum ParameterLocation
{
    [EnumMember(Value = "query")]
    Query,

    [EnumMember(Value = "header")]
    Header,

    [EnumMember(Value = "path")]
    Path,

    [EnumMember(Value = "formData")]
    FormData,

    [EnumMember(Value = "body")]
    Body
}