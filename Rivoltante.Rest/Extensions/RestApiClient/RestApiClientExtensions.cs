using System.Text;
using System.Web;

namespace Rivoltante.Rest;

public static partial class RestApiClientExtensions
{
    public static string FormatRoute(string route, params object[] parameters)
        => FormatRoute(route, new Dictionary<string, object>(), parameters);

    public static string FormatRoute(string route, IDictionary<string, object> queryParameters, params object[] parameters)
    {
        var builder = new StringBuilder(RevoltRestApiClient.BaseApiUrl)
            .Append(string.Format(route, parameters));

        if (queryParameters.Count > 0)
            builder.Append('?').AppendJoin('&', queryParameters.Select(x => HttpUtility.UrlEncode($"{x.Key}={x.Value}")));

        return builder.ToString();
    }
}