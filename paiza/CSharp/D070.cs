using System;
using System.Collections.Generic;
using System.Linq;

static class D070
{
    static void Main(string[] args)
    {
        var lineToInts = Console.ReadLine()
            .Split(' ')
            .Select(s => int.Parse(s))
            .ToArray();
        Console.WriteLine(lineToInts[0] - lineToInts[1]);
    }
}