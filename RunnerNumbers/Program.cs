using SunamoNumbers.Tests;

namespace RunnerNumbers;

/// <summary>
/// Runner entry point for executing NumberService tests.
/// </summary>
internal class Program
{
    static void Main()
    {
        NumberServiceTests t = new();
        t.ParseInterval();
    }
}
