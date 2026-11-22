namespace SunamoNumbers;

/// <summary>
/// Represents the low high helper type.
/// </summary>
public class LowHighHelper
{
    private int minimum = int.MaxValue;
    private int maximum = int.MinValue;

    /// <summary>
    /// Set.
    /// </summary>
    /// <param name="value">The value.</param>
    public void Set(int value)
    {
        if (value < minimum) minimum = value;

        if (value > maximum) maximum = value;
    }
}
