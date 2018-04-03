using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();
            var elements = new List<List<int>>(rowsAndCols[0]);

            for (int row = 0; row < rowsAndCols[0]; row++)
            {
                elements.Add(new List<int>());

                for (int col = 0; col < rowsAndCols[1]; col++)
                {
                    elements[row].Add(col + 1 + row * rowsAndCols[1]);
                }
            }

            string input = Console.ReadLine();

            while (!input.Equals("Nuke it from orbit"))
            {
                int[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();
                int targetedRow = tokens[0];
                int targetedCol = tokens[1];
                int radius = tokens[2];

                if (targetedRow >= 0 && targetedRow < elements.Count)
                {
                    if (targetedCol >= 0 && targetedCol < elements[targetedRow].Count)
                    {
                        int length = Math.Max(0, targetedRow - radius);

                        for (int row = targetedRow; row >= length; row--)
                        {
                            if (elements[row].Count > targetedCol)
                            {
                                elements[row][targetedCol] = 0;
                            }
                        }

                        length = Math.Min(elements.Count - 1, targetedRow + radius);

                        for (int row = targetedRow; row <= length; row++)
                        {
                            if (elements[row].Count > targetedCol)
                            {
                                elements[row][targetedCol] = 0;
                            }
                        }

                        length = Math.Max(0, targetedCol - radius);

                        for (int col = targetedCol; col >= length; col--)
                        {
                            elements[targetedRow][col] = 0;
                        }

                        length = Math.Min(elements[targetedRow].Count - 1, targetedCol + radius);

                        for (int col = targetedCol; col <= length; col++)
                        {
                            elements[targetedRow][col] = 0;
                        }
                    }
                    else if (targetedCol < 0)
                    {
                        int length = Math.Min(elements[targetedRow].Count - 1, targetedCol + radius);

                        for (int col = 0; col <= length; col++)
                        {
                            elements[targetedRow][col] = 0;
                        }
                    }
                    else if (targetedCol >= elements[targetedRow].Count)
                    {
                        int length = Math.Max(0, targetedCol - radius);

                        for (int col = elements[targetedRow].Count - 1; col >= length; col--)
                        {
                            elements[targetedRow][col] = 0;
                        }
                    }
                }
                else if (targetedRow < 0)
                {
                    if (targetedCol >= 0 && targetedCol < elements[RowWithMaxLength(elements)].Count)
                    {
                        int length = Math.Min(elements.Count - 1, targetedRow + radius);

                        for (int row = 0; row <= length; row++)
                        {
                            if (elements[row].Count > targetedCol)
                            {
                                elements[row][targetedCol] = 0;
                            }
                        }
                    }
                }
                else if (targetedRow >= elements.Count)
                {
                    if (targetedCol >= 0 && targetedCol < elements[RowWithMaxLength(elements)].Count)
                    {
                        int length = Math.Max(0, targetedRow - radius);

                        for (int row = elements.Count - 1; row >= length; row--)
                        {
                            if (elements[row].Count > targetedCol)
                            {
                                elements[row][targetedCol] = 0;
                            }
                        }
                    }
                }

                elements = NewList(elements);

                input = Console.ReadLine();
            }

            PrintList(elements);
        }

        static List<List<int>> NewList(List<List<int>> list)
        {
            var newList = new List<List<int>>();

            for (int i = 0; i < list.Count; i++)
            {
                newList.Add(new List<int>());

                for (int j = 0; j < list[i].Count; j++)
                {
                    if (list[i][j] != 0)
                    {
                        newList[i].Add(list[i][j]);
                    }
                }
            }

            return newList.Where(l => l.Count > 0).ToList();
        }

        static void PrintList(List<List<int>> elements)
        {
            foreach (var list in elements)
            {
                foreach (var item in list)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }

        static int RowWithMaxLength(List<List<int>> elements)
        {
            int maxLength = int.MinValue;
            int index = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Count > maxLength)
                {
                    maxLength = elements[i].Count;
                    index = i;
                }
            }

            return index;
        }
    }
}