namespace Rivoltante.Core;

public class UlidOverflowException : Exception
{
    private static readonly Ulid MaxValue = Ulid.Parse("7ZZZZZZZZZZZZZZZZZZZZZZZZZ"); // 281474976710655
    
    internal UlidOverflowException(string ulidString) : base($"The provided ULID string {ulidString} exceeded the maximum permitted ULID {MaxValue}.") 
    { }
}