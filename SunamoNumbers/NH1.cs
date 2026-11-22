namespace SunamoNumbers;

public static partial class NH
{
    /// <summary>
    /// Median t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="getValue">The get value.</param>
    /// <returns>The median t result.</returns>
    public static double Median<T>(this IList<T> list, Func<T, double> getValue)
    {
        var doubleList = list.Select(getValue).ToList();
        var middleIndex = (doubleList.Count - 1) / 2;
        return doubleList.NthOrderStatistic(middleIndex);
    }

    /// <summary>
    /// Sum.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The sum result.</returns>
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

    /// <summary>
    /// Remove ending zero padding.
    /// </summary>
    /// <param name="list">The list.</param>
    public static void RemoveEndingZeroPadding(List<byte> list)
    {
        for (var currentIndex = list.Count - 1; currentIndex >= 0; currentIndex--)
            if (list[currentIndex] == 0)
                list.RemoveAt(currentIndex);
            else
                break;
    }

    /// <summary>
    /// Min for length.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns>The min for length result.</returns>
    public static int MinForLength(int length = 4)
    {
        return int.Parse("1".PadRight(length, '0'));
    }

    /// <summary>
    /// Max for length.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns>The max for length result.</returns>
    public static int MaxForLength(int length = 4)
    {
        return int.Parse("9".PadRight(length, '9'));
    }

    /// <summary>
    /// Average float.
    /// </summary>
    /// <param name="totalValue">The total value.</param>
    /// <param name="count">The count.</param>
    /// <returns>The average float result.</returns>
    public static float AverageFloat(double totalValue, double count)
    {
        return (float)Average<double>(totalValue, count);
    }

    /// <summary>
    /// Make up to 3 numbers to zero.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <returns>The make up to 3 numbers to zero result.</returns>
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

    /// <summary>
    /// Generate interval short.
    /// </summary>
    /// <param name="from">The from.</param>
    /// <param name="to">The to.</param>
    /// <returns>The generate interval short result.</returns>
    public static List<short> GenerateIntervalShort(short from, short to)
    {
        var shortIntervalList = new List<short>();
        for (var currentShort = from; currentShort < to; currentShort++)
            shortIntervalList.Add(currentShort);
        shortIntervalList.Add(to);
        return shortIntervalList;
    }

    /// <summary>
    /// Return the nearest small integer number.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The return the nearest small integer number result.</returns>
    public static double ReturnTheNearestSmallIntegerNumber(double value)
    {
        return Convert.ToInt32(value);
    }

    /// <summary>
    /// Invert.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <param name="count">The count.</param>
    /// <returns>The invert result.</returns>
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

    /// <summary>
    /// Round 0.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The round 0 result.</returns>
    public static string Round0(float value)
    {
        return Math.Round(value, 0).ToString();
    }

    /// <summary>
    /// Make up to 2 numbers to zero.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <returns>The make up to 2 numbers to zero result.</returns>
    public static string MakeUpTo2NumbersToZero(int number)
    {
        var numberString = number.ToString();
        if (numberString.Length == 1)
            return "0" + number;
        return numberString;
    }

    /// <summary>
    /// Average t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <returns>The average t result.</returns>
    public static T Average<T>(List<T> list)
    {
        return Average<T>(Sum(list)!, list.Count);
    }

    /// <summary>
    /// Average t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="totalValue">The total value.</param>
    /// <param name="count">The count.</param>
    /// <returns>The average t result.</returns>
    public static T Average<T>(dynamic totalValue, dynamic count)
    {
        if (EqualityComparer<T>.Default.Equals(count, (T)ReturnZero<T>()))
            return (T)ReturnZero<T>();
        if (EqualityComparer<T>.Default.Equals(totalValue, (T)ReturnZero<T>()))
            return (T)ReturnZero<T>();
        var result = totalValue / count;
        return result;
    }

    /// <summary>
    /// Max.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The max result.</returns>
    public static int Max(List<int> list)
    {
        var maximum = int.MinValue;
        foreach (var item in list)
            if (maximum < item)
                maximum = item;
        return maximum;
    }

    /// <summary>
    /// Min.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The min result.</returns>
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

    /// <summary>
    /// Sum t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <returns>The sum t result.</returns>
    public static T Sum<T>(List<T> list)
    {
        dynamic sum = 0;
        foreach (var item in list)
            sum += item;
        return sum;
    }

    /// <summary>
    /// Join another tokens if is number.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="startIndex">The start index.</param>
    /// <returns>The join another tokens if is number result.</returns>
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
