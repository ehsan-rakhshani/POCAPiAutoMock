using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ApiDocumentation.Models.SwaggerModels.Models;

[JsonConverter(typeof(StringEnumConverter))]
public enum Scheme
{
    [EnumMember(Value = "http")]
    Http,

    [EnumMember(Value = "https")]
    Https,

    [EnumMember(Value = "ws")]
    Ws,

    [EnumMember(Value = "wss")]
    Wss
}