using System;
using System.Linq;

namespace AtCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            var digits = Console.ReadLine()
                .Skip(1)
                .Select(c => int.Parse(c.ToString()));
            if (digits.Distinct().Count() == 1)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
