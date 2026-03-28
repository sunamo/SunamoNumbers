namespace SunamoNumbers.Tests;

/// <summary>
/// Tests for the NumberService class.
/// </summary>
public class NumberServiceTests
{
    /// <summary>
    /// Tests that ParseInterval correctly parses interval and single value inputs.
    /// </summary>
    [Fact]
    public void ParseInterval()
    {
        NumberService numberService = new NumberService();

        var intervalResult = numberService.ParseInterval("120 000 ‍–‍ 150 000");
        var singleValueResult = numberService.ParseInterval("150 000");

        Assert.NotNull(intervalResult);
        Assert.NotNull(intervalResult.Value.Item2);
        Assert.Equal(120000, intervalResult.Value.Item2!.From);
        Assert.Equal(150000u, intervalResult.Value.Item2!.To);

        Assert.NotNull(singleValueResult);
        Assert.Equal(150000, singleValueResult.Value.Item1);

        var isOutOfRangeHigh = intervalResult.Value.Item2.IsNumberInRange(200000);
        var isOutOfRangeLow = intervalResult.Value.Item2.IsNumberInRange(100000);
        var isInRange = intervalResult.Value.Item2.IsNumberInRange(150000);

        Assert.False(isOutOfRangeHigh);
        Assert.False(isOutOfRangeLow);
        Assert.True(isInRange);
    }
}
