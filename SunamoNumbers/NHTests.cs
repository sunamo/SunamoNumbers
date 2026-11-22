namespace SunamoNumbers;

using Xunit;

/// <summary>
/// Represents the NH tests type.
/// </summary>
public class NHTests
{
    /// <summary>
    /// The test input.
    /// </summary>
    public static readonly List<int> TestInput = [4, 0];

    /// <summary>
    /// The test input 3.
    /// </summary>
    public static readonly List<int> TestInput3 = [4, 4, 250, 500, 500];

    /// <summary>
    /// The test input 4.
    /// </summary>
    public static readonly List<int> TestInput4 = [4, 4, 250, 500, 500];

    /// <summary>
    /// The test input 5.
    /// </summary>
    public static readonly List<int> TestInput5 = [4, 4, 4, 4, 250, 500, 500];

    /// <summary>
    /// The test input 2.
    /// </summary>
    public static readonly List<double> TestInput2 = [-5, -4, 7.5, 8.7, 3.4, 9.4, 0.8, 1.5, 2.6, 0.9, 0.6, 9.4, 8.4, 6.6, 9.4];

    /// <summary>
    /// Represents the int type.
    /// </summary>
    public class Int
    {
        /// <summary>
        /// Median test.
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
        /// Median 2 test.
        /// </summary>
        /// <returns>The median 2 test result.</returns>
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
    /// Represents the double type.
    /// </summary>
    public class Double
    {
        /// <summary>
        /// Median test.
        /// </summary>
        /// <typeparam name="int">The type int.</typeparam>
        /// <param name="TestInput">The test input.</param>
        /// <returns>The median test result.</returns>
        [Fact]
        public void MedianTest()
        {
            var medianResult = NH.Median<double>(TestInput2);

            Assert.Equal(3.4, medianResult);
        }

        /// <summary>
        /// Initializes a new instance of the median 2 test class.
        /// </summary>
        /// <param name="4">The 4.</param>
        /// <param name="medianResult5">The median result 5.</param>
        [Fact]
        public void Median2Test()
        {
            var medianResult = NH.Median2<double>(TestInput2);

            Assert.Equal(3.4, medianResult);
        }
    }
}
