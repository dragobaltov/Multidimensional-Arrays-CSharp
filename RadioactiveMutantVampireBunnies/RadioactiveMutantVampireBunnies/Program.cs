using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        public static char[,] matrix;
        public static int personRow;
        public static int personCol;
        public static bool personHasWon;

        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();
            matrix = new char[rowsAndCols[0], rowsAndCols[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (currentRow[col] == 'P')
                    {
                        personRow = row;
                        personCol = col;
                    }
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();
            personHasWon = false;

            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case 'U':
                        MoveUp();
                        break;
                    case 'D':
                        MoveDown();
                        break;
                    case 'R':
                        MoveRight();
                        break;
                    case 'L':
                        MoveLeft();
                        break;
                    default:
                        break;
                }

                SpreadBunnies();

                if (personHasWon)
                {
                    PrintMatrix();
                    Console.WriteLine($"won: {personRow} {personCol}");
                    break;
                }
                if (!MatrixContainsPlayer())
                {
                    PrintMatrix();
                    Console.WriteLine($"dead: {personRow} {personCol}");
                    break;
                }
            }
        }

        static void MoveUp()
        {
            matrix[personRow, personCol] = '.';
            personRow--;

            if (personRow < 0)
            {
                personHasWon = true;
                personRow++;
            }
            else
            {
                if (matrix[personRow, personCol] == '.')
                {
                    matrix[personRow, personCol] = 'P';
                }
            }
        }

        static void MoveDown()
        {
            matrix[personRow, personCol] = '.';
            personRow++;

            if (personRow >= matrix.GetLength(0))
            {
                personHasWon = true;
                personRow--;
            }
            else
            {
                if (matrix[personRow, personCol] == '.')
                {
                    matrix[personRow, personCol] = 'P';
                }
            }
        }

        static void MoveRight()
        {
            matrix[personRow, personCol] = '.';
            personCol++;

            if (personCol >= matrix.GetLength(1))
            {
                personHasWon = true;
                personCol--;
            }
            else
            {
                if (matrix[personRow, personCol] == '.')
                {
                    matrix[personRow, personCol] = 'P';
                }
            }
        }

        static void MoveLeft()
        {
            matrix[personRow, personCol] = '.';
            personCol--;

            if (personCol < 0)
            {
                personHasWon = true;
                personCol++;
            }
            else
            {
                if (matrix[personRow, personCol] == '.')
                {
                    matrix[personRow, personCol] = 'P';
                }
            }
        }

        static void PrintMatrix()
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

        static void SpreadBunnies()
        {
            char[,] copyMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    copyMatrix[i, j] = matrix[i, j];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (copyMatrix[row, col] == 'B')
                    {
                        int currentBunnyRow = row;
                        int currentBunnyCol = col;

                        if (currentBunnyRow == 0)
                        {
                            if (currentBunnyCol == 0)
                            {
                                matrix[currentBunnyRow, currentBunnyCol + 1] = 'B';
                                matrix[currentBunnyRow + 1, currentBunnyCol] = 'B';
                            }
                            else if (currentBunnyCol == matrix.GetLength(1) - 1)
                            {
                                matrix[currentBunnyRow, currentBunnyCol - 1] = 'B';
                                matrix[currentBunnyRow + 1, currentBunnyCol] = 'B';
                            }
                            else
                            {
                                matrix[currentBunnyRow, currentBunnyCol - 1] = 'B';
                                matrix[currentBunnyRow, currentBunnyCol + 1] = 'B';
                                matrix[currentBunnyRow + 1, currentBunnyCol] = 'B';
                            }
                        }
                        else if (currentBunnyRow == matrix.GetLength(0) - 1)
                        {
                            if (currentBunnyCol == 0)
                            {
                                matrix[currentBunnyRow - 1, currentBunnyCol] = 'B';
                                matrix[currentBunnyRow, currentBunnyCol + 1] = 'B';
                            }
                            else if (currentBunnyCol == matrix.GetLength(1) - 1)
                            {
                                matrix[currentBunnyRow - 1, currentBunnyCol] = 'B';
                                matrix[currentBunnyRow, currentBunnyCol - 1] = 'B';
                            }
                            else
                            {
                                matrix[currentBunnyRow - 1, currentBunnyCol] = 'B';
                                matrix[currentBunnyRow, currentBunnyCol - 1] = 'B';
                                matrix[currentBunnyRow, currentBunnyCol + 1] = 'B';
                            }
                        }
                        else
                        {
                            if (currentBunnyCol == 0)
                            {
                                matrix[currentBunnyRow - 1, currentBunnyCol] = 'B';
                                matrix[currentBunnyRow + 1, currentBunnyCol] = 'B';
                                matrix[currentBunnyRow, currentBunnyCol + 1] = 'B';
                            }
                            else if (currentBunnyCol == matrix.GetLength(1) - 1)
                            {
                                matrix[currentBunnyRow - 1, currentBunnyCol] = 'B';
                                matrix[currentBunnyRow + 1, currentBunnyCol] = 'B';
                                matrix[currentBunnyRow, currentBunnyCol - 1] = 'B';
                            }
                            else
                            {
                                matrix[currentBunnyRow - 1, currentBunnyCol] = 'B';
                                matrix[currentBunnyRow + 1, currentBunnyCol] = 'B';
                                matrix[currentBunnyRow, currentBunnyCol - 1] = 'B';
                                matrix[currentBunnyRow, currentBunnyCol + 1] = 'B';
                            }
                        }
                    }
                }
            }
        }

        static bool MatrixContainsPlayer()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'P')
                        return true;
                }
            }

            return false;
        }
    }
}