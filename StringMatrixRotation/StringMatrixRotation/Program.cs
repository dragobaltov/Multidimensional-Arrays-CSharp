using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StringMatrixRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = Console.ReadLine().Split(new string[] { "Rotate", "(", ")" }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse).ToArray()[0] % 360;
            var lines = new List<string>();
            string line = Console.ReadLine();

            while (!line.Equals("END"))
            {
                lines.Add(line);
                line = Console.ReadLine();
            }

            char[][] matrix = new char[lines.Count][];
            int length = MaxLength(lines);

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new char[length];

                for (int col = 0; col < length; col++)
                {
                    if (col >= lines[row].Length)
                    {
                        matrix[row][col] = ' ';
                    }
                    else
                    {
                        matrix[row][col] = lines[row][col];
                    }
                }
            }

            for (int i = 0; i < degrees / 90; i++)
            {
                matrix = Rotate(matrix);
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }

        static char[][] Rotate(char[][] matrix)
        {
            char[][] newMatrix = new char[matrix[0].Length][];
            int rowIndexOldMatrix = matrix.Length - 1;
            int colIndexOldMatrix = 0;

            for (int row = 0; row < newMatrix.Length; row++)
            {
                newMatrix[row] = new char[matrix.Length];
                rowIndexOldMatrix = matrix.Length - 1;

                for (int col = 0; col < newMatrix[row].Length; col++)
                {
                    newMatrix[row][col] = matrix[rowIndexOldMatrix][colIndexOldMatrix];
                    rowIndexOldMatrix--;
                }
                colIndexOldMatrix++;
            }

            return newMatrix;
        }

        static int MaxLength(List<string> lines)
        {
            int maxLength = 0;

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Length > maxLength)
                {
                    maxLength = lines[i].Length;
                }
            }

            return maxLength;
        }
    }
}