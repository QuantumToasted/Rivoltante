namespace Rivoltante.Core;

public interface IUlidEntity : IRevoltEntity
{
    Ulid Id { get; }

    DateTimeOffset CreatedAt => Id.CreatedAt;
}