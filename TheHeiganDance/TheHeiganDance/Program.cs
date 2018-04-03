using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace TheHeiganDance
{
    class Program
    {
        static void Main(string[] args)
        {
            double damageDoneToHeigan = double.Parse(Console.ReadLine());
            double playersPoints = 18500;
            double heigansPoints = 3000000;
            int playersRow = 7;
            int playersCol = 7;
            bool activeCloud = false;

            while (true)
            {
                if (activeCloud)
                {
                    playersPoints -= 3500;
                    activeCloud = false;
                }

                heigansPoints -= damageDoneToHeigan;

                if (heigansPoints <= 0 || playersPoints <= 0)
                {
                    if (heigansPoints <= 0)
                        Console.WriteLine("Heigan: Defeated!");
                    else
                        Console.WriteLine($"Heigan: {heigansPoints:F2}");

                    if (playersPoints <= 0)
                        Console.WriteLine("Player: Killed by Plague Cloud");
                    else
                        Console.WriteLine($"Player: {playersPoints}");

                    Console.WriteLine($"Final position: {playersRow}, {playersCol}");
                    break;
                }

                string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string spell = tokens[0];
                int targetRow = int.Parse(tokens[1]);
                int targetCol = int.Parse(tokens[2]);
                double damageDoneToPlayer = 0;

                if (spell == "Cloud")
                {
                    damageDoneToPlayer = 3500;
                    spell = "Plague Cloud";
                    activeCloud = true;
                }
                else
                {
                    damageDoneToPlayer = 6000;
                }

                var damagedCells = new List<Tuple<int, int>>();

                for (int row = targetRow - 1; row <= targetRow + 1; row++)
                {
                    for (int col = targetCol - 1; col <= targetCol + 1; col++)
                    {
                        damagedCells.Add(new Tuple<int, int>(row, col));
                    }
                }

                if (damagedCells.Contains(new Tuple<int, int>(playersRow, playersCol)))
                {
                    if (playersRow - 1 >= 0 && !damagedCells.Contains(new Tuple<int, int>(playersRow - 1, playersCol)))
                    {
                        playersRow--;
                        activeCloud = false;
                    }
                    else if (playersCol + 1 < 15 && !damagedCells.Contains(new Tuple<int, int>(playersRow, playersCol + 1)))
                    {
                        playersCol++;
                        activeCloud = false;
                    }
                    else if (playersRow + 1 < 15 && !damagedCells.Contains(new Tuple<int, int>(playersRow + 1, playersCol)))
                    {
                        playersRow++;
                        activeCloud = false;
                    }
                    else if (playersCol - 1 >= 0 && !damagedCells.Contains(new Tuple<int, int>(playersRow, playersCol - 1)))
                    {
                        playersCol--;
                        activeCloud = false;
                    }
                    else
                    {
                        playersPoints -= damageDoneToPlayer;
                    }

                    if (playersPoints <= 0)
                    {
                        Console.WriteLine($"Heigan: {heigansPoints:F2}");
                        Console.WriteLine($"Player: Killed by {spell}");
                        Console.WriteLine($"Final position: {playersRow}, {playersCol}");
                        break;
                    }
                }
                else
                {
                    activeCloud = false;
                }
            }
        }
    }
}