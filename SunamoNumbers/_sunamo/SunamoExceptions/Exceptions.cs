namespace SunamoNumbers._sunamo.SunamoExceptions;

internal sealed partial class Exceptions
{
    internal static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? string.Empty : before + ": ";
    }

    internal static Tuple<string, string, string> PlaceOfException(bool shouldFillFirstTwo = true)
    {
        StackTrace stackTrace = new();
        var stackTraceText = stackTrace.ToString();
        var lines = stackTraceText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.RemoveAt(0);
        var index = 0;
        string type = string.Empty;
        string methodName = string.Empty;
        for (; index < lines.Count; index++)
        {
            var line = lines[index];
            if (shouldFillFirstTwo)
                if (!line.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(line, out type, out methodName);
                    shouldFillFirstTwo = false;
                }
            if (line.StartsWith("at System."))
            {
                lines.Add(string.Empty);
                lines.Add(string.Empty);
                break;
            }
        }
        return new Tuple<string, string, string>(type, methodName, string.Join(Environment.NewLine, lines));
    }

    internal static void TypeAndMethodName(string line, out string type, out string methodName)
    {
        var frameText = line.Split(new[] { "at " }, StringSplitOptions.None)[1].Trim();
        var fullMethodPath = frameText.Split('(')[0];
        var pathParts = fullMethodPath.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = pathParts[^1];
        pathParts.RemoveAt(pathParts.Count - 1);
        type = string.Join(".", pathParts);
    }

    internal static string CallingMethod(int depth = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(depth)?.GetMethod();
        if (methodBase is null)
        {
            return "Method name cannot be get";
        }
        var methodName = methodBase.Name;
        return methodName;
    }

    internal static string? OnlyOneElement(string before, string collectionName, ICollection collection)
    {
        return collection.Count == 1 ? CheckBefore(before) + collectionName + " has only one element" : null;
    }

    internal static string? NotImplementedCase(string before, object notImplementedName)
    {
        var forClause = string.Empty;
        if (notImplementedName is not null)
        {
            forClause = " for ";
            if (notImplementedName.GetType() == typeof(Type))
                forClause += ((Type)notImplementedName).FullName;
            else
                forClause += notImplementedName.ToString();
        }
        return CheckBefore(before) + "Not implemented case" + forClause + " . internal program error. Please contact developer" +
        ".";
    }
}
