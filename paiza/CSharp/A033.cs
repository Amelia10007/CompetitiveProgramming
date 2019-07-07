using System;
using System.Collections.Generic;
using System.Linq;

struct Book
{
    public int Page;
    public int NeededDate;
}

static class A033
{
    static int MaxReadablePage(Book[] books, int startIndex, int remainingDate, int?[,] memoTable)
    {
        var pageCount = 0;
        if (memoTable[startIndex, remainingDate] != null)
        {
            pageCount = memoTable[startIndex, remainingDate].Value;
        }
        else if (startIndex >= books.Length)
        {
            pageCount = 0;
        }
        else if (books[startIndex].NeededDate > remainingDate)
        {
            pageCount = MaxReadablePage(books, startIndex + 1, remainingDate, memoTable);
        }
        else
        {
            var notRead = MaxReadablePage(books, startIndex + 1, remainingDate, memoTable);
            var read = MaxReadablePage(books, startIndex + 1, remainingDate - books[startIndex].NeededDate, memoTable) + books[startIndex].Page;
            pageCount = Math.Max(notRead, read);
        }
        memoTable[startIndex, remainingDate] = pageCount;
        return pageCount;
    }
    static void Main(string[] args)
    {
        var firstLine = Console.ReadLine()
            .Split(' ')
            .Select(s => int.Parse(s))
            .ToArray();
        var bookCount = firstLine[0];
        var maxDateCount = firstLine[1];
        var books = new Book[bookCount];
        foreach (var i in Enumerable.Range(0, bookCount))
        {
            var line = Console.ReadLine()
            .Split(' ')
            .Select(s => int.Parse(s))
            .ToArray();
            var page = line[0];
            var neededDate = line[1];
            books[i] = new Book() { Page = page, NeededDate = neededDate };
        }
        //
        var memoTable = new int?[bookCount + 1, maxDateCount + 1];
        var answer = MaxReadablePage(books, 0, maxDateCount, memoTable);
        Console.WriteLine(answer);
    }
}
