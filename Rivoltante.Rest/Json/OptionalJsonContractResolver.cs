using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Rivoltante.Core;

namespace Rivoltante.Rest;

public class OptionalJsonContractResolver : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);

        if (property.PropertyType!.IsGenericType && typeof(IOptional).IsAssignableFrom(property.PropertyType))
        {
            property.ShouldSerialize = x => ((IOptional)property.ValueProvider!.GetValue(x)!).HasValue;
        }

        return property;
    }
}