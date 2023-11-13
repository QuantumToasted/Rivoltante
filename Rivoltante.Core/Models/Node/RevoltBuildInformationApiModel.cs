using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record RevoltBuildInformationApiModel(
    [property: JsonPropertyName("commit_sha")] string CommitSha,
    [property: JsonPropertyName("commit_hash")] string CommitHash,
    [property: JsonPropertyName("semver")] string SemVer,
    [property: JsonPropertyName("origin_url")] string OriginUrl,
    [property: JsonPropertyName("timestamp")] string Timestamp) : ApiModel;