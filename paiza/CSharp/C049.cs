using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var moveCount = int.Parse(Console.ReadLine());
        var floors = new int[moveCount];
        foreach (var i in Enumerable.Range(0, moveCount))
        {
            floors[i] = int.Parse(Console.ReadLine());
        }
        var sum = floors[0] - 1;
        foreach (var i in Enumerable.Range(0, moveCount - 1))
        {
            sum += Math.Abs(floors[i + 1] - floors[i]);
        }
        Console.WriteLine(sum);
    }
}
