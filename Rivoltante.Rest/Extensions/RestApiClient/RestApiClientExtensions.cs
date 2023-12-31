﻿using System.Text;
using System.Web;
using Rivoltante.Core;
using static System.Web.HttpUtility;

namespace Rivoltante.Rest;

public static partial class RestApiClientExtensions
{
    public static ValueTask<NodeQueryApiModel> QueryNodeAsync(this IRevoltRestApiClient client, CancellationToken cancellationToken = default)
        => client.RequestAsync<NodeQueryApiModel>(HttpMethod.Get, FormatRoute(string.Empty), null, cancellationToken);
    
    public static string FormatRoute(string route, params object[] parameters)
        => FormatRoute(route, new Dictionary<string, object>(), parameters);

    public static string FormatRoute(string route, IDictionary<string, object> queryParameters, params object[] parameters)
    {
        var builder = new StringBuilder(RevoltRestApiClient.BaseApiUrl)
            .Append(string.Format(route, parameters));

        if (queryParameters.Count > 0)
            builder.Append('?').AppendJoin('&', queryParameters.Select(x => $"{UrlEncode(x.Key)}={UrlEncode(x.Value.ToString())}"));

        return builder.ToString();
    }
}