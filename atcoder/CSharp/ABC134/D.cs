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
    //i>=1
    static void f(int[] ballCounts, int n, int i, int sumRemainingShouldBe)
    {
        var sumRemain = Enumerable.Range(1, n / i + 1)
            .Select(index => index * i)
            .Where(index => index <= n)
            .Select(index => ballCounts[index - 1])
            .Sum() % 2;
        if (sumRemain == sumRemainingShouldBe)
        {
            //ボール入れなくていい
            ballCounts[i - 1] = 0;
        }
        else
        {
            //ボール入れないとだめ
            ballCounts[i - 1] = 1;
        }
    }

    static void Main(string[] args)
    {
        var n = LineToInt();
        var remainingShouldBe = LineToInts();
        var ballCounts = new int[n];
        for (int temp = n; temp > 0; temp--)
        {
            f(ballCounts, n, temp, remainingShouldBe[temp - 1]);
        }
        var ballExistingBoxCount = ballCounts.Count(c => c > 0);
        Console.WriteLine(ballExistingBoxCount);
        foreach (var i in Enumerable.Range(0, n))
        {
            if (ballCounts[i] == 0) continue;
            Console.Write(i + 1 + " ");
        }
    }
}

