namespace SunamoNumbers._sunamo;
internal class CAToNumber
{
    internal static List<T> ToNumber<T, U>(Func<string, T> parse, IList<U> enumerable)
    {
        List<T> result = new List<T>();
        foreach (var item in enumerable)
        {
            if (item.ToString() == "NA")
            {
                continue;
            }

            if (double.TryParse(item.ToString(), out var _) /*SHSH.IsNumber(item.ToString(), new Char[] { AllChars.comma, AllChars.dot, AllChars.dash })*/)
            {
                var number = parse.Invoke(item.ToString());

                result.Add(number);
            }
        }
        return result;
    }
}
