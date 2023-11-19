namespace Rivoltante.Core;

public interface IRevoltClient : ILogs
{
    //IRevoltApiClient ApiClient { get; }
    Token Token { get; }
}