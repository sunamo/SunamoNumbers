using SunamoNumbers.Tests;

namespace RunnerNumbers;

internal class Program
{
    static void Main()
    {
        NumberServiceTests t = new();
        t.ParseInterval();
    }
}
