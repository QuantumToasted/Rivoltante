using System.Text.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class RevoltBuildInformationApiModel : IApiModel
{
    public required string CommitSha { get; init; }

    public required string CommitTimestamp { get; init; }

    [JsonPropertyName("semver")] 
    public required string SemVer { get; init; }

    public required string OriginUrl { get; init; }

    public required string Timestamp { get; init; }
}