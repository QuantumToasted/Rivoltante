namespace Rivoltante.Core;

public sealed class CommonTextChannel(ChannelApiModel model, IRevoltClient client) : CommonServerChannel(model, client), ITextChannel
{
    public Ulid? LastMessageId => model.LastMessageId.GetValueOrNullable();
    
    public override ChannelType Type => ChannelType.TextChannel;
}