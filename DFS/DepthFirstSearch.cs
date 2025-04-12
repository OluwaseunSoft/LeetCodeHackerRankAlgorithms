using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHackerRankAlgorithms.DFS
{
    public class DepthFirstSearch
    {
        public static List<(int, int)> DFS(int[,] maze, (int, int) start, (int, int) goal)
        {
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push(start);
            Dictionary<(int, int), (int, int)> predecessors = new Dictionary<(int, int), (int, int)>();
            predecessors.Add(start, (0, 0));

            while (stack.Count != 0)
            {

            }

            return new List<(int, int)>(stack.ToArray());
        }
    }
}
