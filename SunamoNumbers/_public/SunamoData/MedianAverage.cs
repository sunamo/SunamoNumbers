namespace SunamoNumbers._public.SunamoData;

public class MedianAverage<T>
{
    public T MedianValue { get; set; } = default!;

    public T AverageValue { get; set; } = default!;

    public T MinimumValue { get; set; } = default!;

    public T MaximumValue { get; set; } = default!;

    public int ElementCount { get; set; }

    public override string ToString()
    {
        return $"Count: {ElementCount}, Median: {MedianValue}, Average: {AverageValue}, Min: {MinimumValue}, Max: {MaximumValue}";
    }
}
