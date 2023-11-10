using System.Buffers;

namespace Rivoltante.Core;

public readonly struct Ulid(byte[] rawValue) : IEquatable<Ulid>,
    IEquatable<string>,
    IComparable<Ulid>,
    IComparable<string>,
    IComparable
{
    private const int VALID_STRING_LENGTH = 26;
    private const string CROCKFORDS_BASE_32_VALID_CHARACTERS = "0123456789ABCDEFGHJKMNPQRSTVWXYZ";

    private readonly byte[] _rawValue = rawValue;

    public ReadOnlySpan<byte> RawValue => _rawValue.AsSpan();
    
    public DateTimeOffset CreatedAt
    {
        get
        {
            var rawTimestamp = (long)_rawValue[0] << 40 | (long)_rawValue[1] << 32 |
                               (long)_rawValue[2] << 24 | (long)_rawValue[3] << 16 |
                               (long)_rawValue[4] << 8 | _rawValue[5];
            
            return DateTimeOffset.FromUnixTimeMilliseconds(rawTimestamp);
        }
    }

    public bool Equals(Ulid other)
        => other._rawValue.SequenceEqual(other._rawValue);

    public bool Equals(string? other)
        => ToString().Equals(other);

    public int CompareTo(Ulid other)
        => CompareTo(other.ToString());

    public int CompareTo(string? other)
        => string.CompareOrdinal(ToString(), other);

    public int CompareTo(object? obj)
    {
        return obj switch
        {
            Ulid ulid => CompareTo(ulid),
            string s => CompareTo(s),
            _ => -1
        };
    }

    public override bool Equals(object? obj)
    {
        return obj switch
        {
            Ulid ulid => Equals(ulid),
            string s => Equals(s),
            _ => false
        };
    }

    public override int GetHashCode()
        => _rawValue.Aggregate(-67205002, (current, t) => current * 1587296083 + t.GetHashCode());

    public override string ToString()
    {
        return string.Create(VALID_STRING_LENGTH, this, (span, ulid) =>
        {
            for (var i = 0; i < span.Length; i++)
            {
                var value = i switch
                {
                    0 => (ulid._rawValue[0] & 224) >> 5,
                    1 => ulid._rawValue[0] & 31,
                    2 => (ulid._rawValue[1] & 248) >> 3,
                    3 => ((ulid._rawValue[1] & 7) << 2) | ((ulid._rawValue[2] & 192) >> 6),
                    4 => (ulid._rawValue[2] & 62) >> 1,
                    5 => ((ulid._rawValue[2] & 1) << 4) | ((ulid._rawValue[3] & 240) >> 4),
                    6 => ((ulid._rawValue[3] & 15) << 1) | ((ulid._rawValue[4] & 128) >> 7),
                    7 => (ulid._rawValue[4] & 124) >> 2,
                    8 => ((ulid._rawValue[4] & 3) << 3) | ((ulid._rawValue[5] & 224) >> 5),
                    9 => ulid._rawValue[5] & 31,
                    10 => (ulid._rawValue[6] & 248) >> 3,
                    11 => ((ulid._rawValue[6] & 7) << 2) | ((ulid._rawValue[7] & 192) >> 6),
                    12 => (ulid._rawValue[7] & 62) >> 1,
                    13 => ((ulid._rawValue[7] & 1) << 4) | ((ulid._rawValue[8] & 240) >> 4),
                    14 => ((ulid._rawValue[8] & 15) << 1) | ((ulid._rawValue[9] & 128) >> 7),
                    15 => (ulid._rawValue[9] & 124) >> 2,
                    16 => ((ulid._rawValue[9] & 3) << 3) | ((ulid._rawValue[10] & 224) >> 5),
                    17 => ulid._rawValue[10] & 31,
                    18 => (ulid._rawValue[11] & 248) >> 3,
                    19 => ((ulid._rawValue[11] & 7) << 2) | ((ulid._rawValue[12] & 192) >> 6),
                    20 => (ulid._rawValue[12] & 62) >> 1,
                    21 => ((ulid._rawValue[12] & 1) << 4) | ((ulid._rawValue[13] & 240) >> 4),
                    22 => ((ulid._rawValue[13] & 15) << 1) | ((ulid._rawValue[14] & 128) >> 7),
                    23 => (ulid._rawValue[14] & 124) >> 2,
                    24 => ((ulid._rawValue[14] & 3) << 3) | ((ulid._rawValue[15] & 224) >> 5),
                    25 => ulid._rawValue[15] & 31,
                    _ => throw new ArgumentOutOfRangeException(nameof(i))
                };

                span[i] = CROCKFORDS_BASE_32_VALID_CHARACTERS[value];
            }
        });
    }

    public static bool TryParse(ReadOnlySpan<char> input, out Ulid id)
    {
        try
        {
            id = Parse(input);
            return true;
        }
        catch
        {
            id = default;
            return false;
        }
    }

    public static Ulid Parse(string input)
        => Parse(input.AsSpan());

    public static Ulid Parse(ReadOnlySpan<char> input)
    {
        if (input.Length != VALID_STRING_LENGTH)
            throw new FormatException($"The input ULID must be exactly {VALID_STRING_LENGTH} characters in length.");

        var indices = ArrayPool<int>.Shared.Rent(VALID_STRING_LENGTH);
        for (var i = 0; i < input.Length; i++)
        {
            var c = char.ToUpperInvariant(input[i]);
            var index = CROCKFORDS_BASE_32_VALID_CHARACTERS.IndexOf(c);

            if (index < 0)
                throw new FormatException($"The input ULID contained an invalid character '{c}'.");

            indices[i] = index;
        }

        var rawValue = new byte[16];

        rawValue[0] = (byte)(indices[0] << 5 | indices[1]);
        rawValue[1] = (byte)(indices[2] << 3 | indices[3] >> 2);
        rawValue[2] = (byte)(indices[3] << 6 | indices[4] << 1 | indices[5] >> 4);
        rawValue[3] = (byte)(indices[5] << 4 | indices[6] >> 1);
        rawValue[4] = (byte)(indices[6] << 7 | indices[7] << 2 | indices[8] >> 3);
        rawValue[5] = (byte)(indices[8] << 5 | indices[9]);
        rawValue[6] = (byte)(indices[10] << 3 | indices[11] >> 2);
        rawValue[7] = (byte)(indices[11] << 6 | indices[12] << 1 | indices[13] >> 4);
        rawValue[8] = (byte)(indices[13] << 4 | indices[14] >> 1);
        rawValue[9] = (byte)(indices[14] << 7 | indices[15] << 2 | indices[16] >> 3);
        rawValue[10] = (byte)(indices[16] << 5 | indices[17]);
        rawValue[11] = (byte)(indices[18] << 3 | indices[19] >> 2);
        rawValue[12] = (byte)(indices[19] << 6 | indices[20] << 1 | indices[21] >> 4);
        rawValue[13] = (byte)(indices[21] << 4 | indices[22] >> 1);
        rawValue[14] = (byte)(indices[22] << 7 | indices[23] << 2 | indices[24] >> 3);
        rawValue[15] = (byte)(indices[24] << 5 | indices[25]);
        
        ArrayPool<int>.Shared.Return(indices, true);
        return new Ulid(rawValue);
    }

    public static Ulid FromGuid(Guid guid)
        => new(guid.ToByteArray());

    public static bool operator ==(Ulid l, Ulid r)
        => l._rawValue.SequenceEqual(r._rawValue);

    public static bool operator !=(Ulid l, Ulid r)
        => !l._rawValue.SequenceEqual(r._rawValue);

    public static bool operator ==(Ulid l, string r)
        => l.Equals(r);

    public static bool operator !=(Ulid l, string r)
        => !l.Equals(r);

    public static bool operator >(Ulid l, Ulid r)
        => string.CompareOrdinal(l.ToString(), r.ToString()) > 0;

    public static bool operator <(Ulid l, Ulid r)
        => string.CompareOrdinal(l.ToString(), r.ToString()) < 0;

    public static implicit operator string(Ulid ulid) => ulid.ToString();
    
    public static implicit operator Ulid(string s) => Parse(s);
}