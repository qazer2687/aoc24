string filePath = "./input";

var arr1 = new List<string>();

int safe1 = 0;
int safe2 = 0;

// seperate reports by line
foreach (string line in File.ReadLines(filePath)) {
  // create an array for each report
  int[] arr = line.Split(' ').Select(int.Parse).ToArray();

  // check if array is strictly ascending or descending
  if (Enumerable.Range(1, arr.Length - 1).All(i => arr[i] > arr[i - 1]) ||
    Enumerable.Range(1, arr.Length - 1).All(i => arr[i] < arr[i - 1])) {
    // check if the difference between elements is 1..3
    if (Enumerable.Range(1, arr.Length - 1).All(i => Math.Abs(arr[i] - arr[i - 1]) >= 1 && Math.Abs(arr[i] - arr[i - 1]) <= 3)) {
      safe1++;
      safe2++;
      continue;
    }
  }
  
  for (int removeIndex = 0; removeIndex < arr.Length; removeIndex++) {
    // remove each element of the array and loop through
    int[] arr2 = arr.Where((_, index) => index != removeIndex).ToArray();

    // do the same checks again
    if (Enumerable.Range(1, arr2.Length - 1).All(i => arr2[i] > arr2[i - 1]) ||
      Enumerable.Range(1, arr2.Length - 1).All(i => arr2[i] < arr2[i - 1])) {
      if (Enumerable.Range(1, arr2.Length - 1).All(i => Math.Abs(arr2[i] - arr2[i - 1]) >= 1 && Math.Abs(arr2[i] - arr2[i - 1]) <= 3)) {
        safe2++;
        break;
      }
    }
  }
}

// part 1 answer
Console.WriteLine(Convert.ToString(safe1));

// part 2 answer
Console.WriteLine(Convert.ToString(safe2));


