// Instance variables refactored according to C# conventions
namespace SunamoNumbers;

public class NumberService
{
    public (int?, Interval?)? ParseInterval(string input)
    {
        input = HttpUtility.HtmlDecode(input).Replace(" ", "").RemoveInvisibleChars().RemoveWhitespaceChars();
        
        // Zkopíroval jsem znak –. Ále ani s ním mi to nevracelo true. Musí to být zapsané jako číslo.
        var enDash = (char)8211;
        var containsEnDash = input.Contains(enDash);
        if (input.Contains("-") || containsEnDash)
        {
            bool isNegative = false;
            if (input[0] == '-')
            {
                isNegative = true;
                input = input.Substring(1);
            }
            int firstNumber = 0;
            uint secondNumber = 0;
            var parts = input.Split('-', enDash);
            var firstPartChars = parts[0].Trim().ToCharArray();
            var firstParseSuccess = int.TryParse(firstPartChars, out firstNumber);
            if (isNegative)
            {
                firstNumber *= -1;
            }
            var secondParseSuccess = uint.TryParse(parts[1].Trim(), out secondNumber);
            if (firstParseSuccess && secondParseSuccess)
            {
                return (null, new Interval { From = firstNumber, To = secondNumber });
            }
            return (null, null);
        }
        else
        {
            if (int.TryParse(input, out var parsedValue))
            {
                return (parsedValue, null);
            }
        }
        return null;
    }
}