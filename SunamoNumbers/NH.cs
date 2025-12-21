namespace SunamoNumbers;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
// Instance variables refactored according to C# conventions
public static partial class NH
{
    private static Type currentType = typeof(NH);
    /// <summary>
    ///     Vytvoří interval od A1 do A2 včetně
    /// </summary>
    /// <param name = "od"></param>
    /// <param name = "to"></param>
    public static List<int> GenerateIntervalInt(int od, int to)
    {
        var intervalList = new List<int>();
        for (var currentNumber = od; currentNumber < to; currentNumber++)
            intervalList.Add(currentNumber);
        intervalList.Add(to);
        return intervalList;
    }

    public static (string, MedianAverage<double>) CalculateMedianAverageNoOut(List<float> list, bool throwExIfOnlyOneElement)
    {
        MedianAverage<double> medianAverageResult = null;
        var result = CalculateMedianAverage(list, out medianAverageResult, throwExIfOnlyOneElement);
        return (result, medianAverageResult);
    }

    /// <summary>
    ///     gen metoda abych nemusel kopírovat toho více tím že jedna volá druhou
    /// </summary>
    public static string CalculateMedianAverageT(List<double> list, out MedianAverage<double> medianAverage)
    {
        list.RemoveAll(data => data == 0);
        ThrowEx.OnlyOneElement("list", list);
        medianAverage = new MedianAverage<double>();
        medianAverage.elementCount = list.Count;
        medianAverage.medianValue = list.Median();
        medianAverage.averageValue = Average(list);
        medianAverage.minimumValue = list.Min();
        medianAverage.maximumValue = list.Max();
        return medianAverage.ToString();
    }

    public static string CalculateMedianAverage(List<float> l2, out MedianAverage<double> medianAverage, bool throwExIfOnlyOneElement)
    {
        var doubleList = CAToNumber.ToNumber(double.Parse, l2);
        return CalculateMedianAverage(doubleList, out medianAverage, throwExIfOnlyOneElement);
    }

    public static string CalculateMedianAverage(List<long> l2, bool throwExIfOnlyOneElement)
    {
        var doubleList = CAToNumber.ToNumber(double.Parse, l2);
        return CalculateMedianAverage(doubleList, throwExIfOnlyOneElement);
    }

    public static float RoundAndReturnInInputType(float ugtKm, int v)
    {
        var roundedValue = Math.Round(ugtKm, v).ToString();
        return float.Parse(roundedValue);
    }

    /// <summary>
    ///     Reversion is DTHelperGeneral.FullYear
    /// </summary>
    /// <param name = "year"></param>
    /// <returns></returns>
    public static byte Last2NumberByte(int year)
    {
        var yearString = year.ToString();
        yearString = yearString.Substring(yearString.Length - 3);
        return byte.Parse(yearString);
    }

    /// <summary>
    ///     Cast A1,2 to double and divide
    /// </summary>
    /// <param name = "textC"></param>
    /// <param name = "diac"></param>
    public static double Divide(object textC, object diac)
    {
        return double.Parse(textC.ToString()) / double.Parse(diac.ToString());
    }

    public static string MakeUpTo2NumbersToZero(byte p)
    {
        var numberString = p.ToString();
        if (numberString.Length == 1)
            return "0" + p;
        return numberString;
    }

    public static int GetLowest(List<int> excludedValues, List<int> list)
    {
        list.Sort();
        var lowestValue = list[0];
        while (excludedValues.Contains(lowestValue))
        {
            list.RemoveAt(0);
            if (list.Count > 0)
                lowestValue = list[0];
        //
        }

        return lowestValue;
    }

    public static List<byte> GenerateIntervalByte(byte od, byte to)
    {
        var byteIntervalList = new List<byte>();
        for (var currentByte = od; currentByte < to; currentByte++)
            byteIntervalList.Add(currentByte);
        byteIntervalList.Add(to);
        return byteIntervalList;
    }

    public static List<T> Sort<T>(params T[] t)
    {
        var sortableCollection = new List<T>(t);
        sortableCollection.Sort();
        return sortableCollection;
    }

    public static string CalculateMedianAverage(Dictionary<string, List<float>> typeWithSalaries, bool throwExIfOnlyOneElement)
    {
        //TextOutputGenerator tog = new TextOutputGenerator();
        var resultDictionary = new Dictionary<string, (float, string)>();
        foreach (var item in typeWithSalaries)
        {
            MedianAverage<double> ma = null;
            var calculationResult = item.Value.Count > 1 ? CalculateMedianAverage(item.Value, out ma, throwExIfOnlyOneElement) : item.Value[0].ToString();
            var averageFloat = item.Value.Count > 1 ? (float)ma.averageValue : item.Value[0];
            resultDictionary.Add(item.Key, (averageFloat, calculationResult));
        }

        dynamic stringBuilder = new StringBuilder();
        var orderedResults = resultDictionary.OrderByDescending(entry => entry.Value.Item1);
        foreach (var item in orderedResults)
            stringBuilder.PairBullet(item.Key, item.Value.Item2);
        return stringBuilder.ToString();
    }

    public static string CalculateMedianAverage(List<double> list, bool throwExIfOnlyOneElement)
    {
        MedianAverage<double> medianAverage = null;
        return CalculateMedianAverage(list, out medianAverage, throwExIfOnlyOneElement);
    }

    public static (string, MedianAverage<double>) CalculateMedianAverageNoOutDouble(List<double> list, bool throwExIfOnlyOneElement)
    {
        MedianAverage<double> medianAverage = null;
        var calculationResult = CalculateMedianAverage(list, out medianAverage, throwExIfOnlyOneElement);
        return (calculationResult, medianAverage);
    }

    public static string CalculateMedianAverage(List<double> list, out MedianAverage<double> medianAverage, bool throwExIfOnlyOneElement)
    {
        list.RemoveAll(data => data == 0);
        if (list.Count == 0)
        {
            throw new ArgumentException($"{nameof(list)} have zero elements!");
        }

        medianAverage = new MedianAverage<double>();
        if (list.Count == 1)
        {
            if (throwExIfOnlyOneElement)
            {
                ThrowEx.OnlyOneElement("list", list);
            }
            else
            {
                medianAverage.elementCount = 1;
                medianAverage.medianValue = medianAverage.averageValue = medianAverage.minimumValue = medianAverage.maximumValue = list[1];
            }
        }
        else
        {
            medianAverage.elementCount = list.Count;
            medianAverage.medianValue = list.Median();
            medianAverage.averageValue = Average(list);
            medianAverage.minimumValue = list.Min();
            medianAverage.maximumValue = list.Max();
        }

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
    public static T Median<T>(this IList<T> list)
        where T : IComparable<T>
    {
        return list.NthOrderStatistic((list.Count - 1) / 2);
    }

    public static (int, string) NumberIntUntilWontReachOtherChar(string text)
    {
        var numberStringBuilder = new StringBuilder();
        for (var index = 0; index < text.Length; index++)
            if (char.IsNumber(text[index]))
                numberStringBuilder.Append(text[index]);
            else
                break;
        var result = numberStringBuilder.ToString();
        text = SH.ReplaceOnce(text, result, string.Empty);
        return (BTS.ParseInt(result, int.MaxValue), text);
    }

    /// <summary>
    ///     Working excellent
    ///     4, 0 = 2 (as online)
    ///     4, 4, 250, 500, 500 = 250
    ///     4, 4, 250, 500, 500 = 250
    ///     4, 4, 4, 4, 250, 500, 500 = 4
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "numbers"></param>
    public static double Median2<T>(IList<T> numbers)
    {
        var numberCount = numbers.Count();
        var halfIndex = numbers.Count() / 2;
        var sortedNumbers = numbers.OrderBy(n => n);
        double median;
        if (numberCount % 2 == 0)
        {
            var upperValue = sortedNumbers.ElementAt(halfIndex);
            var lowerValue = sortedNumbers.ElementAt(halfIndex - 1);
            median = Sum(new List<string>(new[] { upperValue.ToString(), lowerValue.ToString() })) / 2;
        }
        else
        {
            median = double.Parse(sortedNumbers.ElementAt(halfIndex).ToString());
        }

        return median;
    }
}