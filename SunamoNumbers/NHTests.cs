// Instance variables refactored according to C# conventions
using Xunit;

namespace sunamo.Tests.Helpers.Numbers;
public class NHTests
{
    public readonly static List<int> testInput = [4, 0];// 4, 4, 4, 3, 0, 0, 0, 0);
    public readonly static List<int> testInput3 = [4, 4, 250, 500, 500];
    public readonly static List<int> testInput4 = [4, 4, 250, 500, 500];
    public readonly static List<int> testInput5 = [4, 4, 4, 4, 250, 500, 500];
    public readonly static List<double> testInput2 = [-5, -4, 7.5, 8.7, 3.4, 9.4, 0.8, 1.5, 2.6, 0.9, 0.6, 9.4, 8.4, 6.6, 9.4];

    public class Int
    {
        //3
        [Fact]
        public void MedianTest()
        {
            var medianResult = NH.Median<int>(testInput);
            var medianResult3 = NH.Median<int>(testInput3);
            var medianResult4 = NH.Median<int>(testInput4);
            var medianResult5 = NH.Median<int>(testInput5);
            ////DebugLogger.Instance.WriteLine(medianResult);
        }

        // 3
        [Fact]
        public void Median2Test()
        {
            var medianResult = NH.Median2<int>(testInput);
            //var medianResult2 = NH.Median2<int>(testInput2);
            var medianResult3 = NH.Median2<int>(testInput3);
            var medianResult4 = NH.Median2<int>(testInput4);
            var medianResult5 = NH.Median2<int>(testInput5);
            ////DebugLogger.Instance.WriteLine(medianResult);
        }
    }
    public class Double
    {
        //3.4
        [Fact]
        public void MedianTest()
        {
            var medianResult = NH.Median<double>(testInput2);
            ////DebugLogger.Instance.WriteLine(medianResult);
        }

        // 3.4
        [Fact]
        public void Median2Test()
        {
            var medianResult = NH.Median2<double>(testInput2);
            ////DebugLogger.Instance.WriteLine(medianResult);
        }
    }

}
