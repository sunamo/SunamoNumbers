namespace SunamoNumbers;

public static class NH
{
    private static Type type = typeof(NH);

    /// <summary>
    ///     Vytvoří interval od A1 do A2 včetně
    /// </summary>
    /// <param name="od"></param>
    /// <param name="to"></param>
    public static List<int> GenerateIntervalInt(int od, int to)
    {
        var vr = new List<int>();
        for (var i = od; i < to; i++) vr.Add(i);
        vr.Add(to);
        return vr;
    }

    public static (string, MedianAverage<double>) CalculateMedianAverageNoOut(List<float> l)
    {
        MedianAverage<double> ma = null;
        var result = CalculateMedianAverage(l, out ma);
        return (result, ma);
    }

    /// <summary>
    ///     gen metoda abych nemusel kopírovat toho více tím že jedna volá druhou
    /// </summary>
    /// <param name="l2"></param>
    /// <param name="medianAverage"></param>
    /// <returns></returns>
    public static string CalculateMedianAverageT(List<double> list, out MedianAverage<double> medianAverage)
    {
        list.RemoveAll(d => d == 0);

        ThrowEx.OnlyOneElement("list", list);

        medianAverage = new MedianAverage<double>();
        medianAverage.count = list.Count;
        medianAverage.median = list.Median();
        medianAverage.average = Average(list);
        medianAverage.min = list.Min();
        medianAverage.max = list.Max();

        return medianAverage.ToString();
    }

    public static string CalculateMedianAverage(List<float> l2, out MedianAverage<double> medianAverage)
    {
        var l = CAToNumber.ToNumber(double.Parse, l2);
        return CalculateMedianAverage(l, out medianAverage);
    }

    public static string CalculateMedianAverage(List<long> l2)
    {
        var l = CAToNumber.ToNumber(double.Parse, l2);
        return CalculateMedianAverage(l);
    }

    public static float RoundAndReturnInInputType(float ugtKm, int v)
    {
        var vr = Math.Round(ugtKm, v).ToString();
        return float.Parse(vr);
    }


    /// <summary>
    ///     Reversion is DTHelperGeneral.FullYear
    /// </summary>
    /// <param name="year"></param>
    /// <returns></returns>
    public static byte Last2NumberByte(int year)
    {
        var ts = year.ToString();
        ts = ts.Substring(ts.Length - 3);
        return byte.Parse(ts);
    }

    /// <summary>
    ///     Cast A1,2 to double and divide
    /// </summary>
    /// <param name="textC"></param>
    /// <param name="diac"></param>
    public static double Divide(object textC, object diac)
    {
        return double.Parse(textC.ToString()) / double.Parse(diac.ToString());
    }

    public static string MakeUpTo2NumbersToZero(byte p)
    {
        var s = p.ToString();
        if (s.Length == 1) return "0" + p;
        return s;
    }


    public static int GetLowest(List<int> excludedValues, List<int> list)
    {
        list.Sort();
        var vr = list[0];
        while (excludedValues.Contains(vr))
        {
            list.RemoveAt(0);
            if (list.Count > 0) vr = list[0];
            //
        }

        return vr;
    }

    public static List<byte> GenerateIntervalByte(byte od, byte to)
    {
        var vr = new List<byte>();
        for (var i = od; i < to; i++) vr.Add(i);
        vr.Add(to);
        return vr;
    }

    public static List<T> Sort<T>(params T[] t)
    {
        var c = new List<T>(t);
        c.Sort();
        return c;
    }

    public static string CalculateMedianAverage(Dictionary<string, List<float>> typeWithSalaries)
    {
        //TextOutputGenerator tog = new TextOutputGenerator();
        var d = new Dictionary<string, (float, string)>();

        foreach (var item in typeWithSalaries)
        {
            MedianAverage<double> ma = null;
            var r = item.Value.Count > 1 ? CalculateMedianAverage(item.Value, out ma) : item.Value[0].ToString();
            var f = item.Value.Count > 1 ? (float)ma.average : item.Value[0];
            d.Add(item.Key, (f, r));
        }

        dynamic sb = new StringBuilder();

        var ord = d.OrderByDescending(d => d.Value.Item1);
        foreach (var item in ord) sb.PairBullet(item.Key, item.Value.Item2);

        return sb.ToString();
    }

    public static string CalculateMedianAverage(List<double> list)
    {
        MedianAverage<double> medianAverage = null;
        return CalculateMedianAverage(list, out medianAverage);
    }

    public static (string, MedianAverage<double>) CalculateMedianAverageNoOutDouble(List<double> list)
    {
        MedianAverage<double> medianAverage = null;
        var vr = CalculateMedianAverage(list, out medianAverage);
        return (vr, medianAverage);
    }

    public static string CalculateMedianAverage(List<double> list, out MedianAverage<double> medianAverage)
    {
        list.RemoveAll(d => d == 0);

        ThrowEx.OnlyOneElement("list", list);

        medianAverage = new MedianAverage<double>();
        medianAverage.count = list.Count;
        medianAverage.median = list.Median();
        medianAverage.average = Average(list);
        medianAverage.min = list.Min();
        medianAverage.max = list.Max();

        return medianAverage.ToString();
    }


    public static double Average(double gridWidth, double columnsCount)
    {
        return Average<double>(gridWidth, columnsCount);
    }


    /// <summary>
    ///     Median = most frequented value
    ///     Note: specified list would be mutated in the process.
    ///     Working excellent
    ///     4, 0 = 0
    ///     4, 4, 250, 500, 500 = 250
    ///     4, 4, 250, 500, 500 = 250
    ///     4, 4, 4, 4, 250, 500, 500 = 4
    /// </summary>
    public static T Median<T>(this IList<T> list) where T : IComparable<T>
    {
        return list.NthOrderStatistic((list.Count - 1) / 2);
    }

    public static (int, string) NumberIntUntilWontReachOtherChar(string s)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < s.Length; i++)
            if (char.IsNumber(s[i]))
                sb.Append(s[i]);
            else
                break;

        var result = sb.ToString();

        s = SH.ReplaceOnce(s, result, string.Empty);


        return (BTS.ParseInt(result, int.MaxValue), s);
    }

    /// <summary>
    ///     Working excellent
    ///     4, 0 = 2 (as online)
    ///     4, 4, 250, 500, 500 = 250
    ///     4, 4, 250, 500, 500 = 250
    ///     4, 4, 4, 4, 250, 500, 500 = 4
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="numbers"></param>
    public static double Median2<T>(IList<T> numbers)
    {
        var numberCount = numbers.Count();
        var halfIndex = numbers.Count() / 2;
        var sortedNumbers = numbers.OrderBy(n => n);
        double median;
        if (numberCount % 2 == 0)
        {
            var d = sortedNumbers.ElementAt(halfIndex);
            var d2 = sortedNumbers.ElementAt(halfIndex - 1);
            median = Sum(new List<string>(new[] { d.ToString(), d2.ToString() })) / 2;
        }
        else
        {
            median = double.Parse(sortedNumbers.ElementAt(halfIndex).ToString());
        }

        return median;
    }

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
            var d = double.Parse(item);
            result += d;
        }

        return result;
    }

    public static void RemoveEndingZeroPadding(List<byte> bajty)
    {
        for (var i = bajty.Count - 1; i >= 0; i--)
            if (bajty[i] == 0)
                bajty.RemoveAt(i);
            else
                break;
    }

    public static int MinForLength(int length)
    {
        return int.Parse("1".PadRight(4, '0'));
    }

    public static int MaxForLength(int length)
    {
        return int.Parse("9".PadRight(4, '9'));
    }

    public static float AverageFloat(double gridWidth, double columnsCount)
    {
        return (float)Average<double>(gridWidth, columnsCount);
    }

    public static string MakeUpTo3NumbersToZero(int p)
    {
        var ps = p.ToString();
        var delka = ps.Length;
        if (delka == 1)
            return "00" + ps;
        if (delka == 2) return "0" + ps;
        return ps;
    }

    /// <summary>
    ///     Vytvoří interval od A1 do A2 včetně
    /// </summary>
    /// <param name="od"></param>
    /// <param name="to"></param>
    public static List<short> GenerateIntervalShort(short od, short to)
    {
        var vr = new List<short>();
        for (var i = od; i < to; i++) vr.Add(i);
        vr.Add(to);
        return vr;
    }

    public static double ReturnTheNearestSmallIntegerNumber(double d)
    {
        return Convert.ToInt32(d);
    }

    public static List<int> Invert(List<int> arr, int changeTo, int finalCount)
    {
        var vr = new List<int>(finalCount);
        for (var i = 0; i < finalCount; i++)
            if (arr.Contains(i))
                vr.Add(arr[arr.IndexOf(i)]);
            else
                vr.Add(changeTo);
        return vr;
    }


    public static string Round0(float v)
    {
        return Math.Round(v, 0).ToString();
    }

    public static string MakeUpTo2NumbersToZero(int p)
    {
        var s = p.ToString();
        if (s.Length == 1) return "0" + p;
        return s;
    }

    public static T Average<T>(List<T> list)
    {
        return Average<T>(Sum(list), list.Count);
    }

    public static T Average<T>(dynamic gridWidth, dynamic columnsCount)
    {
        if (EqualityComparer<T>.Default.Equals(columnsCount, (T)ReturnZero<T>())) return (T)ReturnZero<T>();

        if (EqualityComparer<T>.Default.Equals(gridWidth, (T)ReturnZero<T>())) return (T)ReturnZero<T>();

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
    /// <typeparam name="T"></typeparam>
    private static object ReturnZero<T>()
    {
        var t = typeof(T);
        if (t == Types.tDouble)
            return NumConsts.zeroDouble;
        if (t == Types.tInt)
            return NumConsts.zeroInt;
        if (t == Types.tFloat) return NumConsts.zeroFloat;
        ThrowEx.NotImplementedCase(t.FullName);
        return null;
    }

    public static T Sum<T>(List<T> list)
    {
        dynamic sum = 0;
        foreach (var item in list) sum += item;
        return sum;
    }

    public static string JoinAnotherTokensIfIsNumber(List<string> p, int i)
    {
        var sb = new StringBuilder();

        for (; i < p.Count; i++)
            if (int.TryParse(p[i], out var _))
                sb.Append(p[i]);
            else
                break;

        return sb.ToString();
    }
}