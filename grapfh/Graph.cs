public class Graph
{
    private List<Vertex> vertices;

    public Graph()
    {
        vertices = new List<Vertex>();
    }

    public void AddVertex(int number)
    {
        vertices.Add(new Vertex(number));
    }

    public void AddEdge(int from, int to)
    {
        Vertex fromVertex = vertices.Find(v => v.Number == from);
        Vertex toVertex = vertices.Find(v => v.Number == to);

        if (fromVertex != null && toVertex != null)
        {
            fromVertex.Neighbors.Add(toVertex);
        }
    }

    public List<int> GetUnreachableVertices()
    {
        List<int> unreachable = new List<int>();
        HashSet<Vertex> visited = new HashSet<Vertex>();

        foreach (Vertex vertex in vertices)
        {
            if (DFS(vertex, visited, false) == 0)
            {
                unreachable.Add(vertex.Number);
            }
        }

        return unreachable;
    }

    public Dictionary<int, int> GetReachableVertices()
    {
        Dictionary<int, int> reachable = new Dictionary<int, int>();
        HashSet<Vertex> visited = new HashSet<Vertex>();

        foreach (Vertex vertex in vertices)
        {
            reachable[vertex.Number] = DFS(vertex, visited, true);
        }

        return reachable;
    }

    private int DFS(Vertex vertex, HashSet<Vertex> visited, bool countReachable)
    {
        visited.Add(vertex);

        int count = countReachable ? 1 : 0;
        foreach (Vertex neighbor in vertex.Neighbors)
        {
            if (!visited.Contains(neighbor))
            {
                count += DFS(neighbor, visited, countReachable);
            }
        }

        return count;
    }
}