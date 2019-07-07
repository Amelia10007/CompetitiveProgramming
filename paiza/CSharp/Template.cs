using System;
using System.Collections.Generic;
using System.Linq;

static class Template
{
    static void _Main(string[] args)
    {
        //line to an input
        var lineInt = int.Parse(Console.ReadLine());

        //line to multiple inputs
        var lineToInts = Console.ReadLine()
            .Split(' ')
            .Select(s => int.Parse(s))
            .ToArray();

        //1-dimensional array
        var length = 0;

        var array1 = new int[length];
        foreach (var i in Enumerable.Range(0, length))
        {
            array1[i] = int.Parse(Console.ReadLine());
        }

        //2-dimensional array
        var width = 0;
        var height = 2;

        var array2 = new int[height, width];
        foreach (var y in Enumerable.Range(0, height))
        {
            var inputs = Console.ReadLine()
                .Split(' ')
                .Select(s => int.Parse(s))
                .ToArray();
            foreach (var x in Enumerable.Range(0, width))
            {
                array2[y, x] = inputs[x];
            }
        }
    }

    static IEnumerable<KeyValuePair<int, T>> WithIndex<T>(this IEnumerable<T> sequence)
    {
        var index = 0;
        foreach (var item in sequence)
        {
            var pair = KeyValuePair.Create(index, item);
            yield return pair;
            index++;
        }
    }
}