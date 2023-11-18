namespace Rivoltante.Core;

public sealed class CommonUnknownChannel(ChannelApiModel model, IRevoltClient client) : CommonChannel(model, client)
{
    public string RawChannelType { get; } = model.ChannelType;
    
    public override ChannelType Type => throw new InvalidOperationException("Unknown channel type.");
}