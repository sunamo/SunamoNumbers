namespace SunamoNumbers;

public class MH
{
    /// <summary>
    ///     G nejv�t�� spole�n� d�litel/�initel/faktor (highest common factor)
    /// </summary>
    /// <param name="a">Number a to calculate</param>
    /// <param name="b">Number b to calculate</param>
    /// <returns>The Highest Common Factor of the two numbers</returns>
    /// <remarks>
    ///     I explicitly checked for zero in the parameters
    ///     but decided to not make it throw an exception because
    ///     everyone seems to hate exceptions :).
    /// </remarks>
    public static int HCF(int a, int b)
    {
        if (a == 0 || b == 0)
            return 0;

        // declare our incremental variables
        int highestCommonFactor = 1, currentCounter = 1;

        while (currentCounter <= Math.Min(a, b))
        {
            if (a % currentCounter == 0 && b % currentCounter == 0) highestCommonFactor = currentCounter;

            // increment counter
            currentCounter++;
        }

        // return the highest common factor
        return highestCommonFactor;
    }

    /// <summary>
    ///     Vr�t� nejmen�� spole�n� n�sobek. (lowest common factor)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public static int LCF(int a, int b)
    {
        for (var divisor = 2;; divisor++)
            if (a % divisor == 0 && b % divisor == 0)
                return divisor;
        // Here was originally return 1 but C# compiler marked this as useless
    }
}