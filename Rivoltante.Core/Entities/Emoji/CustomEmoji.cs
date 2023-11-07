using System.Diagnostics.CodeAnalysis;

namespace Rivoltante.Core.Emoji;

public class CustomEmoji : ICustomEmoji
{
    public CustomEmoji(Ulid id)
    {
        Id = id;
    }

    public Ulid Id { get; }

    public static bool TryParse(string input, [NotNullWhen(true)] out CustomEmoji? emoji)
    {
        if (Ulid.TryParse(input, out var id))
        {
            emoji = new CustomEmoji(id);
            return true;
        }

        emoji = null;
        return false;
    }
}