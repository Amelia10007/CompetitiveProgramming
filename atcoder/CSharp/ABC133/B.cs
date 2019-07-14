using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine()
                .Split(' ')
                .Select(s => int.Parse(s))
                .ToArray();
            var n = inputs[0];
            var dimension = inputs[1];
            var positions = new int[n, dimension];
            foreach (var i in Enumerable.Range(0, n))
            {
                var poss = Console.ReadLine()
                .Split(' ')
                .Select(s => int.Parse(s))
                .ToArray();
                foreach(var j in Enumerable.Range(0, dimension))
                {
                    positions[i, j] = poss[j];
                }
            }
            var integerDistancePairs = 0;
            foreach (var i in Enumerable.Range(0, n))
            {
                foreach (var j in Enumerable.Range(0, n))
                {
                    if (i >= j) continue;

                    var distanceSquare =
                        Enumerable.Range(0, dimension)
                        .Select(index => positions[i, index] - positions[j, index])
                        .Select(diff => diff * diff)
                        .Sum();
                    var sqrt = Math.Sqrt(distanceSquare);
                    var intSqrt = (int)sqrt;
                    if (Math.Abs(sqrt - intSqrt) < 1e-6) integerDistancePairs++;
                }
            }
            Console.WriteLine(integerDistancePairs);
        }
    }
}
