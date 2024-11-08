namespace SunamoNumbers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Interval
{
    public int From { get; set; }
    public uint To { get; set; }

    public bool IsNumberInRange(int from)
    {
        return From <= from && To >= from;
    }
}