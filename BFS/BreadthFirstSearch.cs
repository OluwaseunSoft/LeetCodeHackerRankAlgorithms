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

        public static List<(int, int)> BFS(int[,] maze, (int, int) start, (int, int) goal)
        {
            string[] directions = ["up", "right", "down", "left"];
            var queueItem = new Queue<(int, int)>();
            queueItem.Enqueue(start);
            var predecessors = new Dictionary<(int, int), (int, int)>();
            predecessors.Add(start, (0, 0));

            while (queueItem.Count != 0)
            {
                int row_offset, col_offset = 0;
                (int, int) neighbour;
                var currentCell = queueItem.Dequeue();
                if (currentCell == goal)
                    return GetPath(predecessors, start, goal);
                foreach (string direction in directions)
                {
                    var directionValues = Offsets()[direction];
                    row_offset = directionValues.Item1;
                    col_offset = directionValues.Item2;
                    neighbour = (currentCell.Item1 + row_offset, currentCell.Item2 + col_offset);
                    if (IsLegal(maze, neighbour) && !predecessors.ContainsKey(neighbour))
                    {
                        queueItem.Enqueue(neighbour);
                        predecessors.Add(neighbour, currentCell);
                    }
                }
            }
            return new List<(int, int)>();
        }

        private static List<(int, int)> GetPath(Dictionary<(int, int), (int, int)> predecessors, (int, int) start, (int, int) goal)
        {
            (int, int) current = goal;
            List<(int, int)> path = new List<(int, int)>();
            while (current != start)
            {
                path.Add(current);
                current = predecessors[current];
            }
            path.Add(start);
            path.Reverse();
            return path;
        }

        private static Dictionary<string, (int, int)> Offsets()
        {
            return new Dictionary<string, (int, int)>() { { "right", (0, 1) },
                { "left", (0, -1) },
                { "up", (-1, 0) },
                { "down", (1, 0)} };
        }

        private static bool IsLegal(int[,] maze, (int, int) neighbour)
        {
            int i = neighbour.Item1;
            int j = neighbour.Item2;
            int numRows = maze.GetLength(0);
            int numCols = maze.GetLength(1);
            return (0 <= i && i < numRows) && (0 <= j && j < numCols) && maze[i, j] != 0;
        }

        public static List<List<char>> ReadMaze(string path)
        {
            try
            {
                var lines = File.ReadAllLines(path);
                var maze = new List<List<char>>();

                if (lines.Length == 0)
                {
                    Console.WriteLine("Empty maze file");
                    Environment.Exit(1);
                }
                var expectedWidth = lines[0].Trim('\n').Length;
                foreach (var line in lines)
                {
                    var trimmedLine = line.Trim('\n');
                    if (trimmedLine.Length != expectedWidth)
                    {
                        Console.WriteLine("This is not a rectangular maze");
                        Environment.Exit(1);
                    }
                    maze.Add(trimmedLine.ToList());
                }
                return maze;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file not found");
                Environment.Exit(1);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An I/O error occurred: {ex.Message}");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Environment.Exit(1);
            }
            return null;
        }
    }
}
