using System.Text.Json.Serialization;

namespace Rivoltante.Core;

// TODO: This model is an abomination, because Revolt's permission models are an abomination.
// https://github.com/revoltchat/api/issues/29
public sealed class PermissionsApiModel
{
    [JsonPropertyName("a")] // must set explicit JsonPropertyName on private properties/fields
    private Permission A
    {
        get => Allow;
        set => Allow = value;
    }

    [JsonPropertyName("d")] // must set explicit JsonPropertyName on private properties/fields
    private Permission D
    {
        get => Deny;
        set => Deny = value;
    }
    
    // "allow"
    public Permission Allow { get; private set; }
    
    // "deny"
    public Permission Deny { get; private set; }
}