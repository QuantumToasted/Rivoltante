﻿using Rivoltante.Core;

namespace Rivoltante.Rest;

public interface IBulkMessages : IClientEntity
{
    IReadOnlyDictionary<Ulid, IMessage> Messages { get; }
    
    IReadOnlyDictionary<Ulid, IUser> Users { get; }
}