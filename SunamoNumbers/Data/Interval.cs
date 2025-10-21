// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
// Instance variables refactored according to C# conventions
namespace SunamoNumbers.Data;

public class Interval
{
    public int From { get; set; }
    public uint To { get; set; }
    public bool IsNumberInRange(int numberToCheck)
    {
        return From <= numberToCheck && To >= numberToCheck;
    }
}