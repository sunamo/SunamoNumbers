namespace SunamoNumbers;

public class LowHighHelper
{
    private int low = int.MaxValue;
    private int max = int.MinValue;

    public void Set(int t)
    {
        if (t < low) low = t;

        if (t > max) max = t;
    }

#if DEBUG2
    public void PrintDebug()
    {
        DebugLogger.Instance.WriteLine("Low: ", low);
        DebugLogger.Instance.WriteLine("High: ", max);
    }
#endif
}