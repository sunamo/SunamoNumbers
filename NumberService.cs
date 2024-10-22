namespace SunamoNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class NumberService
{
    public (uint, uint)? ParseInterval(string input)
    {
        if (input.Contains("-"))
        {
            var p = input.Split('-');
            uint.TryParse(p[0], out var first);
            uint.TryParse(p[1], out var second);

            return (first, second);
        }

        return null;
    }
}