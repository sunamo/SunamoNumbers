// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
// Instance variables refactored according to C# conventions
namespace SunamoNumbers._sunamo.SunamoBts;

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

            if (double.TryParse(item.ToString(), out var _) /*SH.IsNumber(item.ToString(), new Char[] { ',', '.', '-' })*/)
            {
                var number = parse.Invoke(item.ToString());

                result.Add(number);
            }
        }
        return result;
    }
}
