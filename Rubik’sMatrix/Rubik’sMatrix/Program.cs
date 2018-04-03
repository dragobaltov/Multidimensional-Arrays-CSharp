using System;
using System.Linq;

namespace Rubik_sMatrix
{
    class Program
    {
        public static int[,] matrix;

        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();
            matrix = new int[rowsAndCols[0], rowsAndCols[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = col + 1 + row * matrix.GetLength(1);
                }
            }

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int targetedRowOrCol = int.Parse(tokens[0]);
                string direction = tokens[1];
                int moves = int.Parse(tokens[2]);

                switch (direction)
                {
                    case "up":
                        MoveUp(targetedRowOrCol, moves);
                        break;
                    case "down":
                        MoveDown(targetedRowOrCol, moves);
                        break;
                    case "right":
                        MoveRight(targetedRowOrCol, moves);
                        break;
                    case "left":
                        MoveLeft(targetedRowOrCol, moves);
                        break;
                    default:
                        break;
                }
            }

            Swap();
        }

        static void MoveUp(int targetedCol, int moves)
        {
            for (int i = 0; i < moves % matrix.GetLength(0); i++)
            {
                int numAtFirstRow = matrix[0, targetedCol];

                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    matrix[row - 1, targetedCol] = matrix[row, targetedCol];
                }

                matrix[matrix.GetLength(0) - 1, targetedCol] = numAtFirstRow;
            }
        }

        static void MoveDown(int targetedCol, int moves)
        {
            for (int i = 0; i < moves % matrix.GetLength(0); i++)
            {
                int numAtLastRow = matrix[matrix.GetLength(0) - 1, targetedCol];

                for (int row = matrix.GetLength(0) - 2; row >= 0; row--)
                {
                    matrix[row + 1, targetedCol] = matrix[row, targetedCol];
                }

                matrix[0, targetedCol] = numAtLastRow;
            }
        }

        static void MoveRight(int targetedRow, int moves)
        {
            for (int i = 0; i < moves % matrix.GetLength(1); i++)
            {
                int numAtLastCol = matrix[targetedRow, matrix.GetLength(1) - 1];

                for (int col = matrix.GetLength(1) - 1; col >= 1; col--)
                {
                    matrix[targetedRow, col] = matrix[targetedRow, col - 1];
                }

                matrix[targetedRow, 0] = numAtLastCol;
            }
        }

        static void MoveLeft(int targetedRow, int moves)
        {
            for (int i = 0; i < moves % matrix.GetLength(1); i++)
            {
                int numAtFirstCol = matrix[targetedRow, 0];

                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    matrix[targetedRow, col - 1] = matrix[targetedRow, col];
                }

                matrix[targetedRow, matrix.GetLength(1) - 1] = numAtFirstCol;
            }
        }

        static void Swap()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int neededNumber = col + 1 + row * matrix.GetLength(1);

                    if (neededNumber == matrix[row, col])
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        var rowAndColOfNeededNumbers = RowAndColOfNeededNumber(neededNumber);
                        int neededRow = rowAndColOfNeededNumbers.Item1;
                        int neededCol = rowAndColOfNeededNumbers.Item2;

                        int copy = matrix[row, col];
                        matrix[row, col] = neededNumber;
                        matrix[neededRow, neededCol] = copy;

                        Console.WriteLine($"Swap ({row}, {col}) with ({neededRow}, {neededCol})");
                    }
                }
            }
        }

        static Tuple<int, int> RowAndColOfNeededNumber(int neededNumber)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (neededNumber == matrix[i, j])
                    {
                        return new Tuple<int, int>(i, j);
                    }
                }
            }

            return new Tuple<int, int>(0, 0);
        }

        /*static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }*/
    }
}