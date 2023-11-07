using System.Net.Http.Json;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Rivoltante.Core;

public abstract record ApiModel
{
    public virtual void Validate()
    { }
}