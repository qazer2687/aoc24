using System.Text.RegularExpressions;

string filePath = "./input";
var input = File.ReadAllText(filePath);

var arr1 = new List<int>();

string pattern1 = @"mul\((\d+),(\d+)\)";
var matches1 = Regex.Matches(input, pattern1);

// split the two numbers and multiply them
foreach (Match match in matches1) {
  int val1 = int.Parse(match.Groups[1].Value);
  int val2 = int.Parse(match.Groups[2].Value);
  arr1.Add(val1 * val2);
}

// part 1
Console.WriteLine(Convert.ToString(arr1.Sum()));

var arr2 = new List<int>();

// track the state, starting as true
bool mul = true;

string pattern2 = @"do\(\)|don't\(\)|mul\((\d+),(\d+)\)";
var matches2 = Regex.Matches(input, pattern2);

foreach (Match match in matches2) {
  if (match.Value == "do()") {
    mul = true;
  } else if (match.Value == "don't()") {
    mul = false;
  } else if (mul && match.Groups[1].Success && match.Groups[2].Success) {
    int val1 = int.Parse(match.Groups[1].Value);
    int val2 = int.Parse(match.Groups[2].Value);
    arr2.Add(val1 * val2);
  }
}

// part 2
Console.WriteLine(Convert.ToString(arr2.Sum()));