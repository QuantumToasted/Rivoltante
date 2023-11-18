namespace Rivoltante.Core;

public interface IUserProfile
{
    string? Content { get; }
    
    IAttachment? Background { get; }
}