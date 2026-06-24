namespace SunamoNumbers._sunamo.SunamoExtensions;

internal static class ListExtensions
{
    internal static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex)
    {
        if (firstIndex == secondIndex)
            return;
        var storedValue = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = storedValue;
    }

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

    internal static T NthOrderStatistic<T>(this IList<T> list, int targetIndex, Random? random = null) where T : IComparable<T>
    {
        return NthOrderStatistic(list, targetIndex, 0, list.Count - 1, random);
    }

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
