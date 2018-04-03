using System;
using System.Linq;

namespace LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] firstArray = new int[n][];
            int[][] secondArray = new int[n][];

            for (int i = 0; i < n; i++)
            {
                int[] currentRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse).ToArray();
                firstArray[i] = new int[currentRow.Length];

                for (int j = 0; j < currentRow.Length; j++)
                {
                    firstArray[i][j] = currentRow[j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                int[] currentRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse).ToArray();
                secondArray[i] = new int[currentRow.Length];

                for (int j = 0; j < currentRow.Length; j++)
                {
                    secondArray[i][j] = currentRow[j];
                }
            }

            secondArray = ReverseArray(secondArray);

            int[][] newArray = CombineArrays(firstArray, secondArray);

            if (ArraysFitPerfectly(newArray))
            {
                PrintJaggedArray(newArray);
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {AllCells(newArray)}");
            }
        }

        static int[][] ReverseArray(int[][] secondArray)
        {
            for (int row = 0; row < secondArray.Length; row++)
            {
                int startIndex = 0;
                int endIndex = secondArray[row].Length - 1;

                while (startIndex < endIndex)
                {
                    int copy = secondArray[row][startIndex];
                    secondArray[row][startIndex] = secondArray[row][endIndex];
                    secondArray[row][endIndex] = copy;

                    startIndex++;
                    endIndex--;
                }
            }

            return secondArray;
        }

        static int[][] CombineArrays(int[][] firstArray, int[][] secondArray)
        {
            int[][] newArray = new int[firstArray.Length][];

            for (int row = 0; row < newArray.Length; row++)
            {
                newArray[row] = new int[firstArray[row].Length + secondArray[row].Length];
                int index = 0;

                for (int col = 0; col < firstArray[row].Length; col++)
                {
                    newArray[row][index] = firstArray[row][col];
                    index++;
                }
                for (int col = 0; col < secondArray[row].Length; col++)
                {
                    newArray[row][index] = secondArray[row][col];
                    index++;
                }
            }

            return newArray;
        }

        static bool ArraysFitPerfectly(int[][] newArray)
        {
            int length = newArray[0].Length;

            for (int i = 1; i < newArray.Length; i++)
            {
                if (newArray[i].Length != length)
                    return false;
            }

            return true;
        }

        static void PrintJaggedArray(int[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine("[" + string.Join(", ", jaggedArray[i]) + "]");
            }
        }

        static int AllCells(int[][] jaggedArray)
        {
            int cells = 0;

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                cells += jaggedArray[i].Length;
            }

            return cells;
        }
    }
}