using System;
using System.Linq;

public class Hello{
    public static void Main(){
        var userInput = int.Parse(Console.ReadLine());
        var output = new string(Enumerable.Repeat('*', userInput).ToArray());
        Console.WriteLine(output);
    }
}