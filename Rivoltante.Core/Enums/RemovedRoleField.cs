namespace Rivoltante.Core;

public enum RemovedRoleField
{
    Color,
    [Obsolete("Prefer using Color instead; this value is simply for interop with the API.")]
    Colour = Color
}