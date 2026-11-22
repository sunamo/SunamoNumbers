namespace SunamoNumbers;

/// <summary>
/// Represents the linear helper type.
/// </summary>
public class LinearHelper
{
    /// <summary>
    /// Get string list from to.
    /// </summary>
    /// <param name="from">The from.</param>
    /// <param name="to">The to.</param>
    /// <returns>The get string list from to result.</returns>
    public static List<string> GetStringListFromTo(int from, int to)
    {
        return GetListFromTo(from, to).ConvertAll(number => number.ToString());
    }

    /// <summary>
    /// Get list from to.
    /// </summary>
    /// <param name="from">The from.</param>
    /// <param name="to">The to.</param>
    /// <returns>The get list from to result.</returns>
    public static List<int> GetListFromTo(int from, int to)
    {
        var numberList = new List<int>();
        to++;
        for (; from < to; from++) numberList.Add(from);

        return numberList;
    }

    /// <summary>
    /// Get list from to t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="from">The from.</param>
    /// <param name="to">The to.</param>
    /// <returns>The get list from to t result.</returns>
    public static List<T> GetListFromTo<T>(int from, int to)
    {
        var stringList = GetStringListFromTo(from, to);

        var parseFunction = (Func<string, T>)BTS.MethodForParse<T>();
        var resultList = CAToNumber.ToNumber(parseFunction, stringList);
        return resultList;
    }
}
