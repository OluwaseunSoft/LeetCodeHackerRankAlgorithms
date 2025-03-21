// See https://aka.ms/new-console-template for more information

#region Sliding Window
//Sliding Window
//using LeetCodeHackerRankAlgorithms.SlidingWindow;

//SlidingWindow slidingWindow = new SlidingWindow();


//Console.WriteLine("{0}", slidingWindow.LongestSubString("pwwkew"));
//Console.ReadLine();
#endregion
using LeetCodeHackerRankAlgorithms.BFS;

List<int>[] adj = new List<int>[5];
adj[0] = new List<int> { 2, 3, 1 };
adj[1] = new List<int> { 0 };
adj[2] = new List<int> { 0, 4 };
adj[3] = new List<int> { 0 };
adj[4] = new List<int> { 2 };

int src = 0;
List<int> ans = BreadthFirstSearch.BFSOfGraph(adj, src);
foreach (int n in ans)
{
    Console.Write(n + " ");
}

Console.ReadLine();


