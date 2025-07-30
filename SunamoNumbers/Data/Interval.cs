namespace SunamoNumbers.Data;

public class Interval
{
    public int From { get; set; }
    public uint To { get; set; }
    public bool IsNumberInRange(int from)
    {
        return From <= from && To >= from;
    }
}