namespace SunamoNumbers;

public class LowHighHelper
{
    private int minimum = int.MaxValue;
    private int maximum = int.MinValue;

    public void Set(int value)
    {
        if (value < minimum) minimum = value;

        if (value > maximum) maximum = value;
    }
}
