namespace SunamoNumbers;

/// <summary>
/// Represents the number service type.
/// </summary>
public class NumberService
{
    /// <summary>
    /// Initializes a new instance of the parse interval class.
    /// </summary>
    /// <param name="int?">The int.</param>
    /// <param name="Interval?">The interval.</param>
    public (int?, Interval?)? ParseInterval(string input)
    {
        input = HttpUtility.HtmlDecode(input).Replace(" ", "").RemoveInvisibleChars().RemoveWhitespaceChars();

        var enDash = (char)8211;
        var containsEnDash = input.Contains(enDash);
        if (input.Contains('-') || containsEnDash)
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
            var firstParseSuccess = int.TryParse(new string(firstPartChars), out firstNumber);
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
