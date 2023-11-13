using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record NodeQueryApiModel(
    [property: JsonPropertyName("revolt")] string Revolt,
    [property: JsonPropertyName("features")] RevoltFeatureListApiModel Features,
    [property: JsonPropertyName("ws")] string Ws,
    [property: JsonPropertyName("app")] string App,
    [property: JsonPropertyName("vapid")] string Vapid,
    [property: JsonPropertyName("build")] RevoltBuildInformationApiModel Build) : ApiModel;