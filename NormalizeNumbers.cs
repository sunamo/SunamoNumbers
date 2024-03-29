namespace SunamoNumbers;

public static partial class NormalizeNumbers
{
    public static ulong NormalizeLong(long p)
    {
        decimal p2 = p;
        decimal sm = long.MaxValue;
        ulong nt = (ulong)(p2 + sm + 1m);
        //nt++;
        return nt;
    }

    public static uint BytesToMegabytes(int size)
    {
        uint normalized = NormalizeInt(size);
        normalized /= 1024;
        normalized /= 1024;
        return normalized;
    }
}
