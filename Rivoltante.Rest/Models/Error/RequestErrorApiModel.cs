using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public record RequestErrorApiModel(
    [property: JsonPropertyName("type")] string Type) : ApiModel
{
    public virtual string GetErrorString() => $"API Error: {Type}";
}