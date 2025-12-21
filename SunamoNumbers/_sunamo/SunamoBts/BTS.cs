namespace SunamoNumbers._sunamo.SunamoBts;

internal class BTS
{
    internal static string? ToString<T>(T value)
    {
        return value.ToString();
    }

    internal static object MethodForParse<T1>()
    {
        var targetType = typeof(T1);
        #region Same seria as in DefaultValueForTypeT
        #region MyRegion
        if (targetType == Types.tString)
        {
            return new Func<string, string>(ToString<string>);
        }
        if (targetType == Types.tBool)
        {
            return new Func<string, bool>(bool.Parse);
        }
        #endregion

        #region Signed numbers
        if (targetType == Types.tFloat)
        {
            return new Func<string, float>(float.Parse);
        }
        if (targetType == Types.tDouble)
        {
            return new Func<string, double>(double.Parse);
        }
        if (targetType == typeof(int))
        {
            return new Func<string, int>(int.Parse);
        }
        if (targetType == Types.tLong)
        {
            return new Func<string, long>(long.Parse);
        }
        if (targetType == Types.tShort)
        {
            return new Func<string, short>(short.Parse);
        }
        if (targetType == Types.tDecimal)
        {
            return new Func<string, decimal>(decimal.Parse);
        }
        if (targetType == Types.tSbyte)
        {
            return new Func<string, sbyte>(sbyte.Parse);
        }
        #endregion

        #region Unsigned numbers
        if (targetType == Types.tByte)
        {
            return new Func<string, byte>(byte.Parse);
        }
        if (targetType == Types.tUshort)
        {
            return new Func<string, ushort>(ushort.Parse);
        }
        if (targetType == Types.tUint)
        {
            return new Func<string, uint>(uint.Parse);
        }
        if (targetType == Types.tUlong)
        {
            return new Func<string, ulong>(ulong.Parse);
        }
        #endregion

        if (targetType == Types.tDateTime)
        {
            return new Func<string, DateTime>(DateTime.Parse);
        }
        if (targetType == Types.tGuid)
        {
            return new Func<string, Guid>(Guid.Parse);
        }
        if (targetType == Types.tChar)
        {
            return new Func<string, char>((string stringValue) => stringValue[0]);
        }

        #endregion

        return new object();
    }

    internal static int ParseInt(string inputEntry, int defaultValue)
    {
        //inputEntry = SH.FromSpace160To32(inputEntry);
        inputEntry = inputEntry.Replace(" ", string.Empty);
        //var characterAtIndex3 = inputEntry[3];

        int parsedInteger = 0;
        if (int.TryParse(inputEntry, out parsedInteger))
        {
            return parsedInteger;
        }
        return defaultValue;
    }
}