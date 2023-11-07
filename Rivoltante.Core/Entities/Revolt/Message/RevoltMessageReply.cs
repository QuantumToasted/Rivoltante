namespace Rivoltante.Core;

public sealed class RevoltMessageReply
{
    public Ulid MessageId { get; set; }
    
    public bool MentionAuthor { get; set; }
}