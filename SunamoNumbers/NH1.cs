namespace SunamoNumbers;

/// <summary>
/// Number Helper (partial) - additional statistical, conversion, and utility methods.
/// </summary>
public static partial class NH
{
    /// <summary>
    /// Computes the median value of a sequence using a value selector function.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="list">The list to compute the median for.</param>
    /// <param name="getValue">The function to extract a double value from each element.</param>
    public static double Median<T>(this IList<T> list, Func<T, double> getValue)
    {
        var doubleList = list.Select(getValue).ToList();
        var middleIndex = (doubleList.Count - 1) / 2;
        return doubleList.NthOrderStatistic(middleIndex);
    }

    /// <summary>
    /// Sums all values in a list of string-represented numbers.
    /// </summary>
    /// <param name="list">The list of string values to sum.</param>
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
    /// Removes trailing zero bytes from the end of a byte list.
    /// </summary>
    /// <param name="list">The list of bytes to trim.</param>
    public static void RemoveEndingZeroPadding(List<byte> list)
    {
        for (var currentIndex = list.Count - 1; currentIndex >= 0; currentIndex--)
            if (list[currentIndex] == 0)
                list.RemoveAt(currentIndex);
            else
                break;
    }

    /// <summary>
    /// Returns the minimum integer value that has the specified digit length.
    /// </summary>
    /// <param name="length">The number of digits.</param>
    public static int MinForLength(int length = 4)
    {
        return int.Parse("1".PadRight(length, '0'));
    }

    /// <summary>
    /// Returns the maximum integer value that has the specified digit length.
    /// </summary>
    /// <param name="length">The number of digits.</param>
    public static int MaxForLength(int length = 4)
    {
        return int.Parse("9".PadRight(length, '9'));
    }

    /// <summary>
    /// Calculates the average of two values and returns the result as float.
    /// </summary>
    /// <param name="totalValue">The total value (dividend).</param>
    /// <param name="count">The count to divide by (divisor).</param>
    public static float AverageFloat(double totalValue, double count)
    {
        return (float)Average<double>(totalValue, count);
    }

    /// <summary>
    /// Pads an integer number to 3 digits with leading zeroes if needed.
    /// </summary>
    /// <param name="number">The number to pad.</param>
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
    /// Generates an inclusive short interval from the start value to the end value.
    /// </summary>
    /// <param name="from">The start of the interval.</param>
    /// <param name="to">The end of the interval (inclusive).</param>
    public static List<short> GenerateIntervalShort(short from, short to)
    {
        var shortIntervalList = new List<short>();
        for (var currentShort = from; currentShort < to; currentShort++)
            shortIntervalList.Add(currentShort);
        shortIntervalList.Add(to);
        return shortIntervalList;
    }

    /// <summary>
    /// Returns the nearest integer value for a double (rounds to nearest).
    /// </summary>
    /// <param name="value">The double value to convert.</param>
    public static double ReturnTheNearestSmallIntegerNumber(double value)
    {
        return Convert.ToInt32(value);
    }

    /// <summary>
    /// Creates an inverted list where missing indices are filled with a default value.
    /// </summary>
    /// <param name="list">The source list of integer values.</param>
    /// <param name="defaultValue">The value to use for indices not present in the source list.</param>
    /// <param name="count">The total number of elements in the result.</param>
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
    /// Rounds a float value to zero decimal places and returns as string.
    /// </summary>
    /// <param name="value">The float value to round.</param>
    public static string Round0(float value)
    {
        return Math.Round(value, 0).ToString();
    }

    /// <summary>
    /// Pads an integer number to 2 digits with leading zero if needed.
    /// </summary>
    /// <param name="number">The integer number to pad.</param>
    public static string MakeUpTo2NumbersToZero(int number)
    {
        var numberString = number.ToString();
        if (numberString.Length == 1)
            return "0" + number;
        return numberString;
    }

    /// <summary>
    /// Calculates the average of all values in a list.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <param name="list">The list of values to average.</param>
    public static T Average<T>(List<T> list)
    {
        return Average<T>(Sum(list)!, list.Count);
    }

    /// <summary>
    /// Calculates the average by dividing the total value by the count.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <param name="totalValue">The total value (dividend).</param>
    /// <param name="count">The count to divide by (divisor).</param>
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
    /// Finds the maximum value in a list of integers.
    /// </summary>
    /// <param name="list">The list of integers.</param>
    public static int Max(List<int> list)
    {
        var maximum = int.MinValue;
        foreach (var item in list)
            if (maximum < item)
                maximum = item;
        return maximum;
    }

    /// <summary>
    /// Finds the minimum value in a list of integers.
    /// </summary>
    /// <param name="list">The list of integers.</param>
    public static int Min(List<int> list)
    {
        var minimum = int.MaxValue;
        foreach (var item in list)
            if (minimum > item)
                minimum = item;
        return minimum;
    }

    /// <summary>
    /// Returns the zero value for the specified numeric type. Must return object for use in EqualityComparer.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
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
    /// Sums all values in a generic list using dynamic dispatch.
    /// </summary>
    /// <typeparam name="T">The numeric type.</typeparam>
    /// <param name="list">The list of values to sum.</param>
    public static T Sum<T>(List<T> list)
    {
        dynamic sum = 0;
        foreach (var item in list)
            sum += item;
        return sum;
    }

    /// <summary>
    /// Joins consecutive numeric tokens starting at the specified index into a single number string.
    /// </summary>
    /// <param name="list">The list of string tokens.</param>
    /// <param name="startIndex">The index to start joining from.</param>
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
