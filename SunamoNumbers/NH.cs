namespace SunamoNumbers;

/// <summary>
/// Represents the NH type.
/// </summary>
public static partial class NH
{
    /// <summary>
    /// Parses an interval written as "first-second" into two unsigned numbers; returns null when the text has no dash, a part that is not a number becomes 0.
    /// </summary>
    /// <param name="text">The text, for example "25-30".</param>
    /// <returns>The two bounds, or null when the text is not an interval.</returns>
    public static (uint From, uint To)? ParseUIntInterval(string text)
    {
        if (text.IndexOf('-') < 0)
        {
            return null;
        }

        var parts = text.Split('-');
        uint.TryParse(parts[0], out var from);
        uint.TryParse(parts[1], out var to);
        return (from, to);
    }
    /// <summary>
    /// Generate interval int.
    /// </summary>
    /// <param name="from">The from.</param>
    /// <param name="to">The to.</param>
    /// <returns>The generate interval int result.</returns>
    public static List<int> GenerateIntervalInt(int from, int to)
    {
        var intervalList = new List<int>();
        for (var currentNumber = from; currentNumber < to; currentNumber++)
            intervalList.Add(currentNumber);
        intervalList.Add(to);
        return intervalList;
    }

    /// <summary>
    /// Initializes a new instance of the calculate median average no out class.
    /// </summary>
    /// <param name="string">The string.</param>
    /// <param name="MedianAverage<double>">The median average double.</param>
    public static (string, MedianAverage<double>) CalculateMedianAverageNoOut(List<float> list, bool shouldThrowOnSingleElement)
    {
        MedianAverage<double> medianAverageResult = null!;
        var result = CalculateMedianAverage(list, out medianAverageResult, shouldThrowOnSingleElement);
        return (result, medianAverageResult);
    }

    /// <summary>
    /// Calculate median average t.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="medianAverage">The median average.</param>
    /// <returns>The calculate median average t result.</returns>
    public static string CalculateMedianAverageT(List<double> list, out MedianAverage<double> medianAverage)
    {
        list.RemoveAll(value => value == 0);
        ThrowEx.OnlyOneElement("list", list);
        medianAverage = new MedianAverage<double>();
        medianAverage.ElementCount = list.Count;
        medianAverage.MedianValue = list.Median();
        medianAverage.AverageValue = Average(list);
        medianAverage.MinimumValue = list.Min();
        medianAverage.MaximumValue = list.Max();
        return medianAverage.ToString();
    }

    /// <summary>
    /// Calculate median average.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="medianAverage">The median average.</param>
    /// <param name="shouldThrowOnSingleElement">The should throw on single element.</param>
    /// <returns>The calculate median average result.</returns>
    public static string CalculateMedianAverage(List<float> list, out MedianAverage<double> medianAverage, bool shouldThrowOnSingleElement)
    {
        var doubleList = CAToNumber.ToNumber(double.Parse, list);
        return CalculateMedianAverage(doubleList, out medianAverage, shouldThrowOnSingleElement);
    }

    /// <summary>
    /// Calculate median average.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="shouldThrowOnSingleElement">The should throw on single element.</param>
    /// <returns>The calculate median average result.</returns>
    public static string CalculateMedianAverage(List<long> list, bool shouldThrowOnSingleElement)
    {
        var doubleList = CAToNumber.ToNumber(double.Parse, list);
        return CalculateMedianAverage(doubleList, shouldThrowOnSingleElement);
    }

    /// <summary>
    /// Round and return in input type.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="decimalPlaces">The decimal places.</param>
    /// <returns>The round and return in input type result.</returns>
    public static float RoundAndReturnInInputType(float value, int decimalPlaces)
    {
        var roundedValue = Math.Round(value, decimalPlaces).ToString();
        return float.Parse(roundedValue);
    }

    /// <summary>
    /// Last 2 number byte.
    /// </summary>
    /// <param name="year">The year.</param>
    /// <returns>The last 2 number byte result.</returns>
    public static byte Last2NumberByte(int year)
    {
        var yearString = year.ToString();
        yearString = yearString.Substring(yearString.Length - 3);
        return byte.Parse(yearString);
    }

    /// <summary>
    /// Divide.
    /// </summary>
    /// <param name="dividend">The dividend.</param>
    /// <param name="divisor">The divisor.</param>
    /// <returns>The divide result.</returns>
    public static double Divide(object dividend, object divisor)
    {
        return double.Parse(dividend.ToString()!) / double.Parse(divisor.ToString()!);
    }

    /// <summary>
    /// Make up to 2 numbers to zero.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <returns>The make up to 2 numbers to zero result.</returns>
    public static string MakeUpTo2NumbersToZero(byte number)
    {
        var numberString = number.ToString();
        if (numberString.Length == 1)
            return "0" + number;
        return numberString;
    }

    /// <summary>
    /// Get lowest.
    /// </summary>
    /// <param name="excludedValues">The excluded values.</param>
    /// <param name="list">The list.</param>
    /// <returns>The get lowest result.</returns>
    public static int GetLowest(List<int> excludedValues, List<int> list)
    {
        list.Sort();
        var lowestValue = list[0];
        while (excludedValues.Contains(lowestValue))
        {
            list.RemoveAt(0);
            if (list.Count > 0)
                lowestValue = list[0];
        }

        return lowestValue;
    }

    /// <summary>
    /// Generate interval byte.
    /// </summary>
    /// <param name="from">The from.</param>
    /// <param name="to">The to.</param>
    /// <returns>The generate interval byte result.</returns>
    public static List<byte> GenerateIntervalByte(byte from, byte to)
    {
        var byteIntervalList = new List<byte>();
        for (var currentByte = from; currentByte < to; currentByte++)
            byteIntervalList.Add(currentByte);
        byteIntervalList.Add(to);
        return byteIntervalList;
    }

    /// <summary>
    /// Sort t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="values">The values.</param>
    /// <returns>The sort t result.</returns>
    public static List<T> Sort<T>(params T[] values)
    {
        var sortableCollection = new List<T>(values);
        sortableCollection.Sort();
        return sortableCollection;
    }

    /// <summary>
    /// Calculate median average.
    /// </summary>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="shouldThrowOnSingleElement">The should throw on single element.</param>
    /// <returns>The calculate median average result.</returns>
    public static string CalculateMedianAverage(Dictionary<string, List<float>> dictionary, bool shouldThrowOnSingleElement)
    {
        var resultDictionary = new Dictionary<string, (float, string)>();
        foreach (var item in dictionary)
        {
            MedianAverage<double> medianAverage = null!;
            var calculationResult = item.Value.Count > 1 ? CalculateMedianAverage(item.Value, out medianAverage, shouldThrowOnSingleElement) : item.Value[0].ToString();
            var averageFloat = item.Value.Count > 1 ? (float)medianAverage.AverageValue : item.Value[0];
            resultDictionary.Add(item.Key, (averageFloat, calculationResult));
        }

        dynamic outputGenerator = new StringBuilder();
        var orderedResults = resultDictionary.OrderByDescending(entry => entry.Value.Item1);
        foreach (var item in orderedResults)
            outputGenerator.PairBullet(item.Key, item.Value.Item2);
        return outputGenerator.ToString();
    }

    /// <summary>
    /// Calculate median average.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="shouldThrowOnSingleElement">The should throw on single element.</param>
    /// <returns>The calculate median average result.</returns>
    public static string CalculateMedianAverage(List<double> list, bool shouldThrowOnSingleElement)
    {
        MedianAverage<double> medianAverage = null!;
        return CalculateMedianAverage(list, out medianAverage, shouldThrowOnSingleElement);
    }

    /// <summary>
    /// Initializes a new instance of the calculate median average no out double class.
    /// </summary>
    /// <param name="string">The string.</param>
    /// <param name="MedianAverage<double>">The median average double.</param>
    public static (string, MedianAverage<double>) CalculateMedianAverageNoOutDouble(List<double> list, bool shouldThrowOnSingleElement)
    {
        MedianAverage<double> medianAverage = null!;
        var calculationResult = CalculateMedianAverage(list, out medianAverage, shouldThrowOnSingleElement);
        return (calculationResult, medianAverage);
    }

    /// <summary>
    /// Calculate median average.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="medianAverage">The median average.</param>
    /// <param name="shouldThrowOnSingleElement">The should throw on single element.</param>
    /// <returns>The calculate median average result.</returns>
    public static string CalculateMedianAverage(List<double> list, out MedianAverage<double> medianAverage, bool shouldThrowOnSingleElement)
    {
        list.RemoveAll(value => value == 0);
        if (list.Count == 0)
        {
            throw new ArgumentException($"{nameof(list)} have zero elements!");
        }

        medianAverage = new MedianAverage<double>();
        if (list.Count == 1)
        {
            if (shouldThrowOnSingleElement)
            {
                ThrowEx.OnlyOneElement("list", list);
            }
            else
            {
                medianAverage.ElementCount = 1;
                medianAverage.MedianValue = medianAverage.AverageValue = medianAverage.MinimumValue = medianAverage.MaximumValue = list[0];
            }
        }
        else
        {
            medianAverage.ElementCount = list.Count;
            medianAverage.MedianValue = list.Median();
            medianAverage.AverageValue = Average(list);
            medianAverage.MinimumValue = list.Min();
            medianAverage.MaximumValue = list.Max();
        }

        return medianAverage.ToString();
    }

    /// <summary>
    /// Average.
    /// </summary>
    /// <param name="totalValue">The total value.</param>
    /// <param name="count">The count.</param>
    /// <returns>The average result.</returns>
    public static double Average(double totalValue, double count)
    {
        return Average<double>(totalValue, count);
    }

    /// <summary>
    /// Median t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <returns>The median t result.</returns>
    public static T Median<T>(this IList<T> list)
        where T : IComparable<T>
    {
        return list.NthOrderStatistic((list.Count - 1) / 2);
    }

    /// <summary>
    /// Initializes a new instance of the number int until wont reach other char class.
    /// </summary>
    /// <param name="int">The int.</param>
    /// <param name="string">The string.</param>
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
    /// Median 2 t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <returns>The median 2 t result.</returns>
    public static double Median2<T>(IList<T> list)
    {
        var numberCount = list.Count();
        var halfIndex = list.Count() / 2;
        var sortedList = list.OrderBy(value => value);
        double median;
        if (numberCount % 2 == 0)
        {
            var upperValue = sortedList.ElementAt(halfIndex);
            var lowerValue = sortedList.ElementAt(halfIndex - 1);
            median = Sum(new List<string>(new[] { upperValue!.ToString()!, lowerValue!.ToString()! })) / 2;
        }
        else
        {
            median = double.Parse(sortedList.ElementAt(halfIndex)!.ToString()!);
        }

        return median;
    }
}
