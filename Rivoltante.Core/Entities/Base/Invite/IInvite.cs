namespace Rivoltante.Core;

public interface IInvite : IClientEntity, IChannelEntity
{
    InviteType Type { get; }
    
    string InviteCode { get; }
    
    Ulid CreatorId { get; }
}