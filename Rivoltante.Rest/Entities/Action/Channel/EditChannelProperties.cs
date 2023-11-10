using Rivoltante.Core;

namespace Rivoltante.Rest;

public class EditChannelProperties
{
    internal EditChannelProperties()
    { }

    public Optional<string> Name { internal get; set; }
    
    public Optional<string> Description { internal get; set; }
    
    public Optional<string> Icon { internal get; set; }
    
    public Optional<bool> IsNsfw { internal get; set; }
    
    public Optional<bool> IsArchived { internal get; set; }
    
    public Optional<IEnumerable<RemoveChannelField>> RemovedChannelFields { internal get; set; }
}