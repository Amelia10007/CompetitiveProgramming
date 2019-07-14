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
        int index = 0;
        foreach (var item in sequence)
        {
            var withIndex = new WithIndex<T>
            {
                Value = item,
                Index = index
            };
            yield return withIndex;
            index++;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var cardCount = int.Parse(Console.ReadLine());
        var digitsOfEachCard = Enumerable.Range(0, cardCount)
            .Select(_ => Console.ReadLine())
            .Select(line => line.Take(line.Length - 1))
            .Select(line => line.Select(c => int.Parse(c.ToString())).ToArray())
            .ToArray();
        foreach (var digits in digitsOfEachCard)
        {
            var digitsWithIndex = digits.WithIndex().ToArray();
            var evenDigitsSum =
                digitsWithIndex
                .Where(it => it.Index % 2 == 0)
                .Select(it => it.Value * 2)
                .Select(v => (v >= 10) ? (1 + v % 10) : v)
                .Sum();
            foreach (var unknownDigitCandidate in Enumerable.Range(0, 10))
            {
                var oddDigitsSum =
                    digitsWithIndex
                    .Where(it => it.Index % 2 == 1)
                    .Select(it => it.Value)
                    .Sum() + unknownDigitCandidate;
                var checkSum = evenDigitsSum + oddDigitsSum;
                if (checkSum % 10 == 0)
                {
                    Console.WriteLine(unknownDigitCandidate);
                    break;
                }
            }
        }
    }
}
