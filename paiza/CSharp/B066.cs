using System;
using System.Collections.Generic;
using System.Linq;

struct Position
{
    public int X, Y;
}

class Piece
{
    public bool[,] Table;
    public Piece Rotate()
    {
        var size = this.Table.GetLength(0);
        var temp = new bool[size, size];
        foreach (var h in Enumerable.Range(0, size))
        {
            foreach (var w in Enumerable.Range(0, size))
            {
                temp[w, size - h - 1] = this.Table[h, w];
            }
        }
        return new Piece
        {
            Table = temp
        };
    }
}

class Program
{
    static void Main(string[] args)
    {
        var firstLine = Console.ReadLine()
            .Split(' ')
            .Select(s => int.Parse(s))
            .ToArray();
        var pieceCount = firstLine[0];
        var fieldSize = firstLine[1];
        var pieceSize = firstLine[2];
        //
        var fieldTable = new bool[fieldSize, fieldSize];
        foreach (var h in Enumerable.Range(0, fieldSize))
        {
            var isYellows = Console.ReadLine()
                .Select(c => c == 'Y')
                .ToArray();
            foreach (var w in Enumerable.Range(0, fieldSize))
            {
                fieldTable[h, w] = isYellows[w];
            }
        }
        //
        var pieces = new Piece[pieceCount];
        foreach (var i in Enumerable.Range(0, pieceCount))
        {
            pieces[i] = new Piece();
            pieces[i].Table = new bool[pieceSize, pieceSize];
            foreach (var h in Enumerable.Range(0, pieceSize))
            {
                var isYellows = Console.ReadLine()
                    .Select(c => c == 'Y')
                    .ToArray();
                foreach (var w in Enumerable.Range(0, pieceSize))
                {
                    pieces[i].Table[h, w] = isYellows[w];
                }
            }
        }
        //
        var usedPieceCount = 0;
        var shouldUsePieceCount = fieldSize * fieldSize / (pieceSize * pieceSize);
        var usedPositions = new Position?[pieceCount];
        var rotatedCounts = new int[pieceCount];
        //
        while (usedPieceCount < shouldUsePieceCount)
        {
            foreach (var pieceIndex in Enumerable.Range(0, pieceCount))
            {
                if (usedPositions[pieceIndex].HasValue) continue;
                var positionCandidates =
                    Enumerable.Range(0, fieldSize / pieceSize)
                    .Select(pos => pos * pieceSize)
                    .ToArray();
                foreach (var xCandidate in positionCandidates)
                {
                    foreach (var yCandidate in positionCandidates)
                    {
                        var rotatedPiece = pieces[pieceIndex];
                        var position = new Position
                        {
                            X = xCandidate,
                            Y = yCandidate
                        };
                        //no rotate
                        if (Match(fieldTable, rotatedPiece, pieceSize, position))
                        {
                            usedPositions[pieceIndex] = position;
                            rotatedCounts[pieceIndex] = 0;
                            usedPieceCount++;
                            goto toNextCheck;
                        }
                        //1 rotate
                        rotatedPiece = rotatedPiece.Rotate();
                        if (Match(fieldTable, rotatedPiece, pieceSize, position))
                        {
                            usedPositions[pieceIndex] = position;
                            rotatedCounts[pieceIndex] = 1;
                            usedPieceCount++;
                            goto toNextCheck;
                        }
                        //2 rotate
                        rotatedPiece = rotatedPiece.Rotate();
                        if (Match(fieldTable, rotatedPiece, pieceSize, position))
                        {
                            usedPositions[pieceIndex] = position;
                            rotatedCounts[pieceIndex] = 2;
                            usedPieceCount++;
                            goto toNextCheck;
                        }
                        //3 rotate
                        rotatedPiece = rotatedPiece.Rotate();
                        if (Match(fieldTable, rotatedPiece, pieceSize, position))
                        {
                            usedPositions[pieceIndex] = position;
                            rotatedCounts[pieceIndex] = 3;
                            usedPieceCount++;
                            goto toNextCheck;
                        }
                    }
                }
            }
        toNextCheck:;
        }
        foreach (var pieceIndex in Enumerable.Range(0, pieceCount))
        {
            if (!usedPositions[pieceIndex].HasValue)
            {
                Console.WriteLine(-1);
                continue;
            }
            var position = usedPositions[pieceIndex].Value;
            var rotation = rotatedCounts[pieceIndex];
            Console.WriteLine((position.Y + 1) + " " + (position.X + 1) + " " + rotation);
        }
    }

    static bool Match(bool[,] fieldTable, Piece rotatedPiece, int pieceSize, Position position)
    {
        foreach (var x in Enumerable.Range(0, pieceSize))
        {
            foreach (var y in Enumerable.Range(0, pieceSize))
            {
                var fieldX = position.X + x;
                var fieldY = position.Y + y;
                var fieldValue = fieldTable[fieldY, fieldX];
                var pieceValue = rotatedPiece.Table[y, x];
                if (fieldValue != pieceValue) return false;
            }
        }
        return true;
    }
}
