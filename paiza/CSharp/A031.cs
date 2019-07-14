using System;
using System.Collections.Generic;
using System.Linq;

struct Power
{
    public int x, y, z;
    public double log;
    public long GetProduct(long[] primes)
    {
        var p1 = (long)Math.Pow(primes[0], this.x);
        var p2 = (long)Math.Pow(primes[1], this.y);
        var p3 = (long)Math.Pow(primes[2], this.z);
        return p1 * p2 * p3;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var firstLine = Console.ReadLine()
            .Split(' ')
            .Select(s => long.Parse(s))
            .ToArray();
        var primeNumbers = firstLine
            .Take(3)
            .ToArray();
        var k = (int)firstLine
            .Last();
        var primeLogs = primeNumbers
            .Select(p => Math.Log(p))
            .ToArray();

        var currentPower = new Power()
        {
            x = 0,
            y = 0,
            z = 0,
            log = 0
        };
        var currentK = 1;
        while (currentK < k)
        {
            var lowerLog = currentPower.log;
            var upperX = (int)Math.Ceiling(lowerLog / primeLogs[0]);
            var upperY = (int)Math.Ceiling(lowerLog / primeLogs[1]);
            var upperZ = (int)Math.Ceiling(lowerLog / primeLogs[2]);
            var candidateLog = double.MaxValue;
            int candidateX = 0, candidateY = 0, candidateZ = 0;
            foreach (var x in Enumerable.Range(0, upperX + 2))
            {
                foreach (var y in Enumerable.Range(0, upperY + 2))
                {
                    foreach (var z in Enumerable.Range(0, upperZ + 2))
                    {
                        var log = x * primeLogs[0] + y * primeLogs[1] + z * primeLogs[2];
                        if (log >= candidateLog) break;
                        if (log <= lowerLog) continue;
                        candidateLog = log;
                        candidateX = x;
                        candidateY = y;
                        candidateZ = z;
                    }
                }
            }
            currentPower.x = candidateX;
            currentPower.y = candidateY;
            currentPower.z = candidateZ;
            currentPower.log = candidateLog;
            currentK++;
        }
        Console.WriteLine(currentPower.GetProduct(primeNumbers));
    }
}
