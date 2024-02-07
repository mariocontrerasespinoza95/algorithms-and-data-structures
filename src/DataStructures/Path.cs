namespace DataStructures;

internal sealed class Path
{
    private readonly List<string> _nodes = [];

    public void Add(string node) => _nodes.Add(node);

    public override string ToString()
    {
        return Array.ToString(_nodes.ToArray());
    }
}
