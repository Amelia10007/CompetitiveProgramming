using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        var playCount = int.Parse(Console.ReadLine());
        var plays = new string[playCount];
        foreach (var i in Enumerable.Range(0, playCount))
        {
            plays[i] = Console.ReadLine();
        }
        var strikeCount = 0;
        var ballCount = 0;
        foreach (var play in plays)
        {
            string output;
            if (play == "strike")
            {
                strikeCount++;
                output = (strikeCount < 3) ? "strike!" : "out!";
            }
            else
            {
                ballCount++;
                output = (ballCount < 4) ? "ball!" : "fourball!";
            }
            Console.WriteLine(output);
        }
    }
}
