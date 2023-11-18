using System.Text.Json.Serialization;

namespace Rivoltante.Delta;

public interface IHeaderMetadata
{
    [JsonIgnore]
    IReadOnlyDictionary<string, string> Headers { get; }
}