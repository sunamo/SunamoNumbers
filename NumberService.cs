namespace SunamoNumbers;

using SunamoNumbers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NumberService
{
    public (int?, Interval?)? ParseInterval(string input)
    {
        input = input.Replace("&nbsp;", "").Replace(" ", "").RemoveInvisibleChars();
        // Zkopíroval jsem znak –. Ále ani s ním mi to nevracelo true. Musí to být zapsané jako číslo.
        var enDash = (char)8211;

        var b = input.Contains(enDash);
        if (input.Contains("-") || b)
        {
            bool isNeg = false;
            if (input[0] == '-')
            {
                isNeg = true;
                input = input.Substring(1);
            }

            int first = 0;
            uint second = 0;

            var p = input.Split('-', enDash);
            var tp = p[0].Trim().ToCharArray();


            var b1 = int.TryParse(tp, out first);
            var b2 = uint.TryParse(p[1].Trim(), out second);
            if (b1 && b2)
            {
                return (null, new Interval { From = first, To = second });
            }
            return (null, null);
        }
        else
        {
            if (int.TryParse(input, out var val))
            {
                return (val, null);
            }
        }

        return null;
    }
}