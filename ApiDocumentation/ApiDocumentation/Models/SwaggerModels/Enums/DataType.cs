using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ApiDocumentation.Models.SwaggerModels.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum DataType
{
    [EnumMember(Value = "string")]
    String,

    [EnumMember(Value = "number")]
    Number,

    [EnumMember(Value = "integer")]
    Integer,

    [EnumMember(Value = "boolean")]
    Boolean,

    [EnumMember(Value = "object")]
    Object,

    [EnumMember(Value = "array")]
    Array
}