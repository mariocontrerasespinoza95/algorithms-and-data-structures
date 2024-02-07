namespace DataStructures;

internal class WeightedGraph
{
    public static void ProgramPrint()
    {
        var graph = new WeightedGraph();
        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddNode("D");
        graph.AddEdge(from: "A", to: "B", weight: 3);
        graph.AddEdge(from: "B", to: "D", weight: 4);
        graph.AddEdge(from: "C", to: "D", weight: 5);
        graph.AddEdge(from: "A", to: "C", weight: 1);
        graph.AddEdge(from: "B", to: "C", weight: 2);
        WeightedGraph tree = graph.GetMinimumSpanningTree();
        tree.Print();
    }

    private class Node(string label)
    {
        internal readonly string Label = label;
        private readonly List<Edge> _edges = [];

        public override string ToString() => Label;

        public void AddEdge(Node to, int weight) => _edges.Add(new Edge(this, to, weight));

        public List<Edge> GetEdges() => _edges;
    }

    private class Edge(Node from, Node to, int weight)
    {
        internal readonly Node From = from;
        internal readonly Node To = to;
        internal readonly int Weight = weight;

        public override string ToString() => From + "->" + To;
    }

    private readonly Dictionary<string, Node> _nodes = [];

    private void AddNode(string label) => _nodes[label] = new Node(label);

    private void AddEdge(string from, string to, int weight)
    {
        _nodes.TryGetValue(from, out Node fromNode);
        ArgumentNullException.ThrowIfNull(fromNode);

        _nodes.TryGetValue(to, out Node toNode);
        ArgumentNullException.ThrowIfNull(toNode);

        fromNode.AddEdge(toNode, weight);
        toNode.AddEdge(fromNode, weight);
    }

    private void Print()
    {
        foreach (Node node in _nodes.Values)
        {
            List<Edge> edges = node.GetEdges();
            if (edges.Count > 0)
            {
                Console.WriteLine(node + " is connected to " + Array.ToString(edges.ToArray()));
            }
        }
    }

    public Path GetShortestPath(string from, string to)
    {
        _nodes.TryGetValue(from, out Node fromNode);
        ArgumentNullException.ThrowIfNull(fromNode);

        _nodes.TryGetValue(to, out Node toNode);
        ArgumentNullException.ThrowIfNull(toNode);

        Dictionary<Node, int> distances = [];
        foreach (Node node in _nodes.Values)
        {
            distances[node] = int.MaxValue;
        }

        distances[fromNode] = 0;

        Dictionary<Node, Node> previousNodes = [];
        HashSet<Node> visited = [];

        PriorityQueue<Node, int> queue = new(
            Comparer<int>.Default
        );

        queue.Enqueue(fromNode, 0);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            visited.Add(current);

            foreach (Edge edge in current.GetEdges())
            {
                if (visited.Contains(edge.To))
                {
                    continue;
                }

                int newDistance = distances[current] + edge.Weight;
                if (newDistance >= distances[edge.To])
                {
                    continue;
                }

                distances[edge.To] = newDistance;
                previousNodes[edge.To] = current;
                queue.Enqueue(edge.To, newDistance);
            }
        }

        return BuildPath(previousNodes, toNode);
    }

    private static Path BuildPath(
        IReadOnlyDictionary<Node, Node> previousNodes,
        Node toNode)
    {
        Stack<Node> stack = [];
        stack.Push(toNode);
        Node previous = previousNodes[toNode];
        while (previous != null)
        {
            stack.Push(previous);
            previousNodes.TryGetValue(previous, out previous);
        }

        var path = new Path();
        while (stack.Count > 0)
        {
            path.Add(stack.Pop().Label);
        }

        return path;
    }

    public bool HasCycle()
    {
        HashSet<Node> visited = [];

        return _nodes.Values.Any(node => !visited.Contains(node) && HasCycle(node, null, visited));
    }

    private static bool HasCycle(
        Node node,
        Node? parent,
        ISet<Node> visited)
    {
        visited.Add(node);

        foreach (Edge edge in node.GetEdges().Where(edge => edge.To != parent))
        {
            if (visited.Contains(edge.To))
            {
                return true;
            }

            if (HasCycle(edge.To, node, visited))
            {
                return true;
            }
        }

        return false;
    }

    private WeightedGraph GetMinimumSpanningTree()
    {
        var tree = new WeightedGraph();

        if (_nodes.Count == 0)
        {
            return tree;
        }

        var edges = new PriorityQueue<Edge, int>(Comparer<int>.Default);

        Node startNode = _nodes.Values.First();
        foreach (Edge edge in startNode.GetEdges())
        {
            edges.Enqueue(edge, edge.Weight);
        }

        tree.AddNode(startNode.Label);

        while (tree._nodes.Count < _nodes.Count)
        {
            Edge minEdge = edges.Dequeue();
            Node nextNode = minEdge.To;

            if (tree.ContainsNode(nextNode.Label))
            {
                continue;
            }

            tree.AddNode(nextNode.Label);
            tree.AddEdge(from: minEdge.From.Label, to: nextNode.Label, weight: minEdge.Weight);

            foreach (Edge edge in nextNode.GetEdges().Where(edge => !tree.ContainsNode(edge.To.Label)))
            {
                edges.Enqueue(edge, edge.Weight);
            }
        }

        return tree;
    }

    private bool ContainsNode(string label) => _nodes.ContainsKey(label);
}
