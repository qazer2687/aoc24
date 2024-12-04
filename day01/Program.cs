using System;
using System.IO;

string filePath = "./input";

var arr1 = new List<int>();
var arr2 = new List<int>();
var arr3 = new List<int>();
var arr4 = new List<double>();

int result1 = 0;
int result2 = 0;

// parse arrays
foreach (string line in File.ReadLines(filePath)) {
  string[] parts = line.Split("   ");

  int num1 = int.Parse(parts[0]);
  int num2 = int.Parse(parts[1]);

  arr1.Add(num1);
  arr2.Add(num2);
}

// order arrays ascending
arr1.Sort();
arr2.Sort();

// find difference
for (int i = 0; i < 1000; i++) {
  arr3.Add(Math.Abs(arr1[i] - arr2[i]));
}

// sum
foreach (int num in arr3) {
  result1 += num;
}

Console.WriteLine($"p1: {result1}");

// create array of similarity scores
foreach (int num1 in arr1) {
  int count = 0;
  foreach (int num2 in arr2) {
    if (num1 == num2) {
      count++;
    }
  }
  var score = num1 * count;
  arr4.Add(score);
}

// sum
foreach (int num in arr4) {
  result2 += num;
}

Console.WriteLine($"p2: {result2}");