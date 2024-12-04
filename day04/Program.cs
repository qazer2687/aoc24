using System;
using System.IO;

// read input
string[] lines = File.ReadAllLines("./input");
int rows = lines.Length;
int cols = lines[0].Length;

// convert input to 2d array
char[,] grid = new char[rows, cols];
for (int y = 0; y < rows; y++) {
  for (int x = 0; x < cols; x++) {
    grid[y, x] = lines[y][x];
  }
}

string word = "XMAS";
int wordLength = word.Length;
int count1= 0;

// directions
int[][] directions = new int[][] {
    new int[] { 0, 1 },
    new int[] { 1, 0 },
    new int[] { 1, 1 },
    new int[] { 1, -1 },
    new int[] { 0, -1 },
    new int[] { -1, 0 },
    new int[] { -1, -1 },
    new int[] { -1, 1 }
};

// search each cell in grid
for (int i = 0; i < rows; i++) {
  for (int j = 0; j < cols; j++) {
    foreach (var dir in directions) {
      bool isMatch = true;

      // check all the chars in that direction
      for (int k = 0; k < wordLength; k++) {
        int newRow = i + k * dir[0];
        int newCol = j + k * dir[1];

        if (newRow < 0 || newRow >= rows || newCol < 0 || newCol >= cols || grid[newRow, newCol] != word[k]) {
          isMatch = false;
          break;
        }
      }

      // increment if all chars are found
      if (isMatch) {
        count1++;
      }
    }
  }
}

// part 1 answer
Console.WriteLine($"p1: {count1}");

int count2 = 0;

// search each cell in the grid
for (int centerY = 0; centerY < rows; centerY++) {
  for (int centerX = 0; centerX < cols; centerX++) {
    // center needs to be 'A'
    if (grid[centerY, centerX] == 'A') {
      // top left to bottom right
      int x1 = centerX - 1, y1 = centerY - 1;
      int x2 = centerX + 1, y2 = centerY + 1;
      bool diag1 = x1 >= 0 && y1 >= 0 && x2 < cols && y2 < rows &&
                        ((grid[y1, x1] == 'S' && grid[y2, x2] == 'M') ||
                         (grid[y1, x1] == 'M' && grid[y2, x2] == 'S'));

      // top right to bottom left
      int x3 = centerX - 1, y3 = centerY + 1;
      int x4 = centerX + 1, y4 = centerY - 1;
      bool diag2 = x3 >= 0 && y3 < rows && x4 < cols && y4 >= 0 &&
                        ((grid[y3, x3] == 'S' && grid[y4, x4] == 'M') ||
                         (grid[y3, x3] == 'M' && grid[y4, x4] == 'S'));

      // increment if both diagonals are found
      if (diag1 && diag2) {
        count2++;
      }
    }
  }
}

// part 2 answer
Console.WriteLine($"p2: {count2}");
