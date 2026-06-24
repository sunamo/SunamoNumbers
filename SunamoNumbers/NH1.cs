namespace SunamoNumbers;

public static partial class NH
{
    public static double Median<T>(this IList<T> list, Func<T, double> getValue)
    {
        var doubleList = list.Select(getValue).ToList();
        var middleIndex = (doubleList.Count - 1) / 2;
        return doubleList.NthOrderStatistic(middleIndex);
    }

    public static double Sum(List<string> list)
    {
        double result = 0;
        foreach (var item in list)
        {
            var parsedValue = double.Parse(item);
            result += parsedValue;
        }

        return result;
    }

    public static void RemoveEndingZeroPadding(List<byte> list)
    {
        for (var currentIndex = list.Count - 1; currentIndex >= 0; currentIndex--)
            if (list[currentIndex] == 0)
                list.RemoveAt(currentIndex);
            else
                break;
    }

    public static int MinForLength(int length = 4)
    {
        return int.Parse("1".PadRight(length, '0'));
    }

    public static int MaxForLength(int length = 4)
    {
        return int.Parse("9".PadRight(length, '9'));
    }

    public static float AverageFloat(double totalValue, double count)
    {
        return (float)Average<double>(totalValue, count);
    }

    public static string MakeUpTo3NumbersToZero(int number)
    {
        var numberString = number.ToString();
        var stringLength = numberString.Length;
        if (stringLength == 1)
            return "00" + numberString;
        if (stringLength == 2)
            return "0" + numberString;
        return numberString;
    }

    public static List<short> GenerateIntervalShort(short from, short to)
    {
        var shortIntervalList = new List<short>();
        for (var currentShort = from; currentShort < to; currentShort++)
            shortIntervalList.Add(currentShort);
        shortIntervalList.Add(to);
        return shortIntervalList;
    }

    public static double ReturnTheNearestSmallIntegerNumber(double value)
    {
        return Convert.ToInt32(value);
    }

    public static List<int> Invert(List<int> list, int defaultValue, int count)
    {
        var invertedList = new List<int>(count);
        for (var currentIndex = 0; currentIndex < count; currentIndex++)
            if (list.Contains(currentIndex))
                invertedList.Add(list[list.IndexOf(currentIndex)]);
            else
                invertedList.Add(defaultValue);
        return invertedList;
    }

    public static string Round0(float value)
    {
        return Math.Round(value, 0).ToString();
    }

    public static string MakeUpTo2NumbersToZero(int number)
    {
        var numberString = number.ToString();
        if (numberString.Length == 1)
            return "0" + number;
        return numberString;
    }

    public static T Average<T>(List<T> list)
    {
        return Average<T>(Sum(list)!, list.Count);
    }

    public static T Average<T>(dynamic totalValue, dynamic count)
    {
        if (EqualityComparer<T>.Default.Equals(count, (T)ReturnZero<T>()))
            return (T)ReturnZero<T>();
        if (EqualityComparer<T>.Default.Equals(totalValue, (T)ReturnZero<T>()))
            return (T)ReturnZero<T>();
        var result = totalValue / count;
        return result;
    }

    public static int Max(List<int> list)
    {
        var maximum = int.MinValue;
        foreach (var item in list)
            if (maximum < item)
                maximum = item;
        return maximum;
    }

    public static int Min(List<int> list)
    {
        var minimum = int.MaxValue;
        foreach (var item in list)
            if (minimum > item)
                minimum = item;
        return minimum;
    }

    private static object ReturnZero<T>()
    {
        var targetType = typeof(T);
        if (targetType == Types.DoubleType)
            return NumConsts.ZeroDouble;
        if (targetType == typeof(int))
            return NumConsts.ZeroInt;
        if (targetType == Types.FloatType)
            return NumConsts.ZeroFloat;
        ThrowEx.NotImplementedCase(targetType.FullName!);
        return new object();
    }

    public static T Sum<T>(List<T> list)
    {
        dynamic sum = 0;
        foreach (var item in list)
            sum += item;
        return sum;
    }

    public static string JoinAnotherTokensIfIsNumber(List<string> list, int startIndex)
    {
        var numberStringBuilder = new StringBuilder();
        for (; startIndex < list.Count; startIndex++)
            if (int.TryParse(list[startIndex], out var _))
                numberStringBuilder.Append(list[startIndex]);
            else
                break;
        return numberStringBuilder.ToString();
    }
}
