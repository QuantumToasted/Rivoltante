using System.Text.Json;

namespace Rivoltante.Core;

public interface IRevoltApiClient : ILogs
{
    Token Token { get; }
    
    JsonSerializerOptions SerializerOptions { get; }
}