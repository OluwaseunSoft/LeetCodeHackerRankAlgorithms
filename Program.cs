#region Sliding Window
//Sliding Window
//using LeetCodeHackerRankAlgorithms.SlidingWindow;

//SlidingWindow slidingWindow = new SlidingWindow();
//Console.WriteLine("{0}", slidingWindow.LongestSubString("bbbbb"));
//Console.ReadLine();
#endregion

using LeetCodeHackerRankAlgorithms.TwoSum;

TwoSum twoSum = new TwoSum();
int[] nums = [3, 2, 4];
int target = 6;
Console.WriteLine("{0}", twoSum.TwoSumSolution(nums, target));
Console.ReadLine();
