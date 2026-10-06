namespace SunamoNumbers;

public static partial class NH
{
    public static List<int> GenerateIntervalInt(int from, int to)
    {
        var intervalList = new List<int>();
        for (var currentNumber = from; currentNumber < to; currentNumber++)
            intervalList.Add(currentNumber);
        intervalList.Add(to);
        return intervalList;
    }

    public static (string, MedianAverage<double>) CalculateMedianAverageNoOut(List<float> list, bool shouldThrowOnSingleElement)
    {
        MedianAverage<double> medianAverageResult = null!;
        var result = CalculateMedianAverage(list, out medianAverageResult, shouldThrowOnSingleElement);
        return (result, medianAverageResult);
    }

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

    public static string CalculateMedianAverage(List<float> list, out MedianAverage<double> medianAverage, bool shouldThrowOnSingleElement)
    {
        var doubleList = CAToNumber.ToNumber(double.Parse, list);
        return CalculateMedianAverage(doubleList, out medianAverage, shouldThrowOnSingleElement);
    }

    public static string CalculateMedianAverage(List<long> list, bool shouldThrowOnSingleElement)
    {
        var doubleList = CAToNumber.ToNumber(double.Parse, list);
        return CalculateMedianAverage(doubleList, shouldThrowOnSingleElement);
    }

    public static float RoundAndReturnInInputType(float value, int decimalPlaces)
    {
        var roundedValue = Math.Round(value, decimalPlaces).ToString();
        return float.Parse(roundedValue);
    }

    public static byte Last2NumberByte(int year)
    {
        var yearString = year.ToString();
        yearString = yearString.Substring(yearString.Length - 3);
        return byte.Parse(yearString);
    }

    public static double Divide(object dividend, object divisor)
    {
        return double.Parse(dividend.ToString()!) / double.Parse(divisor.ToString()!);
    }

    public static string MakeUpTo2NumbersToZero(byte number)
    {
        var numberString = number.ToString();
        if (numberString.Length == 1)
            return "0" + number;
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
        }

        return lowestValue;
    }

    public static List<byte> GenerateIntervalByte(byte from, byte to)
    {
        var byteIntervalList = new List<byte>();
        for (var currentByte = from; currentByte < to; currentByte++)
            byteIntervalList.Add(currentByte);
        byteIntervalList.Add(to);
        return byteIntervalList;
    }

    public static List<T> Sort<T>(params T[] values)
    {
        var sortableCollection = new List<T>(values);
        sortableCollection.Sort();
        return sortableCollection;
    }

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

    public static string CalculateMedianAverage(List<double> list, bool shouldThrowOnSingleElement)
    {
        MedianAverage<double> medianAverage = null!;
        return CalculateMedianAverage(list, out medianAverage, shouldThrowOnSingleElement);
    }

    public static (string, MedianAverage<double>) CalculateMedianAverageNoOutDouble(List<double> list, bool shouldThrowOnSingleElement)
    {
        MedianAverage<double> medianAverage = null!;
        var calculationResult = CalculateMedianAverage(list, out medianAverage, shouldThrowOnSingleElement);
        return (calculationResult, medianAverage);
    }

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

    public static double Average(double totalValue, double count)
    {
        return Average<double>(totalValue, count);
    }

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
