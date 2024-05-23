namespace SunamoNumbers;

using System.Text.RegularExpressions;

//namespace SunamoNumbers;

public class SH
{
    //    public static Func<string, string, string, string> ReplaceOnce;
    //    public static Func<string, int[], string> JoinMakeUpTo2NumbersToZero;

    public static string ReplaceOnce(string input, string what, string zaco)
    {
        return new Regex(what).Replace(input, zaco, 1);
    }
}
