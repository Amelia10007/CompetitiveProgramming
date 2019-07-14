using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        var firstLine = Console.ReadLine()
            .Split(' ')
            .Select(s => int.Parse(s))
            .ToArray();
        var studentCount = firstLine[0];
        var passScore = firstLine[1];
        foreach (var i in Enumerable.Range(0, studentCount))
        {
            var line = Console.ReadLine()
            .Split(' ')
            .Select(s => int.Parse(s))
            .ToArray();
            var score = line[0];
            var absence = line[1];
            var total = Math.Max(score - 5 * absence, 0);
            if (total < passScore) continue;
            Console.WriteLine(i + 1);
        }
    }
}
