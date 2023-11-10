namespace Rivoltante.Core;

public sealed record RevoltMessageEmbed(string? IconUrl = null,
    string? Url = null,
    string? Title = null,
    string? Description = null,
    string? Media = null,
    string? Color = null);