using System;
using System.Collections.Generic;
using System.Linq;

struct Flip
{
    public int x1, x2, y1, y2;
}

class Program
{
    static void Main(string[] args)
    {
        var firstline = Console.ReadLine().Split(' ');
        var height = int.Parse(firstline[0]);
        var width = int.Parse(firstline[1]);
        var playerCount = int.Parse(firstline[2]);
        //
        var numberTable = new int[height, width];
        foreach (var h in Enumerable.Range(0, height))
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(s => int.Parse(s))
                .ToArray();
            foreach (var w in Enumerable.Range(0, width))
            {
                numberTable[h, w] = numbers[w];
            }
        }
        //
        var totalStep = int.Parse(Console.ReadLine());
        var flips = new Flip[totalStep];
        foreach (var turn in Enumerable.Range(0, totalStep))
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(s => int.Parse(s))
                .ToArray();
            var flip = new Flip
            {
                y1 = numbers[0],
                x1 = numbers[1],
                y2 = numbers[2],
                x2 = numbers[3]
            };
            flips[turn] = flip;
        }
        //
        var playersRemoveCounts = new int[playerCount];
        var playerIndex = 0;
        foreach (var turn in Enumerable.Range(0, totalStep))
        {
            var flip = flips[turn];
            var flippedCard1 = numberTable[flip.y1 - 1, flip.x1 - 1];
            var flippedCard2 = numberTable[flip.y2 - 1, flip.x2 - 1];
            if (flippedCard1 == flippedCard2)
            {
                playersRemoveCounts[playerIndex] += 2;
            }
            else
            {
                playerIndex = (playerIndex + 1) % playerCount;
            }
        }
        //
        foreach (var removeCount in playersRemoveCounts)
        {
            Console.WriteLine(removeCount);
        }
    }
}
