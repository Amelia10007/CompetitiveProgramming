using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var rainOfDums = Console.ReadLine()
                .Split(' ')
                .Select(s => int.Parse(s))
                .ToArray();
            var mountainRains = new long[n];
            //
            long rainTransposedSum = 0;
            long transposeCoefficient = 1;
            foreach (var i in Enumerable.Range(0, n))
            {
                rainTransposedSum += rainOfDums[i] * transposeCoefficient;
                transposeCoefficient *= -1;
            }
            mountainRains[0] = rainTransposedSum;
            //
            Console.Write(mountainRains[0] + " ");
            //
            foreach (var i in Enumerable.Range(1, n - 1))
            {
                mountainRains[i] = 2 * rainOfDums[i - 1] - mountainRains[i - 1];
                Console.Write(mountainRains[i] + " ");
            }
        }
    }
}
