namespace SunamoNumbers._sunamo.SunamoBts;

/// <summary>
/// Converts collections of values to their numeric representations.
/// </summary>
internal class CAToNumber
{
    /// <summary>
    /// Converts elements of a list to numeric type using the specified parse function.
    /// </summary>
    /// <typeparam name="T">The target numeric type.</typeparam>
    /// <typeparam name="U">The source element type.</typeparam>
    /// <param name="parse">The parse function to convert string to target type.</param>
    /// <param name="list">The source list of elements to convert.</param>
    internal static List<T> ToNumber<T, U>(Func<string, T> parse, IList<U> list)
    {
        var result = new List<T>();
        foreach (var item in list)
        {
            if (item?.ToString() == "NA")
            {
                continue;
            }

            if (double.TryParse(item?.ToString(), out var _))
            {
                var number = parse.Invoke(item!.ToString()!);
                result.Add(number);
            }
        }
        return result;
    }
}
