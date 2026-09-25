namespace SunamoNumbers;

/// <summary>
/// Provides methods for generating sequential number lists and ranges.
/// </summary>
public class LinearHelper
{
    /// <summary>
    /// Generates a list of string representations of numbers from the start value to the end value (inclusive).
    /// </summary>
    /// <param name="from">The start value.</param>
    /// <param name="to">The end value (inclusive).</param>
    public static List<string> GetStringListFromTo(int from, int to)
    {
        return GetListFromTo(from, to).ConvertAll(number => number.ToString());
    }

    /// <summary>
    /// Generates a list of integers from the start value to the end value (inclusive).
    /// </summary>
    /// <param name="from">The start value.</param>
    /// <param name="to">The end value (inclusive).</param>
    public static List<int> GetListFromTo(int from, int to)
    {
        var numberList = new List<int>();
        to++;
        for (; from < to; from++) numberList.Add(from);

        return numberList;
    }

    /// <summary>
    /// Generates a typed list of numbers from the start value to the end value (inclusive).
    /// </summary>
    /// <typeparam name="T">The target numeric type.</typeparam>
    /// <param name="from">The start value.</param>
    /// <param name="to">The end value (inclusive).</param>
    public static List<T> GetListFromTo<T>(int from, int to)
    {
        var stringList = GetStringListFromTo(from, to);

        var parseFunction = (Func<string, T>)BTS.MethodForParse<T>();
        var resultList = CAToNumber.ToNumber(parseFunction, stringList);
        return resultList;
    }
}
