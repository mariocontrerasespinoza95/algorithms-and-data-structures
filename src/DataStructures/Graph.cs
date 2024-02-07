namespace DataStructures;

internal sealed class Graph
{
    public static void ProgramPrint()
    {
        var graph = new Graph();
        graph.AddNode("A");
        graph.AddNode("B");
        graph.AddNode("C");
        graph.AddNode("D");
        graph.AddEdge("A", "B");
        graph.AddEdge("B", "D");
        graph.AddEdge("D", "C");
        graph.AddEdge("A", "C");
        graph.TraverseDepthFirst("A");
        List<string> list = graph.TopologicalSort();
        Console.WriteLine(Array.ToString(list.ToArray()));
    }

    private class Node(string label)
    {
        internal readonly string Label = label;

        public override string ToString() => Label;
    }

    private readonly Dictionary<string, Node> _nodes = [];
    private readonly Dictionary<Node, List<Node>> _adjacencyList = [];

    private void AddNode(string label)
    {
        var node = new Node(label);
        _nodes[label] = node;
        _adjacencyList[node] = [];
    }

    private void AddEdge(string from, string to)
    {
        Node fromNode = _nodes[from];
        ArgumentNullException.ThrowIfNull(fromNode);

        Node toNode = _nodes[to];
        ArgumentNullException.ThrowIfNull(toNode);

        _adjacencyList[fromNode].Add(toNode);
    }

    public void Print()
    {
        foreach (Node? source in _adjacencyList.Keys)
        {
            List<Node> targets = _adjacencyList[source];
            if (targets.Count > 0)
            {
                Console.WriteLine(source + " is connected to " + Array.ToString(targets.ToArray()));
            }
        }
    }

    public void RemoveNode(string label)
    {
        _nodes.TryGetValue(label, out Node? node);
        if (node == null)
        {
            return;
        }

        foreach (Node n in _adjacencyList.Keys)
        {
            _adjacencyList[n].Remove(node);
        }

        _adjacencyList.Remove(node);
        _nodes.Remove(label);
    }

    public void RemoveEdge(string from, string to)
    {
        _nodes.TryGetValue(from, out Node fromNode);
        _nodes.TryGetValue(to, out Node toNode);

        if (fromNode == null || toNode == null)
        {
            return;
        }

        _adjacencyList[fromNode].Remove(toNode);
    }

    public void TraverseDepthFirstRecursive(string root)
    {
        if (!_nodes.TryGetValue(root, out Node? node))
        {
            return;
        }

        TraverseDepthFirstRecursive(node, []);
    }

    private void TraverseDepthFirstRecursive(Node root, HashSet<Node> visited)
    {
        Console.WriteLine(root);
        visited.Add(root);

        foreach (Node? node in _adjacencyList[root])
        {
            if (!visited.Contains(node))
            {
                TraverseDepthFirstRecursive(node, visited);
            }
        }
    }

    private void TraverseDepthFirst(string root)
    {
        if (!_nodes.TryGetValue(root, out Node? node))
        {
            return;
        }

        Stack<Node> visited = [];

        Stack<Node> stack = [];
        stack.Push(node);

        while (stack.Count > 0)
        {
            Node current = stack.Pop();

            if (visited.Contains(current))
            {
                continue;
            }

            Console.WriteLine(current);
            visited.Push(current);

            foreach (Node? neighbour in _adjacencyList[current])
            {
                if (!visited.Contains(neighbour))
                {
                    stack.Push(neighbour);
                }
            }
        }
    }

    public void TraverseBreadthFirst(string root)
    {
        if (!_nodes.TryGetValue(root, out Node? node))
        {
            return;
        }

        HashSet<Node> visited = [];

        Queue<Node> queue = [];
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();

            if (visited.Contains(current))
            {
                continue;
            }

            Console.WriteLine(current);
            visited.Add(current);

            foreach (Node? neighbour in _adjacencyList[current])
            {
                if (!visited.Contains(neighbour))
                {
                    queue.Enqueue(neighbour);
                }
            }
        }
    }

    private List<string> TopologicalSort()
    {
        HashSet<Node> visited = [];
        Stack<Node> stack = [];

        foreach (Node? node in _nodes.Values)
        {
            TopologicalSort(node, visited, stack);
        }

        List<string> sorted = [];
        while (stack.Count > 0)
        {
            sorted.Add(stack.Pop().Label);
        }

        return sorted;
    }

    private void TopologicalSort(Node node, HashSet<Node> visited, Stack<Node> stack)
    {
        if (!visited.Add(node))
        {
            return;
        }

        foreach (Node? neighbour in _adjacencyList[node])
        {
            TopologicalSort(neighbour, visited, stack);
        }

        stack.Push(node);
    }

    public bool HasCycle()
    {
        HashSet<Node> all = [];
        foreach (Node? node in _nodes.Values)
        {
            all.Add(node);
        }

        HashSet<Node> visiting = [];
        HashSet<Node> visited = [];

        while (all.Count > 0)
        {
            Node current = all.First();
            if (HasCycle(current, all, visiting, visited))
            {
                return true;
            }
        }

        return false;
    }

    private bool HasCycle(
        Node node,
        HashSet<Node> all,
        HashSet<Node> visiting,
        HashSet<Node> visited)
    {
        all.Remove(node);
        visiting.Add(node);

        foreach (Node? neighbour in _adjacencyList[node])
        {
            if (visited.Contains(neighbour))
            {
                continue;
            }

            if (visiting.Contains(neighbour))
            {
                return true;
            }

            if (HasCycle(neighbour, all, visiting, visited))
            {
                return true;
            }
        }

        visiting.Remove(node);
        visited.Add(node);

        return false;
    }
}
