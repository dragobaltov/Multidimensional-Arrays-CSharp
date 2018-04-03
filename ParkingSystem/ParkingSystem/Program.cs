using System;
using System.Linq;

namespace ParkingSystem
{
    class Program
    {
        public static int[][] parking;

        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();
            parking = new int[rowsAndCols[0]][];

            string input = Console.ReadLine();

            while (!input.Equals("stop"))
            {
                int[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();
                int entryRow = tokens[0];
                int desiredRow = tokens[1];
                int desiredCol = tokens[2];
                int distance = 1;
                distance += Math.Abs(entryRow - desiredRow);

                if (parking[desiredRow] == null)
                {
                    parking[desiredRow] = new int[rowsAndCols[1]];
                }

                if (parking[desiredRow][desiredCol] == 0)
                {
                    distance += desiredCol;
                    parking[desiredRow][desiredCol] = 1;
                    Console.WriteLine(distance);
                }
                else
                {
                    if (!DesiredRowHasFreePlace(desiredRow))
                    {
                        Console.WriteLine($"Row {desiredRow} full");
                    }
                    else
                    {
                        int closestCol = ClosestFreeColumn(desiredRow, desiredCol);

                        distance += closestCol;
                        parking[desiredRow][closestCol] = 1;
                        Console.WriteLine(distance);
                    }
                }

                input = Console.ReadLine();
            }
        }

        static bool DesiredRowHasFreePlace(int desiredRow)
        {
            for (int col = 1; col < parking[desiredRow].Length; col++)
            {
                if (parking[desiredRow][col] == 0)
                    return true;
            }

            return false;
        }

        static int ClosestFreeColumn(int desiredRow, int desiredCol)
        {
            int closestColBeforeDesiredCol = 0;
            int closestColAfterDesiredCol = 0;

            for (int col = desiredCol; col >= 1; col--)
            {
                if (parking[desiredRow][col] == 0)
                {
                    closestColBeforeDesiredCol = col;
                    break;
                }
            }

            for (int col = parking[desiredRow].Length - 1; col > desiredCol; col--)
            {
                if (parking[desiredRow][col] == 0)
                {
                    closestColAfterDesiredCol = col;
                }
            }

            if (closestColBeforeDesiredCol == 0)
            {
                return closestColAfterDesiredCol;
            }
            else if (closestColAfterDesiredCol == 0)
            {
                return closestColBeforeDesiredCol;
            }
            else
            {
                int distanceFromDesiredColToColBeforeIt = desiredCol - closestColBeforeDesiredCol;
                int distanceFromDesiredColToColAfterIt = closestColAfterDesiredCol - desiredCol;

                if (distanceFromDesiredColToColBeforeIt <= distanceFromDesiredColToColAfterIt)
                {
                    return closestColBeforeDesiredCol;
                }
                else
                {
                    return closestColAfterDesiredCol;
                }
            }
        }
    }
}