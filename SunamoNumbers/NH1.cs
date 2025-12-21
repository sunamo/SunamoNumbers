namespace SunamoNumbers;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
// Instance variables refactored according to C# conventions
public static partial class NH
{
    public static double Median<T>(this IList<T> sequence, Func<T, double> getValue)
    {
        var list = sequence.Select(getValue).ToList();
        var mid = (list.Count - 1) / 2;
        return list.NthOrderStatistic(mid);
    }

    public static double Sum(List<string> list)
    {
        double result = 0;
        foreach (var item in list)
        {
            var data = double.Parse(item);
            result += data;
        }

        return result;
    }

    public static void RemoveEndingZeroPadding(List<byte> bajty)
    {
        for (var currentIndex = bajty.Count - 1; currentIndex >= 0; currentIndex--)
            if (bajty[currentIndex] == 0)
                bajty.RemoveAt(currentIndex);
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

    public static float AverageFloat(double gridWidth, double columnsCount)
    {
        return (float)Average<double>(gridWidth, columnsCount);
    }

    public static string MakeUpTo3NumbersToZero(int p)
    {
        var numberString = p.ToString();
        var stringLength = numberString.Length;
        if (stringLength == 1)
            return "00" + numberString;
        if (stringLength == 2)
            return "0" + numberString;
        return numberString;
    }

    /// <summary>
    ///     Vytvoří interval od A1 do A2 včetně
    /// </summary>
    /// <param name = "od"></param>
    /// <param name = "to"></param>
    public static List<short> GenerateIntervalShort(short od, short to)
    {
        var shortIntervalList = new List<short>();
        for (var currentShort = od; currentShort < to; currentShort++)
            shortIntervalList.Add(currentShort);
        shortIntervalList.Add(to);
        return shortIntervalList;
    }

    public static double ReturnTheNearestSmallIntegerNumber(double data)
    {
        return Convert.ToInt32(data);
    }

    public static List<int> Invert(List<int> arr, int changeTo, int finalCount)
    {
        var invertedList = new List<int>(finalCount);
        for (var currentIndex = 0; currentIndex < finalCount; currentIndex++)
            if (arr.Contains(currentIndex))
                invertedList.Add(arr[arr.IndexOf(currentIndex)]);
            else
                invertedList.Add(changeTo);
        return invertedList;
    }

    public static string Round0(float v)
    {
        return Math.Round(v, 0).ToString();
    }

    public static string MakeUpTo2NumbersToZero(int p)
    {
        var numberString = p.ToString();
        if (numberString.Length == 1)
            return "0" + p;
        return numberString;
    }

    public static T Average<T>(List<T> list)
    {
        return Average<T>(Sum(list), list.Count);
    }

    public static T Average<T>(dynamic gridWidth, dynamic columnsCount)
    {
        if (EqualityComparer<T>.Default.Equals(columnsCount, (T)ReturnZero<T>()))
            return (T)ReturnZero<T>();
        if (EqualityComparer<T>.Default.Equals(gridWidth, (T)ReturnZero<T>()))
            return (T)ReturnZero<T>();
        var result = gridWidth / columnsCount;
        return result;
    }

    public static int Max(List<int> createEmpty)
    {
        var max = int.MinValue;
        foreach (var item in createEmpty)
            if (max < item)
                max = item;
        return max;
    }

    public static int Min(List<int> createEmpty)
    {
        var max = int.MaxValue;
        foreach (var item in createEmpty)
            if (max > item)
                max = item;
        return max;
    }

    /// <summary>
    ///     Must be object to use in EqualityComparer
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    private static object ReturnZero<T>()
    {
        var targetType = typeof(T);
        if (targetType == Types.tDouble)
            return NumConsts.zeroDouble;
        if (targetType == typeof(int))
            return NumConsts.zeroInt;
        if (targetType == Types.tFloat)
            return NumConsts.zeroFloat;
        ThrowEx.NotImplementedCase(targetType.FullName);
        return new object ();
    }

    public static T Sum<T>(List<T> list)
    {
        dynamic sum = 0;
        foreach (var item in list)
            sum += item;
        return sum;
    }

    public static string JoinAnotherTokensIfIsNumber(List<string> p, int i)
    {
        var numberStringBuilder = new StringBuilder();
        for (; i < p.Count; i++)
            if (int.TryParse(p[i], out var _))
                numberStringBuilder.Append(p[i]);
            else
                break;
        return numberStringBuilder.ToString();
    }
}