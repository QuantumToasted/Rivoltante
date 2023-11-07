namespace Rivoltante.Rest;

public interface IHeaderMetadata
{
    public IReadOnlyDictionary<string, string> Headers { get; }
}