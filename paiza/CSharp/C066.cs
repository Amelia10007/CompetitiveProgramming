using System;
using System.Collections.Generic;
using System.Linq;

static class Template
{
    static void Main(string[] args)
    {
        //line to multiple inputs
        var firstLine = Console.ReadLine()
            .Split(' ')
            .Select(s => int.Parse(s))
            .ToArray();
        var fishCount = firstLine[0];
        var poiCount = firstLine[1];
        var limit = firstLine[2];

        var fishes = new int[fishCount];
        foreach (var i in Enumerable.Range(0, fishCount))
        {
            fishes[i] = int.Parse(Console.ReadLine());
        }

        var catchCount = 0;
        var currentPoiLimit = limit;
        foreach (var fish in fishes)
        {
            while (currentPoiLimit <= fish)
            {
                poiCount--;
                if (poiCount == 0) goto output;
                currentPoiLimit = limit;
            }
            currentPoiLimit -= fish;
            catchCount++;
        }
    output:
        Console.WriteLine(catchCount);
    }
}