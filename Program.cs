#region Sliding Window
//Sliding Window
//using LeetCodeHackerRankAlgorithms.SlidingWindow;

//SlidingWindow slidingWindow = new SlidingWindow();
//Console.WriteLine("{0}", slidingWindow.LongestSubString("bbbbb"));
//Console.ReadLine();
#endregion

#region Two Sum
//using LeetCodeHackerRankAlgorithms.TwoSum;

//TwoSum twoSum = new TwoSum();
//int[] nums = [2, 5, 5, 11];
//int target = 10;
//twoSum.TwoSumSolution(nums, target);
//Console.ReadLine();
#endregion

#region InMemoryDatabase
using LeetCodeHackerRankAlgorithms.InMemoryDatabase;

InMemoryDb memoryDb = new InMemoryDb();

string[][] queries = [
  ["SET_OR_INC", "A", "B", "5"],
  ["SET_OR_INC", "A", "B", "6"],
  ["GET", "A", "B"],
  ["GET", "A", "C"],
  ["DELETE", "A", "B"],
  ["DELETE", "A", "C"]
];

SlidingWindow slidingWindow = new SlidingWindow();
Console.WriteLine("{0}", slidingWindow.LongestSubString("pwwkew"));
Console.ReadLine();

