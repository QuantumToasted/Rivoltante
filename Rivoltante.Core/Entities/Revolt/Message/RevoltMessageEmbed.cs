namespace Rivoltante.Core;

public sealed record RevoltMessageEmbed(Optional<string> IconUrl = default,
    Optional<string> Url = default,
    Optional<string> Title = default,
    Optional<string> Description = default,
    Optional<string> Media = default,
    Optional<string> Color = default);