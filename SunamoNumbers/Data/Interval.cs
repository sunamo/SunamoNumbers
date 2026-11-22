namespace SunamoNumbers.Data;

/// <summary>
/// Represents the interval type.
/// </summary>
public class Interval
{
    /// <summary>
    /// Gets or sets the from.
    /// </summary>
    public int From { get; set; }

    /// <summary>
    /// Gets or sets the to.
    /// </summary>
    public uint To { get; set; }

    /// <summary>
    /// Is number in range.
    /// </summary>
    /// <param name="numberToCheck">The number to check.</param>
    /// <returns>The is number in range result.</returns>
    public bool IsNumberInRange(int numberToCheck)
    {
        return From <= numberToCheck && To >= numberToCheck;
    }
}
