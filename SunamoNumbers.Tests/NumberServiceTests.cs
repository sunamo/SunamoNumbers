// Instance variables refactored according to C# conventions
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

        var intervalResult = numberService.ParseInterval("120 000 ‍–‍ 150 000");
        var singleValueResult = numberService.ParseInterval("150 000");

        var isOutOfRangeHigh = intervalResult.Value.Item2.IsNumberInRange(200000);
        var isOutOfRangeLow = intervalResult.Value.Item2.IsNumberInRange(100000);
        var isInRange = intervalResult.Value.Item2.IsNumberInRange(150000);
    }
}