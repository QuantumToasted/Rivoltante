using System.Diagnostics.CodeAnalysis;

namespace Rivoltante.Core;

public sealed class CustomEmoji(Ulid id) : ICustomEmoji
{
    public Ulid Id { get; } = id;

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