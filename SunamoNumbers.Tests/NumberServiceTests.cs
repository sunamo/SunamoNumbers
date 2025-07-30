namespace SunamoNumbers.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NumberServiceTests
{
    //
    [Fact]
    public void ParseInterval()
    {
        //6
        NumberService numberService = new SunamoNumbers.NumberService();

        var d = numberService.ParseInterval("120 000 ‍–‍ 150 000");
        var r = numberService.ParseInterval("150 000");

        var a = d.Value.Item2.IsNumberInRange(200000);
        var b = d.Value.Item2.IsNumberInRange(100000);
        var c = d.Value.Item2.IsNumberInRange(150000);
    }
}