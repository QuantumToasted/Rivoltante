using Newtonsoft.Json;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record RequestErrorApiModel(
    [property: JsonProperty("type")] string Type) : ApiModel
{
    public virtual string GetErrorString() => $"API Error: {Type}";
}