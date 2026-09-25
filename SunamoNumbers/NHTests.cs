namespace SunamoNumbers;

using Xunit;

/// <summary>
/// Tests for NH class median calculations.
/// </summary>
public class NHTests
{
    /// <summary>
    /// Test input with two elements including zero.
    /// </summary>
    public static readonly List<int> TestInput = [4, 0];

    /// <summary>
    /// Test input with five elements for median calculation.
    /// </summary>
    public static readonly List<int> TestInput3 = [4, 4, 250, 500, 500];

    /// <summary>
    /// Duplicate of TestInput3 for comparison testing.
    /// </summary>
    public static readonly List<int> TestInput4 = [4, 4, 250, 500, 500];

    /// <summary>
    /// Test input with seven elements where 4 is the most frequent.
    /// </summary>
    public static readonly List<int> TestInput5 = [4, 4, 4, 4, 250, 500, 500];

    /// <summary>
    /// Test input with double values including negatives.
    /// </summary>
    public static readonly List<double> TestInput2 = [-5, -4, 7.5, 8.7, 3.4, 9.4, 0.8, 1.5, 2.6, 0.9, 0.6, 9.4, 8.4, 6.6, 9.4];

    /// <summary>
    /// Tests for integer median calculations.
    /// </summary>
    public class Int
    {
        /// <summary>
        /// Tests Median method with various integer inputs.
        /// </summary>
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

        /// <summary>
        /// Tests Median2 method with various integer inputs.
        /// </summary>
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

    /// <summary>
    /// Tests for double median calculations.
    /// </summary>
    public class Double
    {
        /// <summary>
        /// Tests Median method with double input values.
        /// </summary>
        [Fact]
        public void MedianTest()
        {
            var medianResult = NH.Median<double>(TestInput2);

            Assert.Equal(3.4, medianResult);
        }

        /// <summary>
        /// Tests Median2 method with double input values.
        /// </summary>
        [Fact]
        public void Median2Test()
        {
            var medianResult = NH.Median2<double>(TestInput2);

            Assert.Equal(3.4, medianResult);
        }
    }
}
