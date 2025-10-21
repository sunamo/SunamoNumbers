// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
// Instance variables refactored according to C# conventions
namespace SunamoNumbers;

public static class NormalizeNumbers
{
    private static readonly long integerMaximumValue = int.MaxValue;
    private static readonly long offsetValue = 1;

    public static uint NormalizeInt(int inputValue)
    {
        //long inputValueAsLong = (long)inputValue;

        var normalizedValue = (uint)(inputValue + integerMaximumValue + offsetValue);
        //normalizedValue++;
        return normalizedValue;
    }


    public static ushort NormalizeShort(short inputValue)
    {
        int inputAsInt = inputValue;
        int shortMaximumValue = short.MaxValue;
        var normalizedValue = (ushort)(inputAsInt + shortMaximumValue + 1);
        //normalizedValue++;
        return normalizedValue;
    }

    public static ulong NormalizeLong(long inputValue)
    {
        decimal inputAsDecimal = inputValue;
        decimal longMaximumValue = long.MaxValue;
        var normalizedValue = (ulong)(inputAsDecimal + longMaximumValue + 1m);
        //normalizedValue++;
        return normalizedValue;
    }

    public static uint BytesToMegabytes(int sizeInBytes)
    {
        var normalizedSize = NormalizeInt(sizeInBytes);
        normalizedSize /= 1024;
        normalizedSize /= 1024;
        return normalizedSize;
    }
}