using Rivoltante.Core;

namespace Rivoltante.Bonfire;

public interface IBonfireClientEntity : IClientEntity
{
    new IBonfireClient Client { get; }
    IRevoltClient IClientEntity.Client => Client;
}