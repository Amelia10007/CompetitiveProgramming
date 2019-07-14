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
            var a = inputs[1];
            var b = inputs[2];
            var train = n * a;
            var taxi = b;
            Console.WriteLine(Math.Min(train, taxi));
        }
    }
}
