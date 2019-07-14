using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var line = Console.ReadLine()
            .Split(' ')
            .Select(s => int.Parse(s))
            .ToArray();
        var vertexCount = line[0];
        var colorCount = line[1];
        var connections = new Dictionary<int, List<int>>();
        foreach (var i in Enumerable.Range(0, vertexCount))
        {
            connections.Add(i, new List<int>());
        }
        foreach (var _ in Enumerable.Range(0, vertexCount - 1))
        {
            var inputs = Console.ReadLine()
           .Split(' ')
           .Select(s => int.Parse(s))
           .ToArray();
            var from = inputs[0] - 1;
            var to = inputs[1] - 1;
            connections[from].Add(to);
            connections[to].Add(from);
        }
        //
        var within2DistanceCounts = new Dictionary<int, int>();
        foreach (var i in Enumerable.Range(0, vertexCount))
        {
            within2DistanceCounts.Add(i, 0);
        }
        foreach (var pair in connections)
        {
            foreach (var connectionDestinationIndex in pair.Value)
            {
                within2DistanceCounts[connectionDestinationIndex]++;
            }
        }
        var needs = within2DistanceCounts
            .Select(pair => pair.Value)
            .Where(connection => connection >= colorCount);
        long dividor = 1000000007L;
        long answer = 1;
        foreach (var need in needs)
        {
            var max = need + 1;
            for (int i = colorCount; i >= colorCount - max + 1; i--)
            {
                answer = answer * i % dividor;
            }
        }
        Console.WriteLine(answer);
    }
}
