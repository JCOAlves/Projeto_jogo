using System.Collections.Generic;
using UnityEngine;

public class MazeGraph
{
    private Dictionary<Vector2Int, List<Vector2Int>> adjacency 
        = new Dictionary<Vector2Int, List<Vector2Int>>();

    public void AddEdge(Vector2Int a, Vector2Int b)
    {
        if (!adjacency.ContainsKey(a)) adjacency[a] = new List<Vector2Int>();
        if (!adjacency.ContainsKey(b)) adjacency[b] = new List<Vector2Int>();
        adjacency[a].Add(b);
        adjacency[b].Add(a);
    }

    public List<Vector2Int> FindPath(Vector2Int start, Vector2Int goal)
    {
        var q = new Queue<Vector2Int>();
        var visited = new HashSet<Vector2Int>();
        var parent = new Dictionary<Vector2Int, Vector2Int>();

        q.Enqueue(start);
        visited.Add(start);

        while (q.Count > 0)
        {
            var cur = q.Dequeue();
            if (cur == goal) break;

            foreach (var next in adjacency[cur])
            {
                if (!visited.Contains(next))
                {
                    visited.Add(next);
                    parent[next] = cur;
                    q.Enqueue(next);
                }
            }
        }

        // Reconstruct path
        var path = new List<Vector2Int>();
        if (!parent.ContainsKey(goal) && goal != start) return path;

        var pos = goal;
        while (pos != start)
        {
            path.Add(pos);
            pos = parent[pos];
        }
        path.Add(start);
        path.Reverse();
        return path;
    }
}