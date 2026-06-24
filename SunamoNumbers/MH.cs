namespace SunamoNumbers;

// Math Helper - provides greatest common factor and lowest common factor calculations.
public class MH
{
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

    public static int LCF(int firstNumber, int secondNumber)
    {
        for (var divisor = 2; ; divisor++)
            if (firstNumber % divisor == 0 && secondNumber % divisor == 0)
                return divisor;
    }
}
