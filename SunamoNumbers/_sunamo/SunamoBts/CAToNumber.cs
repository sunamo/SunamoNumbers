namespace SunamoNumbers._sunamo.SunamoBts;

internal class CAToNumber
{
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
