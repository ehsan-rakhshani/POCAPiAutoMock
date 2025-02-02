using Newtonsoft.Json;

namespace ApiDocumentation.Models.SwaggerModels.Models;

public class Schema
{
    // این فیلد معمولاً به $ref اشاره دارد
    [JsonProperty("$ref")]
    public string Ref { get; set; }

    // در صورت نیاز، می‌توانید این فیلد را نیز به enum مانند DataType تبدیل کنید
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("items")]
    public Schema Items { get; set; }
}