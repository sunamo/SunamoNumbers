namespace SunamoNumbers._sunamo.SunamoExceptions;

/// <summary>
/// Provides methods for throwing standardized exceptions with detailed context.
/// </summary>
internal partial class ThrowEx
{
    /// <summary>
    /// Throws an exception for a not-implemented case.
    /// </summary>
    /// <param name="notImplementedName">The name or type that is not implemented.</param>
    internal static bool NotImplementedCase(object notImplementedName)
    { return ThrowIsNotNull(Exceptions.NotImplementedCase, notImplementedName); }

    /// <summary>
    /// Throws an exception when a collection has only one element.
    /// </summary>
    /// <param name="collectionName">The name of the collection.</param>
    /// <param name="collection">The collection to check.</param>
    internal static bool OnlyOneElement(string collectionName, ICollection collection)
    { return ThrowIsNotNull(Exceptions.OnlyOneElement(FullNameOfExecutedCode(), collectionName, collection)); }

    /// <summary>
    /// Gets the full name of the currently executed code including type and method.
    /// </summary>
    internal static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> placeOfException = Exceptions.PlaceOfException();
        string fullName = FullNameOfExecutedCode(placeOfException.Item1, placeOfException.Item2, true);
        return fullName;
    }

    /// <summary>
    /// Gets the full name of the executed code from a type and method name.
    /// </summary>
    /// <param name="type">The type object, MethodBase, or string representing the type.</param>
    /// <param name="methodName">The method name.</param>
    /// <param name="isFromThrowEx">Whether the call originates from ThrowEx.</param>
    private static string FullNameOfExecutedCode(object type, string methodName, bool isFromThrowEx = false)
    {
        if (methodName is null)
        {
            int depth = 2;
            if (isFromThrowEx)
            {
                depth++;
            }

            methodName = Exceptions.CallingMethod(depth);
        }
        string typeFullName;
        if (type is Type resolvedType)
        {
            typeFullName = resolvedType.FullName ?? "Type cannot be get via type is Type resolvedType";
        }
        else if (type is MethodBase method)
        {
            typeFullName = method.ReflectedType?.FullName ?? "Type cannot be get via type is MethodBase method";
            methodName = method.Name;
        }
        else if (type is string)
        {
            typeFullName = type.ToString() ?? "Type cannot be get via type is string";
        }
        else
        {
            Type objectType = type.GetType();
            typeFullName = objectType.FullName ?? "Type cannot be get via type.GetType()";
        }
        return string.Concat(typeFullName, ".", methodName);
    }

    /// <summary>
    /// Throws an exception if the exception message is not null.
    /// </summary>
    /// <param name="exception">The exception message to check.</param>
    /// <param name="shouldReallyThrow">Whether to actually throw the exception.</param>
    internal static bool ThrowIsNotNull(string? exception, bool shouldReallyThrow = true)
    {
        if (exception is not null)
        {
            Debugger.Break();
            if (shouldReallyThrow)
            {
                throw new Exception(exception);
            }
            return true;
        }
        return false;
    }

    /// <summary>
    /// Evaluates a function with the current execution context and throws if result is not null.
    /// </summary>
    /// <typeparam name="TArgument">The type of the argument.</typeparam>
    /// <param name="exceptionFactory">The function that creates the exception message.</param>
    /// <param name="argument">The argument to pass to the factory.</param>
    internal static bool ThrowIsNotNull<TArgument>(Func<string, TArgument, string?> exceptionFactory, TArgument argument)
    {
        string? exception = exceptionFactory(FullNameOfExecutedCode(), argument);
        return ThrowIsNotNull(exception);
    }
}
