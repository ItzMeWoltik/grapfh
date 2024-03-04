public class Vertex
{
    public int Number { get; set; }
    public List<Vertex> Neighbors { get; set; }

    public Vertex(int number)
    {
        Number = number;
        Neighbors = new List<Vertex>();
    }
}