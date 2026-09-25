namespace SunamoNumbers.Data;

/// <summary>
/// Represents a numeric interval with a signed lower bound and an unsigned upper bound.
/// </summary>
public class Interval
{
    /// <summary>
    /// Gets or sets the lower bound of the interval.
    /// </summary>
    public int From { get; set; }

    /// <summary>
    /// Gets or sets the upper bound of the interval.
    /// </summary>
    public uint To { get; set; }

    /// <summary>
    /// Determines whether the specified number falls within this interval (inclusive).
    /// </summary>
    /// <param name="numberToCheck">The number to check.</param>
    public bool IsNumberInRange(int numberToCheck)
    {
        return From <= numberToCheck && To >= numberToCheck;
    }
}
