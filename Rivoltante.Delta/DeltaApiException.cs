using System.Net;
using System.Text;
using Humanizer;

namespace Rivoltante.Delta;

public class DeltaApiException : HttpRequestException
{
    public DeltaApiException(HttpStatusCode statusCode, ErrorResponseApiModel errorModel)
        : base(FormatMessage(statusCode, errorModel), null, statusCode)
    {
        ErrorModel = errorModel;
    }
    
    public DeltaApiException(HttpStatusCode statusCode, string? message)
        : base(message, null, statusCode)
    { }
    
    public ErrorResponseApiModel? ErrorModel { get; }

    public static string FormatMessage(HttpStatusCode statusCode, ErrorResponseApiModel errorModel)
    {
        var builder = new StringBuilder()
            .AppendLine($"Revolt Delta API error: {statusCode:D} {statusCode.Humanize(LetterCasing.Title)}");

        if (errorModel.Location.HasValue)
            builder.AppendLine($"Location: {errorModel.Location}");

        builder.AppendLine(errorModel.GetErrorType() switch
        {
            ErrorResponseType.DatabaseError => $"Internal database error (operation {errorModel.Operation}, with {errorModel.With})",
            ErrorResponseType.MissingPermission => $"Missing permission: {errorModel.Permission.Value.Humanize(LetterCasing.Title)}",
            ErrorResponseType.MissingUserPermission => $"Missing user permission: {errorModel.Permission.Value.Humanize(LetterCasing.Title)}",
            ErrorResponseType.TooManyAttachments or ErrorResponseType.TooManyChannels or ErrorResponseType.TooManyEmbeds or 
                ErrorResponseType.TooManyEmoji or ErrorResponseType.TooManyReplies or ErrorResponseType.TooManyRoles or 
                ErrorResponseType.TooManyServers or ErrorResponseType.GroupTooLarge => $"Maximum: {errorModel.Max}",
            _ => string.Empty
        });

        return builder.ToString();
    }
}