using System.Text;

namespace Rivoltante.Bonfire;

public sealed class WebSocketClosedException(int? closeCode, string? closeMessage, Exception? innerException = null) 
    : Exception(FormatMessage(closeCode, closeMessage), innerException)
{
    public int? CloseCode { get; } = closeCode;

    public string? CloseMessage { get; } = closeMessage;

    private static string FormatMessage(int? closeStatus, string? closeMessage)
    {
        return new StringBuilder("The web socket was closed with code \"")
            .Append(closeStatus.HasValue
                ? $"{closeStatus}: {closeMessage}"
                : "{{no code}}")
            .Append("\".")
            .ToString();
    }
}