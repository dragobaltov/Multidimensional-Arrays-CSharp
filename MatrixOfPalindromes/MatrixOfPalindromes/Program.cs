using System;
using System.Linq;

namespace MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string[,] matrix = new string[rowsAndCols[0], rowsAndCols[1]];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char firstAndLastLetter = alphabet[row];

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char middleLetter = alphabet[row + col];
                    matrix[row, col] = "" + firstAndLastLetter + middleLetter + firstAndLastLetter;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}