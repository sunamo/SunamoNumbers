namespace SunamoNumbers._sunamo.SunamoExceptions;

/// <summary>
/// Provides exception message formatting and stack trace analysis utilities.
/// </summary>
internal sealed partial class Exceptions
{
    /// <summary>
    /// Checks and formats a prefix string for exception messages.
    /// </summary>
    /// <param name="before">The prefix to check.</param>
    internal static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? string.Empty : before + ": ";
    }

    /// <summary>
    /// Extracts the type, method name, and full stack trace from the current call stack.
    /// </summary>
    /// <param name="shouldFillFirstTwo">Whether to also extract the type and method name from the first non-ThrowEx frame.</param>
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

    /// <summary>
    /// Extracts the type and method name from a stack trace line.
    /// </summary>
    /// <param name="line">The stack trace line to parse.</param>
    /// <param name="type">The extracted type name.</param>
    /// <param name="methodName">The extracted method name.</param>
    internal static void TypeAndMethodName(string line, out string type, out string methodName)
    {
        var frameText = line.Split(new[] { "at " }, StringSplitOptions.None)[1].Trim();
        var fullMethodPath = frameText.Split('(')[0];
        var pathParts = fullMethodPath.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = pathParts[^1];
        pathParts.RemoveAt(pathParts.Count - 1);
        type = string.Join(".", pathParts);
    }

    /// <summary>
    /// Gets the name of the calling method at the specified stack depth.
    /// </summary>
    /// <param name="depth">The stack frame depth.</param>
    internal static string CallingMethod(int depth = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(depth)?.GetMethod();
        if (methodBase == null)
        {
            return "Method name cannot be get";
        }
        var methodName = methodBase.Name;
        return methodName;
    }

    /// <summary>
    /// Creates an error message when a collection has only one element.
    /// </summary>
    /// <param name="before">The prefix for the message.</param>
    /// <param name="collectionName">The name of the collection.</param>
    /// <param name="collection">The collection to check.</param>
    internal static string? OnlyOneElement(string before, string collectionName, ICollection collection)
    {
        return collection.Count == 1 ? CheckBefore(before) + collectionName + " has only one element" : null;
    }

    /// <summary>
    /// Creates an error message for a not-implemented case.
    /// </summary>
    /// <param name="before">The prefix for the message.</param>
    /// <param name="notImplementedName">The name or type that is not implemented.</param>
    internal static string? NotImplementedCase(string before, object notImplementedName)
    {
        var forClause = string.Empty;
        if (notImplementedName != null)
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
