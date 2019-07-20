using System;
using System.Collections.Generic;
using System.Linq;

class WithIndex<T>
{
    public T Value;
    public int Index;
    public WithIndex(T value, int index)
    {
        this.Value = value;
        this.Index = index;
    }
}

static class Template
{
    public static int LineToInt()
    {
        return int.Parse(Console.ReadLine());
    }

    public static string[] LineToStrings()
    {
        return Console.ReadLine().Split();
    }

    public static int[] LineToInts()
    {
        return LineToStrings()
            .Select(s => int.Parse(s))
            .ToArray();
    }


    public static int[,] LinesToIntTable(int lineCount, int columnCount)
    {
        var value = new int[lineCount, columnCount];
        foreach (var y in Enumerable.Range(0, lineCount))
        {
            var ints = LineToInts();
            foreach (var x in Enumerable.Range(0, columnCount))
            {
                value[y, x] = ints[x];
            }
        }
        return value;
    }

    public static IEnumerable<WithIndex<T>> WithIndex<T>(this IEnumerable<T> sequence)
    {
        int index = 0;
        foreach (var item in sequence)
        {
            yield return new WithIndex<T>(item, index);
            index++;
        }
    }

    static void Main(string[] args)
    {
        var inputs = LineToInts();
        var n = inputs[0];
        var r = inputs[1];
        var count = 1;
        var i = r + 1;
        while (i + r + 1 <= n)
        {
            count++;
            i += 2 * r + 1;
        }
        Console.WriteLine(count);
    }
}

