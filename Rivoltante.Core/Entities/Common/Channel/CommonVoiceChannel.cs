namespace Rivoltante.Core;

public sealed class CommonVoiceChannel(ChannelApiModel model, IRevoltClient client) : CommonServerChannel(model, client), IVoiceChannel
{
    public override ChannelType Type => ChannelType.VoiceChannel;
}