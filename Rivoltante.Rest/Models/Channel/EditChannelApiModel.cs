using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public sealed record EditChannelApiModel(
    [property: JsonPropertyName("name")] Optional<string> Name,
    [property: JsonPropertyName("description")] Optional<string> Description,
    [property: JsonPropertyName("owner")] Optional<Ulid> Owner,
    [property: JsonPropertyName("icon")] Optional<string> Icon,
    [property: JsonPropertyName("nsfw")] Optional<bool> Nsfw,
    [property: JsonPropertyName("archived")] Optional<bool> Archived,
    [property: JsonPropertyName("remove")] Optional<RemovedChannelField[]> Remove) : ApiModel;