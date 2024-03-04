class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();

        graph.AddVertex(1);
        graph.AddVertex(2);
        graph.AddVertex(3);
        graph.AddVertex(4);
        graph.AddVertex(5);

        graph.AddEdge(1, 2);
        graph.AddEdge(2, 4);
        graph.AddEdge(2, 3);
        graph.AddEdge(4, 3);
        graph.AddEdge(4, 1);
        graph.AddEdge(1, 5);

        List<int> unreachable = graph.GetUnreachableVertices();
        Console.WriteLine("Unreachable vertices:");
        foreach (int vertex in unreachable)
        {
            Console.WriteLine(vertex);
        }

        Dictionary<int, int> reachable = graph.GetReachableVertices();
        Console.WriteLine("\nReachable vertices:");
        foreach (KeyValuePair<int, int> pair in reachable)
        {
            Console.WriteLine($"Vertex {pair.Key}: {pair.Value} reachable vertices");
        }

        Console.ReadLine();
    }
}