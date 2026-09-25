namespace SunamoNumbers;

using Xunit;

public class NHTests
{
    public static readonly List<int> TestInput = [4, 0];

    public static readonly List<int> TestInput3 = [4, 4, 250, 500, 500];

    public static readonly List<int> TestInput4 = [4, 4, 250, 500, 500];

    public static readonly List<int> TestInput5 = [4, 4, 4, 4, 250, 500, 500];

    public static readonly List<double> TestInput2 = [-5, -4, 7.5, 8.7, 3.4, 9.4, 0.8, 1.5, 2.6, 0.9, 0.6, 9.4, 8.4, 6.6, 9.4];

    public class Int
    {
        [Fact]
        public void MedianTest()
        {
            var medianResult = NH.Median<int>(TestInput);
            var medianResult3 = NH.Median<int>(TestInput3);
            var medianResult4 = NH.Median<int>(TestInput4);
            var medianResult5 = NH.Median<int>(TestInput5);

            Assert.Equal(0, medianResult);
            Assert.Equal(250, medianResult3);
            Assert.Equal(250, medianResult4);
            Assert.Equal(4, medianResult5);
        }

        [Fact]
        public void Median2Test()
        {
            var medianResult = NH.Median2<int>(TestInput);
            var medianResult3 = NH.Median2<int>(TestInput3);
            var medianResult4 = NH.Median2<int>(TestInput4);
            var medianResult5 = NH.Median2<int>(TestInput5);

            Assert.Equal(2, medianResult);
            Assert.Equal(250, medianResult3);
            Assert.Equal(250, medianResult4);
            Assert.Equal(4, medianResult5);
        }
    }

    public class Double
    {
        [Fact]
        public void MedianTest()
        {
            var medianResult = NH.Median<double>(TestInput2);

            Assert.Equal(3.4, medianResult);
        }

        [Fact]
        public void Median2Test()
        {
            var medianResult = NH.Median2<double>(TestInput2);

            Assert.Equal(3.4, medianResult);
        }
    }
}
