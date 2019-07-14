using System;
using System.Collections.Generic;
using System.Linq;

class WithIndex<T>
{
    public T Value;
    public int Index;
}

static class EnumerableExtension
{
    public static IEnumerable<WithIndex<T>> WithIndex<T>(this IEnumerable<T> sequence)
    {
        var index = 0;
        foreach (var item in sequence)
        {
            var withIndex = new WithIndex<T>();
            withIndex.Value = item;
            withIndex.Index = index;
            yield return withIndex;
            index++;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var firstLine = Console.ReadLine()
            .Split(' ')
            .Select(s => int.Parse(s))
            .ToArray();
        var candidatorCount = firstLine[0];
        var voterCount = firstLine[1];
        var speechCount = firstLine[2];
        var speechedCandidatorIndexes = new int[speechCount];
        foreach (var i in Enumerable.Range(0, speechCount))
        {
            speechedCandidatorIndexes[i] = int.Parse(Console.ReadLine());
        }
        //
        var supportCounts = new int[candidatorCount];
        var nonSupportorCount = voterCount;
        foreach (var i in Enumerable.Range(0, speechCount))
        {
            var candidatorIndex = speechedCandidatorIndexes[i] - 1;
            foreach (var supportorIndex in Enumerable.Range(0, candidatorCount))
            {
                if (supportorIndex == candidatorIndex) continue;
                if (supportCounts[supportorIndex] > 0)
                {
                    supportCounts[supportorIndex]--;
                    supportCounts[candidatorIndex]++;
                }
                if (nonSupportorCount > 0)
                {
                    nonSupportorCount--;
                    supportCounts[candidatorIndex]++;
                }
            }
        }
        //
        var mostSupportedCount = supportCounts.Max();
        var mostSupportedCandidators = supportCounts
            .WithIndex()
            .Where(it => supportCounts[it.Index] == mostSupportedCount)
            .Select(it => it.Index + 1)
            .OrderBy(it => it);
        foreach (var mostSupportedIndex in mostSupportedCandidators)
        {
            Console.WriteLine(mostSupportedIndex);
        }
    }
}
