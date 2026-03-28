namespace SunamoNumbers._sunamo.SunamoInterfaces.Interfaces;

/// <summary>
/// Interface for generating formatted text output.
/// </summary>
internal interface ITextOutputGenerator
{
    /// <summary>
    /// Appends a bullet-formatted key-value pair.
    /// </summary>
    /// <param name="key">The key text.</param>
    /// <param name="value">The value text.</param>
    void PairBullet(string key, string value);

    /// <summary>
    /// Gets or sets the string to prepend before every non-whitespace entry.
    /// </summary>
    string PrependEveryNoWhite { get; set; }

    /// <summary>
    /// Appends text to the output.
    /// </summary>
    /// <param name="text">The text to append.</param>
    void Append(string text);

    /// <summary>
    /// Appends formatted text to the output.
    /// </summary>
    /// <param name="text">The format string.</param>
    /// <param name="arguments">The format arguments.</param>
    void AppendFormat(string text, params string[] arguments);

    /// <summary>
    /// Appends an empty line to the output.
    /// </summary>
    void AppendLine();

    /// <summary>
    /// Appends a line of text to the output.
    /// </summary>
    /// <param name="text">The text to append.</param>
    void AppendLine(string text);

    /// <summary>
    /// Appends a StringBuilder content as a line.
    /// </summary>
    /// <param name="text">The StringBuilder content to append.</param>
    void AppendLine(StringBuilder text);

    /// <summary>
    /// Appends a formatted line to the output.
    /// </summary>
    /// <param name="text">The format string.</param>
    /// <param name="arguments">The format arguments.</param>
    void AppendLineFormat(string text, params string[] arguments);

    /// <summary>
    /// Counts every key-value pair occurrence.
    /// </summary>
    /// <param name="list">The list of key-value pairs to count.</param>
    void CountEvery<T>(IList<KeyValuePair<T, int>> list);

    /// <summary>
    /// Outputs a dictionary with string keys and int values.
    /// </summary>
    /// <param name="dictionary">The dictionary to output.</param>
    /// <param name="delimiter">The delimiter between entries.</param>
    void Dictionary(Dictionary<string, int> dictionary, string delimiter);

    /// <summary>
    /// Outputs a dictionary with string keys and list values.
    /// </summary>
    /// <param name="dictionary">The dictionary to output.</param>
    void Dictionary(Dictionary<string, List<string>> dictionary);

    /// <summary>
    /// Outputs a dictionary with string key-value pairs.
    /// </summary>
    /// <param name="dictionary">The dictionary to output.</param>
    void Dictionary(Dictionary<string, string> dictionary);

    /// <summary>
    /// Outputs a typed dictionary with list values.
    /// </summary>
    /// <param name="dictionary">The dictionary to output.</param>
    /// <param name="isCountingOnlyInValue">Whether to show only count in values.</param>
    void Dictionary<Header, Value>(Dictionary<Header, List<Value>> dictionary, bool isCountingOnlyInValue = false) where Header : IEnumerable<char>;

    /// <summary>
    /// Outputs a typed dictionary with a custom delimiter.
    /// </summary>
    /// <param name="dictionary">The dictionary to output.</param>
    /// <param name="delimiter">The delimiter between entries.</param>
    void Dictionary<T1, T2>(Dictionary<T1, T2> dictionary, string delimiter = "|") where T1 : notnull;

    /// <summary>
    /// Converts dictionary entries to a single line string.
    /// </summary>
    /// <param name="sorted">The sorted dictionary.</param>
    /// <param name="shouldPutValueFirst">Whether to put the value before the key.</param>
    /// <param name="delimiter">The delimiter between entries.</param>
    string DictionaryBothToStringToSingleLine<Key, Value>(Dictionary<Key, Value> sorted, bool shouldPutValueFirst, string delimiter = " ") where Key : notnull;

    /// <summary>
    /// Outputs ordered key-value pairs with a header.
    /// </summary>
    /// <param name="header">The header text.</param>
    /// <param name="ordered">The ordered enumerable.</param>
    void DictionaryKeyValuePair<T1, T2>(string header, IOrderedEnumerable<KeyValuePair<T1, T2>> ordered);

    /// <summary>
    /// Marks the end of runtime measurement.
    /// </summary>
    void EndRunTime();

    /// <summary>
    /// Appends a header to the output.
    /// </summary>
    /// <param name="text">The header text.</param>
    void Header(string text);

    /// <summary>
    /// Outputs a list of strings.
    /// </summary>
    /// <param name="list">The list to output.</param>
    void List(IList<string> list);

    /// <summary>
    /// Outputs a list of strings with a header.
    /// </summary>
    /// <param name="list">The list to output.</param>
    /// <param name="header">The header text.</param>
    void List(IList<string> list, string header);

    /// <summary>
    /// Outputs a typed list with a header.
    /// </summary>
    /// <param name="list">The list to output.</param>
    /// <param name="header">The header text.</param>
    void List<Header, Value>(IList<Value> list, Header header) where Header : IEnumerable<char>;

    /// <summary>
    /// Outputs a typed list with a header and additional arguments.
    /// </summary>
    /// <param name="list">The list to output.</param>
    /// <param name="header">The header text.</param>
    /// <param name="textOutputGeneratorArgs">Additional arguments for the output generator.</param>
    void List<Header, Value>(IList<Value> list, Header header, object textOutputGeneratorArgs) where Header : IEnumerable<char>;

    /// <summary>
    /// Outputs a typed list with a delimiter.
    /// </summary>
    /// <param name="list">The list to output.</param>
    /// <param name="delimiter">The delimiter between entries.</param>
    /// <param name="whenNoEntries">Text to display when the list is empty.</param>
    void List<Value>(IList<Value> list, string delimiter = "\r\n", string whenNoEntries = "");

    /// <summary>
    /// Outputs a non-generic list.
    /// </summary>
    /// <param name="list">The list to output.</param>
    void ListObject(IList list);

    /// <summary>
    /// Outputs a StringBuilder content as a list item.
    /// </summary>
    /// <param name="onlyStart">The StringBuilder content.</param>
    /// <param name="text">The text to append.</param>
    void ListSB(StringBuilder onlyStart, string text);

    /// <summary>
    /// Outputs a string as a list with a header.
    /// </summary>
    /// <param name="text">The text to output.</param>
    /// <param name="header">The header text.</param>
    void ListString(string text, string header);

    /// <summary>
    /// Outputs a "no data" message.
    /// </summary>
    void NoData();

    /// <summary>
    /// Outputs a paragraph with a header.
    /// </summary>
    /// <param name="text">The paragraph text.</param>
    /// <param name="header">The header text.</param>
    void Paragraph(string text, string header);

    /// <summary>
    /// Outputs a StringBuilder content as a paragraph with a header.
    /// </summary>
    /// <param name="text">The StringBuilder content.</param>
    /// <param name="header">The header text.</param>
    void Paragraph(StringBuilder text, string header);

    /// <summary>
    /// Outputs a line of a single repeated character.
    /// </summary>
    /// <param name="paddingChar">The character to repeat.</param>
    /// <param name="count">The number of repetitions.</param>
    void SingleCharLine(char paddingChar, int count);

    /// <summary>
    /// Marks the start of runtime measurement.
    /// </summary>
    /// <param name="text">The description text.</param>
    void StartRunTime(string text);

    /// <summary>
    /// Returns the generated output as string.
    /// </summary>
    string ToString();

    /// <summary>
    /// Undoes the last operation.
    /// </summary>
    void Undo();
}
