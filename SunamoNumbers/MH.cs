namespace SunamoNumbers;

/// <summary>
/// Math Helper - provides greatest common factor and lowest common factor calculations.
/// </summary>
public class MH
{
    /// <summary>
    /// Calculates the Highest Common Factor (Greatest Common Divisor) of two numbers.
    /// </summary>
    /// <param name="firstNumber">The first number.</param>
    /// <param name="secondNumber">The second number.</param>
    /// <returns>The highest common factor of the two numbers, or 0 if either number is 0.</returns>
    public static int HCF(int firstNumber, int secondNumber)
    {
        if (firstNumber == 0 || secondNumber == 0)
            return 0;

        int highestCommonFactor = 1, currentCounter = 1;

        while (currentCounter <= Math.Min(firstNumber, secondNumber))
        {
            if (firstNumber % currentCounter == 0 && secondNumber % currentCounter == 0) highestCommonFactor = currentCounter;

            currentCounter++;
        }

        return highestCommonFactor;
    }

    /// <summary>
    /// Calculates the Lowest Common Factor (smallest prime factor that divides both numbers).
    /// </summary>
    /// <param name="firstNumber">The first number.</param>
    /// <param name="secondNumber">The second number.</param>
    public static int LCF(int firstNumber, int secondNumber)
    {
        for (var divisor = 2; ; divisor++)
            if (firstNumber % divisor == 0 && secondNumber % divisor == 0)
                return divisor;
    }
}
