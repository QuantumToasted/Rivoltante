namespace Rivoltante.Core;

public interface IInvite : IRevoltEntity, IChannelEntity
{
    InviteType Type { get; }
    
    string InviteCode { get; }
    
    Ulid CreatorId { get; }
}