namespace SunamoNumbers;

/// <summary>
/// Number Helper - provides statistical calculations, interval generation, and numeric utilities.
/// </summary>
public static partial class NH
{
    /// <summary>
    /// Generates an inclusive integer interval from the start value to the end value.
    /// </summary>
    /// <param name="from">The start of the interval.</param>
    /// <param name="to">The end of the interval (inclusive).</param>
    public static List<int> GenerateIntervalInt(int from, int to)
    {
        var intervalList = new List<int>();
        for (var currentNumber = from; currentNumber < to; currentNumber++)
            intervalList.Add(currentNumber);
        intervalList.Add(to);
        return intervalList;
    }

    /// <summary>
    /// Calculates median and average statistics without an out parameter.
    /// </summary>
    /// <param name="list">The list of float values.</param>
    /// <param name="shouldThrowOnSingleElement">Whether to throw an exception if the list has only one element.</param>
    public static (string, MedianAverage<double>) CalculateMedianAverageNoOut(List<float> list, bool shouldThrowOnSingleElement)
    {
        MedianAverage<double> medianAverageResult = null!;
        var result = CalculateMedianAverage(list, out medianAverageResult, shouldThrowOnSingleElement);
        return (result, medianAverageResult);
    }

    /// <summary>
    /// Calculates median and average statistics for a list of doubles.
    /// </summary>
    /// <param name="list">The list of double values (zeroes will be removed).</param>
    /// <param name="medianAverage">The output containing all calculated statistical values.</param>
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
    /// Calculates median and average statistics for a list of floats.
    /// </summary>
    /// <param name="list">The list of float values.</param>
    /// <param name="medianAverage">The output containing all calculated statistical values.</param>
    /// <param name="shouldThrowOnSingleElement">Whether to throw an exception if the list has only one element.</param>
    public static string CalculateMedianAverage(List<float> list, out MedianAverage<double> medianAverage, bool shouldThrowOnSingleElement)
    {
        var doubleList = CAToNumber.ToNumber(double.Parse, list);
        return CalculateMedianAverage(doubleList, out medianAverage, shouldThrowOnSingleElement);
    }

    /// <summary>
    /// Calculates median and average statistics for a list of longs.
    /// </summary>
    /// <param name="list">The list of long values.</param>
    /// <param name="shouldThrowOnSingleElement">Whether to throw an exception if the list has only one element.</param>
    public static string CalculateMedianAverage(List<long> list, bool shouldThrowOnSingleElement)
    {
        var doubleList = CAToNumber.ToNumber(double.Parse, list);
        return CalculateMedianAverage(doubleList, shouldThrowOnSingleElement);
    }

    /// <summary>
    /// Rounds a float value to the specified number of decimal places and returns the result as float.
    /// </summary>
    /// <param name="value">The float value to round.</param>
    /// <param name="decimalPlaces">The number of decimal places.</param>
    public static float RoundAndReturnInInputType(float value, int decimalPlaces)
    {
        var roundedValue = Math.Round(value, decimalPlaces).ToString();
        return float.Parse(roundedValue);
    }

    /// <summary>
    /// Extracts the last 2 digits of a year as a byte. Reversion is DTHelperGeneral.FullYear.
    /// </summary>
    /// <param name="year">The full year value.</param>
    public static byte Last2NumberByte(int year)
    {
        var yearString = year.ToString();
        yearString = yearString.Substring(yearString.Length - 3);
        return byte.Parse(yearString);
    }

    /// <summary>
    /// Casts both values to double and divides the first by the second.
    /// </summary>
    /// <param name="dividend">The value to be divided.</param>
    /// <param name="divisor">The value to divide by.</param>
    public static double Divide(object dividend, object divisor)
    {
        return double.Parse(dividend.ToString()!) / double.Parse(divisor.ToString()!);
    }

    /// <summary>
    /// Pads a byte number to 2 digits with leading zero if needed.
    /// </summary>
    /// <param name="number">The byte number to pad.</param>
    public static string MakeUpTo2NumbersToZero(byte number)
    {
        var numberString = number.ToString();
        if (numberString.Length == 1)
            return "0" + number;
        return numberString;
    }

    /// <summary>
    /// Gets the lowest value from the list that is not in the excluded values.
    /// </summary>
    /// <param name="excludedValues">The list of values to exclude.</param>
    /// <param name="list">The list of values to search.</param>
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
    /// Generates an inclusive byte interval from the start value to the end value.
    /// </summary>
    /// <param name="from">The start of the interval.</param>
    /// <param name="to">The end of the interval (inclusive).</param>
    public static List<byte> GenerateIntervalByte(byte from, byte to)
    {
        var byteIntervalList = new List<byte>();
        for (var currentByte = from; currentByte < to; currentByte++)
            byteIntervalList.Add(currentByte);
        byteIntervalList.Add(to);
        return byteIntervalList;
    }

    /// <summary>
    /// Sorts the provided values and returns them as a sorted list.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="values">The values to sort.</param>
    public static List<T> Sort<T>(params T[] values)
    {
        var sortableCollection = new List<T>(values);
        sortableCollection.Sort();
        return sortableCollection;
    }

    /// <summary>
    /// Calculates median and average statistics for categorized float values.
    /// </summary>
    /// <param name="dictionary">A dictionary mapping category names to lists of float values.</param>
    /// <param name="shouldThrowOnSingleElement">Whether to throw an exception if a category has only one element.</param>
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
    /// Calculates median and average statistics for a list of doubles.
    /// </summary>
    /// <param name="list">The list of double values.</param>
    /// <param name="shouldThrowOnSingleElement">Whether to throw an exception if the list has only one element.</param>
    public static string CalculateMedianAverage(List<double> list, bool shouldThrowOnSingleElement)
    {
        MedianAverage<double> medianAverage = null!;
        return CalculateMedianAverage(list, out medianAverage, shouldThrowOnSingleElement);
    }

    /// <summary>
    /// Calculates median and average statistics for a list of doubles without an out parameter.
    /// </summary>
    /// <param name="list">The list of double values.</param>
    /// <param name="shouldThrowOnSingleElement">Whether to throw an exception if the list has only one element.</param>
    public static (string, MedianAverage<double>) CalculateMedianAverageNoOutDouble(List<double> list, bool shouldThrowOnSingleElement)
    {
        MedianAverage<double> medianAverage = null!;
        var calculationResult = CalculateMedianAverage(list, out medianAverage, shouldThrowOnSingleElement);
        return (calculationResult, medianAverage);
    }

    /// <summary>
    /// Calculates median and average statistics for a list of doubles with full output.
    /// </summary>
    /// <param name="list">The list of double values (zeroes will be removed).</param>
    /// <param name="medianAverage">The output containing all calculated statistical values.</param>
    /// <param name="shouldThrowOnSingleElement">Whether to throw an exception if the list has only one element.</param>
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
    /// Calculates the average of two double values.
    /// </summary>
    /// <param name="totalValue">The total value (dividend).</param>
    /// <param name="count">The count to divide by (divisor).</param>
    public static double Average(double totalValue, double count)
    {
        return Average<double>(totalValue, count);
    }

    /// <summary>
    /// Computes the median value of a list. The list may be mutated during computation.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="list">The list to compute the median for.</param>
    public static T Median<T>(this IList<T> list)
        where T : IComparable<T>
    {
        return list.NthOrderStatistic((list.Count - 1) / 2);
    }

    /// <summary>
    /// Extracts leading digits from a string until a non-digit character is encountered.
    /// </summary>
    /// <param name="text">The input text.</param>
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
    /// Computes the median value using sorting. The list is not mutated.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="list">The list to compute the median for.</param>
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
