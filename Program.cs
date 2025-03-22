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
//using LeetCodeHackerRankAlgorithms.InMemoryDatabase;

//InMemoryDb memoryDb = new InMemoryDb();

//string[][] queries = [
//  ["SET_OR_INC", "A", "B", "5"],
//  ["SET_OR_INC", "A", "B", "6"],
//  ["GET", "A", "B"],
//  ["GET", "A", "C"],
//  ["DELETE", "A", "B"],
//  ["DELETE", "A", "C"]
//];
#endregion

#region BFS
using LeetCodeHackerRankAlgorithms.BFS;

List<int>[] adj = new List<int>[5];
adj[0] = new List<int> { 2, 3, 1 };
adj[1] = new List<int> { 0 };
adj[2] = new List<int> { 0, 4 };
adj[3] = new List<int> { 0 };
adj[4] = new List<int> { 2 };

int src = 0;
List<int> ans = BreadthFirstSearch.BFSOfGraph(adj, src);
foreach (int a in ans)
{
    Console.Write(a + " ");
}
#endregion