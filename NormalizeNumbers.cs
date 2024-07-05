namespace SunamoNumbers;

public static class NormalizeNumbers
{
    static long intMax = int.MaxValue;
    static long one = 1;
    public static uint NormalizeInt(int p)
    {
        //long p2 = (long)p;

        uint nt = (uint)(p + intMax + one);
        //nt++;
        return nt;
    }



    public static ushort NormalizeShort(short p)
    {
        int p2 = p;
        int sm = short.MaxValue;
        ushort nt = (ushort)(p2 + sm + 1);
        //nt++;
        return nt;
    }

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
