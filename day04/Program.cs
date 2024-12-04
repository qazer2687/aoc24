using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Read grid from file
        string[] lines = File.ReadAllLines("./input");
        int rows = lines.Length;
        int cols = lines[0].Length;

        // Convert input to 2D grid
        char[,] grid = new char[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                grid[i, j] = lines[i][j];
            }
        }

        string mas = "MAS";
        int count = 0;

        // Check for X-MAS patterns
        for (int centerX = 0; centerX < rows; centerX++)
        {
            for (int centerY = 0; centerY < cols; centerY++)
            {
                int len = mas.Length;

                // Try all combinations of diagonals
                foreach (var diag1 in new string[] { mas, new string(mas.Reverse().ToArray()) })
                {
                    foreach (var diag2 in new string[] { mas, new string(mas.Reverse().ToArray()) })
                    {
                        bool isXMas = true;

                        // Check first diagonal (top-left to bottom-right)
                        for (int k = 0; k < len; k++)
                        {
                            int newX = centerX + k * -1;
                            int newY = centerY + k * -1;
                            if (newX < 0 || newY < 0 || newX >= rows || newY >= cols || grid[newX, newY] != diag1[k])
                            {
                                isXMas = false;
                                break;
                            }
                        }

                        // Check second diagonal (top-right to bottom-left)
                        for (int k = 0; k < len && isXMas; k++)
                        {
                            int newX = centerX + k * 1;
                            int newY = centerY + k * -1;
                            if (newX < 0 || newY < 0 || newX >= rows || newY >= cols || grid[newX, newY] != diag2[k])
                            {
                                isXMas = false;
                                break;
                            }
                        }

                        // If both diagonals match, count as X-MAS
                        if (isXMas)
                        {
                            count++;
                        }
                    }
                }
            }
        }

        Console.WriteLine($"Total X-MAS patterns: {count}");
    }
}
