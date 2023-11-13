using System.Text.Json.Serialization;

namespace Rivoltante.Core;

public record RevoltFeatureListApiModel(
    [property: JsonPropertyName("captcha")] RevoltFeatureApiModel Captcha,
    [property: JsonPropertyName("email")] bool Email,
    [property: JsonPropertyName("invite_only")] bool InviteOnly,
    [property: JsonPropertyName("autumn")] RevoltFeatureApiModel Autumn,
    [property: JsonPropertyName("january")] RevoltFeatureApiModel January,
    [property: JsonPropertyName("voso")]  RevoltFeatureApiModel Voso) : ApiModel;