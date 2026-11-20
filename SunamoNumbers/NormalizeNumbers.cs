namespace SunamoNumbers;

/// <summary>
/// Represents the normalize numbers type.
/// </summary>
public static class NormalizeNumbers
{
    private static readonly long integerMaximumValue = int.MaxValue;
    private static readonly long offsetValue = 1;

    /// <summary>
    /// Normalize int.
    /// </summary>
    /// <param name="inputValue">The input value.</param>
    /// <returns>The normalize int result.</returns>
    public static uint NormalizeInt(int inputValue)
    {
        var normalizedValue = (uint)(inputValue + integerMaximumValue + offsetValue);
        return normalizedValue;
    }

    /// <summary>
    /// Normalize short.
    /// </summary>
    /// <param name="inputValue">The input value.</param>
    /// <returns>The normalize short result.</returns>
    public static ushort NormalizeShort(short inputValue)
    {
        int inputAsInt = inputValue;
        int shortMaximumValue = short.MaxValue;
        var normalizedValue = (ushort)(inputAsInt + shortMaximumValue + 1);
        return normalizedValue;
    }

    /// <summary>
    /// Normalize long.
    /// </summary>
    /// <param name="inputValue">The input value.</param>
    /// <returns>The normalize long result.</returns>
    public static ulong NormalizeLong(long inputValue)
    {
        decimal inputAsDecimal = inputValue;
        decimal longMaximumValue = long.MaxValue;
        var normalizedValue = (ulong)(inputAsDecimal + longMaximumValue + 1m);
        return normalizedValue;
    }

    /// <summary>
    /// Bytes to megabytes.
    /// </summary>
    /// <param name="sizeInBytes">The size in bytes.</param>
    /// <returns>The bytes to megabytes result.</returns>
    public static uint BytesToMegabytes(int sizeInBytes)
    {
        var normalizedSize = NormalizeInt(sizeInBytes);
        normalizedSize /= 1024;
        normalizedSize /= 1024;
        return normalizedSize;
    }
}
