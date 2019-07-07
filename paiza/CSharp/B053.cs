using System;
using System.Collections.Generic;
using System.Linq;

static class B053
{
    static void Main(string[] args)
    {
        //read console
        var firstLine = Console.ReadLine()
            .Split(' ')
            .Select(s => int.Parse(s))
            .ToArray();
        var secondLine = Console.ReadLine()
            .Split(' ')
            .Select(s => int.Parse(s))
            .ToArray();
        var thirdLine = Console.ReadLine()
            .Split(' ')
            .Select(s => int.Parse(s))
            .ToArray();
        //初期値を設定
        var height = firstLine[0];
        var width = firstLine[1];
        var table = new int[height, width];
        table[0, 0] = secondLine[0];
        table[0, 1] = secondLine[1];
        table[1, 0] = thirdLine[0];
        table[1, 1] = thirdLine[1];
        //上2行を埋める
        foreach (var row in Enumerable.Range(0, 2))
        {
            var diff = table[row, 1] - table[row, 0];
            foreach (var col in Enumerable.Range(2, width - 2))
            {
                table[row, col] = table[row, col - 1] + diff;
            }
        }
        //左2行を埋める
        foreach (var col in Enumerable.Range(0, 2))
        {
            var diff = table[1, col] - table[0, col];
            foreach (var row in Enumerable.Range(2, height - 2))
            {
                table[row, col] = table[row - 1, col] + diff;
            }
        }
        //ここまでで左上2x2マスが埋まっているので，ここではほかのすべてのマスを埋める
        foreach (var col in Enumerable.Range(2, width - 2))
        {
            var diff = table[1, col] - table[0, col];
            foreach (var row in Enumerable.Range(2, height - 2))
            {
                table[row, col] = table[row - 1, col] + diff;
            }
        }
        //出力
        foreach (var row in Enumerable.Range(0, height))
        {
            foreach (var col in Enumerable.Range(0, width))
            {
                Console.Write(table[row, col]);
                if (col != width - 1) Console.Write(' ');
            }
            Console.WriteLine();
        }
    }
}