namespace SunamoNumbers;

/// <summary>
/// Provides methods for normalizing signed numeric types to their unsigned equivalents.
/// </summary>
public static class NormalizeNumbers
{
    private static readonly long integerMaximumValue = int.MaxValue;
    private static readonly long offsetValue = 1;

    /// <summary>
    /// Normalizes a signed integer to an unsigned integer by shifting the range.
    /// </summary>
    /// <param name="inputValue">The signed integer value to normalize.</param>
    public static uint NormalizeInt(int inputValue)
    {
        var normalizedValue = (uint)(inputValue + integerMaximumValue + offsetValue);
        return normalizedValue;
    }

    /// <summary>
    /// Normalizes a signed short to an unsigned short by shifting the range.
    /// </summary>
    /// <param name="inputValue">The signed short value to normalize.</param>
    public static ushort NormalizeShort(short inputValue)
    {
        int inputAsInt = inputValue;
        int shortMaximumValue = short.MaxValue;
        var normalizedValue = (ushort)(inputAsInt + shortMaximumValue + 1);
        return normalizedValue;
    }

    /// <summary>
    /// Normalizes a signed long to an unsigned long by shifting the range.
    /// </summary>
    /// <param name="inputValue">The signed long value to normalize.</param>
    public static ulong NormalizeLong(long inputValue)
    {
        decimal inputAsDecimal = inputValue;
        decimal longMaximumValue = long.MaxValue;
        var normalizedValue = (ulong)(inputAsDecimal + longMaximumValue + 1m);
        return normalizedValue;
    }

    /// <summary>
    /// Converts a byte count to megabytes using normalization.
    /// </summary>
    /// <param name="sizeInBytes">The size in bytes.</param>
    public static uint BytesToMegabytes(int sizeInBytes)
    {
        var normalizedSize = NormalizeInt(sizeInBytes);
        normalizedSize /= 1024;
        normalizedSize /= 1024;
        return normalizedSize;
    }
}
