namespace SunamoNumbers._sunamo.SunamoExtensions;

/// <summary>
/// Provides extension methods for list operations including partitioning and order statistics.
/// </summary>
internal static class ListExtensions
{
    /// <summary>
    /// Swaps two elements in the list at the specified indices.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="list">The list to swap elements in.</param>
    /// <param name="firstIndex">The index of the first element.</param>
    /// <param name="secondIndex">The index of the second element.</param>
    internal static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex)
    {
        if (firstIndex == secondIndex)
            return;
        var storedValue = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = storedValue;
    }

    /// <summary>
    /// Partitions the list around a pivot element using the Lomuto partition scheme.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="list">The list to partition.</param>
    /// <param name="start">The start index of the partition range.</param>
    /// <param name="end">The end index of the partition range.</param>
    /// <param name="random">Optional random number generator for pivot selection.</param>
    internal static int Partition<T>(this IList<T> list, int start, int end, Random? random = null) where T : IComparable<T>
    {
        if (random is not null)
            list.Swap(end, random.Next(start, end + 1));
        var pivot = list[end];
        var lastLow = start - 1;
        for (var i = start; i < end; i++)
        {
            if (list[i].CompareTo(pivot) <= 0)
                list.Swap(i, ++lastLow);
        }
        list.Swap(end, ++lastLow);
        return lastLow;
    }

    /// <summary>
    /// Finds the nth order statistic (nth smallest element) in the list.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="list">The list to search.</param>
    /// <param name="targetIndex">The target order index.</param>
    /// <param name="random">Optional random number generator for pivot selection.</param>
    internal static T NthOrderStatistic<T>(this IList<T> list, int targetIndex, Random? random = null) where T : IComparable<T>
    {
        return NthOrderStatistic(list, targetIndex, 0, list.Count - 1, random);
    }

    /// <summary>
    /// Recursive implementation of nth order statistic using quickselect algorithm.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="list">The list to search.</param>
    /// <param name="targetIndex">The target order index.</param>
    /// <param name="start">The start index of the search range.</param>
    /// <param name="end">The end index of the search range.</param>
    /// <param name="random">Optional random number generator for pivot selection.</param>
    private static T NthOrderStatistic<T>(this IList<T> list, int targetIndex, int start, int end, Random? random) where T : IComparable<T>
    {
        while (true)
        {
            var pivotIndex = list.Partition(start, end, random);
            if (pivotIndex == targetIndex)
                return list[pivotIndex];
            if (targetIndex < pivotIndex)
                end = pivotIndex - 1;
            else
                start = pivotIndex + 1;
        }
    }
}
