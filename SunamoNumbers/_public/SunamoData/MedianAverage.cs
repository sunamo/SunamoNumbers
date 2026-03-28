namespace SunamoNumbers._public.SunamoData;

/// <summary>
/// Holds median and average statistical values for a collection.
/// </summary>
/// <typeparam name="T">The numeric type of the values.</typeparam>
public class MedianAverage<T>
{
    /// <summary>
    /// Gets or sets the median value.
    /// </summary>
    public T MedianValue { get; set; } = default!;

    /// <summary>
    /// Gets or sets the average value.
    /// </summary>
    public T AverageValue { get; set; } = default!;

    /// <summary>
    /// Gets or sets the minimum value.
    /// </summary>
    public T MinimumValue { get; set; } = default!;

    /// <summary>
    /// Gets or sets the maximum value.
    /// </summary>
    public T MaximumValue { get; set; } = default!;

    /// <summary>
    /// Gets or sets the element count.
    /// </summary>
    public int ElementCount { get; set; }

    /// <summary>
    /// Returns a formatted string representation of the statistical values.
    /// </summary>
    public override string ToString()
    {
        return $"Count: {ElementCount}, Median: {MedianValue}, Average: {AverageValue}, Min: {MinimumValue}, Max: {MaximumValue}";
    }
}
