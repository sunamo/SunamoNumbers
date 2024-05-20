using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoNumbers;
internal static class ListExtensions
{
    public static void Swap<T>(this IList<T> list, int dx1, int dx2)
    {
        if (dx1 == dx2)   //This check is not required but Partition function may make many calls so its for perf reason
            return;
        var temp = list[dx1];
        list[dx1] = list[dx2];
        list[dx2] = temp;
    }
    public static int Partition<T>(this IList<T> list, int start, int end, Random rnd = null) where T : IComparable<T>
    {
        if (rnd != null)
            list.Swap(end, rnd.Next(start, end + 1));
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

    public static T NthOrderStatistic<T>(this IList<T> list, int n, Random rnd = null) where T : IComparable<T>
    {
        return NthOrderStatistic(list, n, 0, list.Count - 1, rnd);
    }
    private static T NthOrderStatistic<T>(this IList<T> list, int n, int start, int end, Random rnd) where T : IComparable<T>
    {
        while (true)
        {
            var pivotIndex = list.Partition(start, end, rnd);
            if (pivotIndex == n)
                return list[pivotIndex];
            if (n < pivotIndex)
                end = pivotIndex - 1;
            else
                start = pivotIndex + 1;
        }
    }
}
