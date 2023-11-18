namespace Rivoltante.Core;

public sealed record RevoltMessageReply(
    Ulid MessageId,
    bool MentionAuthor);