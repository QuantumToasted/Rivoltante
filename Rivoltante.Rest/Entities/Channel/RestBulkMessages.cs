using Rivoltante.Core;

namespace Rivoltante.Rest;

public class RestBulkMessages(BulkMessagesApiModel model, IRevoltRestClient client) : IBulkMessages
{
    public IRevoltClient Client { get; } = client;

    public IReadOnlyDictionary<Ulid, IMessage> Messages { get; } = model.Messages.ToDictionary(x => x.Id, x => (IMessage) new CommonMessage(client, x));

    public IReadOnlyDictionary<Ulid, IUser> Users { get; } = model.Users.ToDictionary(x => x.Id, x =>
    {
        if (model.Members is { HasValue: true, Value: var members })
        {
            foreach (var member in members)
            {
                if (member.Id.User == x.Id)
                    return (IUser)new CommonMember(x, member, client);
            }
        }

        return new CommonUser(x, client);
    });
}