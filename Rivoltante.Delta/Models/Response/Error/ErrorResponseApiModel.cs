using Rivoltante.Core;

namespace Rivoltante.Delta;

public sealed class ErrorResponseApiModel : IApiModel
{
    public required string Type { get; init; }
    
    public Optional<string> Permission { get; init; }
    
    public Optional<string> Operation { get; init; }
    
    public Optional<string> With { get; init; }
    
    public Optional<string> Location { get; init; }
    
    public Optional<uint> Max { get; init; }

    public ErrorResponseType? GetErrorType() 
        => Enum.TryParse(Type, out ErrorResponseType type) ? type : null;

    public UserPermission? GetMissingUserPermission()
        => Enum.TryParse(Permission.GetValueOrDefault(), out UserPermission permission) ? permission : null;

    public Permission? GetMissingPermission()
        => Enum.TryParse(Permission.GetValueOrDefault(), out Permission permission) ? permission : null;
}