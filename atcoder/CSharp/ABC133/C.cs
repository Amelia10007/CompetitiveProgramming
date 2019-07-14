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
            var lower = inputs[0];
            var upper = inputs[1];
            var range = upper - lower;
            //
            var minMod = 2019;
            foreach (var i in Enumerable.Range(0, 2019))
            {
                foreach (var j in Enumerable.Range(i + 1, 2019 - i - 1))
                {
                    var residual = i * j % 2019;
                    if (residual >= minMod) continue;
                    var lhs = lower - i;
                    var rhs = upper - j;
                    if (Has2019Multiple(lhs, rhs)) minMod = residual;
                }
            }
            Console.WriteLine(minMod);
        }
        static bool Has2019Multiple(int from, int to)
        {
            for (var i = from; i <= to; i++)
            {
                if (i % 2019 == 0) return true;
            }
            return false;
        }
    }
}
