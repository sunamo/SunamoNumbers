namespace SunamoNumbers;

using System.Text.RegularExpressions;

//namespace SunamoNumbers;

internal class SH
{
    //    internal static Func<string, string, string, string> ReplaceOnce;
    //    internal static Func<string, int[], string> JoinMakeUpTo2NumbersToZero;

    internal static string ReplaceOnce(string input, string what, string zaco)
    {
        return new Regex(what).Replace(input, zaco, 1);
    }
}
