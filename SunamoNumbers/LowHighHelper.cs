namespace SunamoNumbers;

/// <summary>
/// Tracks the minimum and maximum integer values encountered.
/// </summary>
public class LowHighHelper
{
    private int minimum = int.MaxValue;
    private int maximum = int.MinValue;

    /// <summary>
    /// Updates the minimum and maximum tracked values with the given value.
    /// </summary>
    /// <param name="value">The value to compare against current minimum and maximum.</param>
    public void Set(int value)
    {
        if (value < minimum) minimum = value;

        if (value > maximum) maximum = value;
    }
}
