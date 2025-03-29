using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeHackerRankAlgorithms.BFS
{
    internal class BreadthFirstSearch
    {
        public static List<int> BFSOfGraph(List<int>[] adj, int s)
        {
            try
            {
                int v = adj.Length;
                List<int> result = new List<int>();
                Queue<int> q = new Queue<int>();
                bool[] visited = new bool[v];
                visited[s] = true;
                q.Enqueue(s);
                while (q.Count > 0)
                {
                    int curr = q.Dequeue();
                    result.Add(curr);

                    foreach (int i in adj[curr])
                    {
                        if (!visited[i])
                        {
                            visited[i] = true;
                            q.Enqueue(i);
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<int>();
            }
        }

        public static List<int> BFSAllVerticeGraph(List<int>[] adj, int s, bool[] visited, List<int> res)
        {
            try
            {
                Queue<int> q = new Queue<int>();
                visited[s] = true;
                q.Enqueue(s);

                while (q.Count > 0)
                {
                    int curr = q.Dequeue();
                    res.Add(curr);

                    foreach (int i in adj[curr])
                    {
                        if (!visited[i])
                        {
                            visited[i] = true;
                            q.Enqueue(i);
                        }
                    }
                }
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<int>();
            }
        }

        public static List<int> BFSDisconnectedGraph(List<int>[] adj)
        {
            int v = adj.Length;

            List<int> res = new List<int>();
            bool[] visited = new bool[v];

            for (int i = 0; i < v; i++)
            {
                if (!visited[i])
                {
                    BFSAllVerticeGraph(adj, i, visited, res);
                }
            }
            return res;
        }

        public static Tuple<int, int> BFS(int[,] ints, (int, int) start, (int, int) goal)
        {
            var queueItem = new Queue<(int, int)>();
            var predecessors = new Dictionary<(int, int), (int?, int?)>();
            predecessors.Add(start, (null, null));

            return new Tuple<int, int>(0,0);
        }
    }
}
