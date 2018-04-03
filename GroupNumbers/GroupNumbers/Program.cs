using System;
using System.Linq;

namespace GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse).ToArray();
            int[] sizes = new int[3];

            for (int i = 0; i < sizes.Length; i++)
            {
                sizes[i] = numbers.Where(n => Math.Abs(n % 3) == i).ToArray().Length;
            }

            int[][] jaggedArray = new int[3][];

            for (int i = 0; i < sizes.Length; i++)
            {
                jaggedArray[i] = new int[sizes[i]];
            }

            int[] indexes = new int[3];

            foreach (var number in numbers)
            {
                int remainder = Math.Abs(number % 3);
                jaggedArray[remainder][indexes[remainder]] = number;
                indexes[remainder]++;
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