// Instance variables refactored according to C# conventions
namespace SunamoNumbers._public.SunamoData;


public class MedianAverage<T>
{
    public T medianValue;
    public T averageValue;
    public T minimumValue;
    public T maximumValue;
    public int elementCount;
    public override string ToString()
    {
        return $"Count: {elementCount}, Median: {medianValue}, Average: {averageValue}, Min: {minimumValue}, Max: {maximumValue}";
    }
}