namespace SunamoNumbers._sunamo.SunamoInterfaces.Interfaces;

internal interface ITextOutputGenerator
{
    void PairBullet(string key, string value);

    string PrependEveryNoWhite { get; set; }

    void Append(string text);

    void AppendFormat(string text, params string[] arguments);

    void AppendLine();

    void AppendLine(string text);

    void AppendLine(StringBuilder text);

    void AppendLineFormat(string text, params string[] arguments);

    void CountEvery<T>(IList<KeyValuePair<T, int>> list);

    void Dictionary(Dictionary<string, int> dictionary, string delimiter);

    void Dictionary(Dictionary<string, List<string>> dictionary);

    void Dictionary(Dictionary<string, string> dictionary);

    void Dictionary<Header, Value>(Dictionary<Header, List<Value>> dictionary, bool isCountingOnlyInValue = false) where Header : IEnumerable<char>;

    void Dictionary<T1, T2>(Dictionary<T1, T2> dictionary, string delimiter = "|") where T1 : notnull;

    string DictionaryBothToStringToSingleLine<Key, Value>(Dictionary<Key, Value> sorted, bool shouldPutValueFirst, string delimiter = " ") where Key : notnull;

    void DictionaryKeyValuePair<T1, T2>(string header, IOrderedEnumerable<KeyValuePair<T1, T2>> ordered);

    void EndRunTime();

    void Header(string text);

    void List(IList<string> list);

    void List(IList<string> list, string header);

    void List<Header, Value>(IList<Value> list, Header header) where Header : IEnumerable<char>;

    void List<Header, Value>(IList<Value> list, Header header, object textOutputGeneratorArgs) where Header : IEnumerable<char>;

    void List<Value>(IList<Value> list, string delimiter = "\r\n", string whenNoEntries = "");

    void ListObject(IList list);

    void ListSB(StringBuilder onlyStart, string text);

    void ListString(string text, string header);

    void NoData();

    void Paragraph(string text, string header);

    void Paragraph(StringBuilder text, string header);

    void SingleCharLine(char paddingChar, int count);

    void StartRunTime(string text);

    string ToString();

    void Undo();
}
