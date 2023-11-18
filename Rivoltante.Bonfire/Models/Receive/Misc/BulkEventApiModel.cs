namespace Rivoltante.Bonfire;

public sealed class BulkEventApiModel : IReceiveEventApiModel
{
    public required IReceiveEventApiModel[] V { get; init; }
    
    public ReceiveEventType? Type => ReceiveEventType.Bulk;
}