namespace SunamoNumbers;

public class LinearHelper
{
    /// <summary>
    ///     Do A2 zadej číslo do kterého se bude počítat včetně.
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    public static List<string> GetStringListFromTo(int from, int to)
    {
        return GetListFromTo(from, to).ConvertAll(number => number.ToString());
    }

    public static List<int> GetListFromTo(int from, int to)
    {
        var numberList = new List<int>();
        to++;
        for (; from < to; from++) numberList.Add(from);

        return numberList;
    }

    public static List<T> GetListFromTo<T>(int from, int to)
    {
        var stringList = GetStringListFromTo(from, to);



        var parseFunction = (Func<string, T>)BTS.MethodForParse<T>();
        var resultList = CAToNumber.ToNumber(parseFunction, stringList);
        return resultList;
    }
}