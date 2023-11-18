namespace Rivoltante.Core;

public interface IRevoltClient : ILogs
{
    IRevoltApiClient ApiClient { get; }
}