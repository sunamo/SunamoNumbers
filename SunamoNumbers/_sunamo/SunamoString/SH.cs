// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
// Instance variables refactored according to C# conventions
namespace SunamoNumbers._sunamo.SunamoString;

internal class SH
{
    //    internal static Func<string, string, string, string> ReplaceOnce;
    //    internal static Func<string, int[], string> JoinMakeUpTo2NumbersToZero;

    internal static string ReplaceOnce(string input, string what, string zaco)
    {
        return new Regex(what).Replace(input, zaco, 1);
    }

}