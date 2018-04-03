using System;
using System.Linq;

namespace TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();
            char[,] matrix = new char[rowsAndCols[0], rowsAndCols[1]];
            char[] snake = Console.ReadLine().ToCharArray();
            int counter = 0;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if ((matrix.GetLength(0) - 1 - row) % 2 == 0)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[counter % snake.Length];
                        counter++;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[counter % snake.Length];
                        counter++;
                    }
                }
            }

            int[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();
            int targetedRow = tokens[0];
            int targetedCol = tokens[1];
            int radius = tokens[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if ((row - targetedRow) * (row - targetedRow) + (col - targetedCol) * (col - targetedCol)
                        <= radius * radius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                string currentCol = TakeCurrentCol(matrix, col);
                string colWithoutSpaces = currentCol.Replace(" ", "");
                string newCol = colWithoutSpaces + new string(' ', currentCol.Length - colWithoutSpaces.Length);
                int count = 0;

                for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                {
                    matrix[row, col] = newCol[count];
                    count++;
                }
            }

            PrintMatrix(matrix);
        }

        static string TakeCurrentCol(char[,] matrix, int col)
        {
            string currentCol = "";

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                currentCol += matrix[row, col];
            }

            return currentCol;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}