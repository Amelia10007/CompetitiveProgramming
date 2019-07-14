using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var leetMap = new Dictionary<char, char>()
            {
                {'A', '4'},
                {'E', '3'},
                {'G', '6'},
                {'I', '1'},
                {'O', '0'},
                {'S', '5'},
                {'Z', '2'},
            };
        var leet = Console.ReadLine()
            .Select(c => leetMap.ContainsKey(c) ? leetMap[c] : c);
        foreach (var c in leet) Console.Write(c);
    }
}
