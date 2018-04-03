using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] squareMatrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] currentRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    squareMatrix[row, col] = currentRow[col];
                }
            }

            long primaryDiagonal = 0;
            long secondaryDiagonal = 0;

            for (int row = 0; row < n; row++)
            {
                primaryDiagonal += squareMatrix[row, row];
                secondaryDiagonal += squareMatrix[row, n - row - 1];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}