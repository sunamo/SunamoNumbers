namespace SunamoNumbers._sunamo.SunamoBts;

internal class BTS
{
    internal static string? ToString<T>(T value)
    {
        return value?.ToString();
    }

    internal static object MethodForParse<T>()
    {
        var targetType = typeof(T);

        if (targetType == Types.StringType)
        {
            return new Func<string, string>(ToString<string>!);
        }
        if (targetType == Types.BoolType)
        {
            return new Func<string, bool>(bool.Parse);
        }

        if (targetType == Types.FloatType)
        {
            return new Func<string, float>(float.Parse);
        }
        if (targetType == Types.DoubleType)
        {
            return new Func<string, double>(double.Parse);
        }
        if (targetType == typeof(int))
        {
            return new Func<string, int>(int.Parse);
        }
        if (targetType == Types.LongType)
        {
            return new Func<string, long>(long.Parse);
        }
        if (targetType == Types.ShortType)
        {
            return new Func<string, short>(short.Parse);
        }
        if (targetType == Types.DecimalType)
        {
            return new Func<string, decimal>(decimal.Parse);
        }
        if (targetType == Types.SbyteType)
        {
            return new Func<string, sbyte>(sbyte.Parse);
        }

        if (targetType == Types.ByteType)
        {
            return new Func<string, byte>(byte.Parse);
        }
        if (targetType == Types.UshortType)
        {
            return new Func<string, ushort>(ushort.Parse);
        }
        if (targetType == Types.UintType)
        {
            return new Func<string, uint>(uint.Parse);
        }
        if (targetType == Types.UlongType)
        {
            return new Func<string, ulong>(ulong.Parse);
        }

        if (targetType == Types.DateTimeType)
        {
            return new Func<string, DateTime>(DateTime.Parse);
        }
        if (targetType == Types.GuidType)
        {
            return new Func<string, Guid>(Guid.Parse);
        }
        if (targetType == Types.CharType)
        {
            return new Func<string, char>((string text) => text[0]);
        }

        return new object();
    }

    internal static int ParseInt(string text, int defaultValue)
    {
        text = text.Replace(" ", string.Empty);

        if (int.TryParse(text, out int parsedInteger))
        {
            return parsedInteger;
        }
        return defaultValue;
    }
}
