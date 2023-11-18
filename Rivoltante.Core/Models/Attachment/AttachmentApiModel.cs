using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public sealed class AttachmentApiModel : IApiModel
{
    [JsonPropertyName("_id")] 
    public required string Id { get; init; }
    
    public required string Tag { get; init; }

    public required string Filename { get; init; }

    public required AttachmentMetadataApiModel Metadata { get; init; }

    public required string ContentType { get; init; }

    public required long Size { get; init; }

    public Optional<bool> Deleted { get; init; }

    public Optional<bool> Reported { get; init; }

    public Optional<Ulid> MessageId { get; init; }

    public Optional<Ulid> UserId { get; init; }

    public Optional<Ulid> ServerId { get; init; }

    public Optional<string> ObjectId { get; init; }
}