using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] jaggedArray = new long[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = new long[row + 1];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (col == 0 || col == jaggedArray[row].Length - 1)
                    {
                        jaggedArray[row][col] = 1;
                    }
                    else
                    {
                        jaggedArray[row][col] = jaggedArray[row - 1][col] + jaggedArray[row - 1][col - 1];
                    }
                }
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}