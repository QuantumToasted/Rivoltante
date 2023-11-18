using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public sealed class MemberApiModel : IApiModel
{
    [JsonPropertyName("_id")] 
    public required MemberIdApiModel Id { get; init; }

    public required DateTimeOffset JoinedAt { get; init; }

    public Optional<string> Nickname { get; init; }

    public Optional<AttachmentApiModel> Avatar { get; init; }
    
    public Optional<Ulid[]> Roles { get; init; }

    public Optional<DateTimeOffset> Timeout { get; init; }
}