using Rivoltante.Core;

namespace Rivoltante.Rest;

public class EditGroupChannelProperties : EditChannelProperties
{
    internal EditGroupChannelProperties()
    { }
    
    public Optional<Ulid> OwnerId { internal get; set; }
}