namespace Trees;

internal sealed class Tree
{
    public static void ProgramPrint()
    {
        
    }

    private class Node(int value)
    {
        internal int Value { get; init; } = value;
        internal Node? LeftChild { get; set; }
        internal Node? RightChild { get; set; }

        public override string ToString()
        {
            return "Node=" + Value;
        }
    }

    private Node? _root;

    public void Insert(int value)
    {
        var node = new Node(value);

        if (_root == null)
        {
            _root = node;
            return;
        }

        Node current = _root;
        while (true)
        {
            if (value < current.Value)
            {
                if (current.LeftChild == null)
                {
                    current.LeftChild = node;
                    break;
                }
                current = current.LeftChild;
            }
            else
            {
                if (current.RightChild == null)
                {
                    current.RightChild = node;
                    break;
                }
                current = current.RightChild;
            }
        }
    }

    public bool Find(int value)
    {
        Node? current = _root;
        while (current != null)
        {
            if (value < current.Value)
            {
                current = current.LeftChild;
            }
            else if (value > current.Value)
            {
                current = current.RightChild;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    public void TraversePreOrder() => TraversePreOrder(_root);
    private static void TraversePreOrder(Node? root)
    {
        if (root == null)
        {
            return;
        }

        Console.WriteLine(root);
        TraversePreOrder(root.LeftChild!);
        TraversePreOrder(root.RightChild!);
    }

    public void TraverseInOrder() => TraverseInOrder(_root);
    private static void TraverseInOrder(Node? root)
    {
        if (root == null)
        {
            return;
        }

        TraverseInOrder(root.LeftChild!);
        Console.WriteLine(root);
        TraverseInOrder(root.RightChild!);
    }

    public int Height() => Height(_root);
    private static int Height(Node? root)
    {
        ArgumentNullException.ThrowIfNull(root);

        if (IsLeaf(root))
        {
            return 0;
        }

        return 1 + Math.Max(Height(root.LeftChild!), Height(root.RightChild!));
    }

    // O(log n)
    public int Min()
    {
        if (_root == null)
        {
            throw new Exception();
        }

        Node? current = _root;
        Node? last = current;
        while (current != null)
        {
            last = current;
            current = current.LeftChild;
        }

        return last.Value;
    }

    // O(n)
    private static int Min(Node root)
    {
        if (IsLeaf(root))
        {
            return root.Value;
        }

        int left = Min(root.LeftChild!);
        int right = Min(root.RightChild!);

        return Math.Min(Math.Min(left, right), root.Value);
    }

    private bool Equals(Tree? other) => other != null && Equals(_root, other._root);
    
    private static bool Equals(Node? first, Node? second)
    {
        if (first == null && second == null)
        {
            return true;
        }

        if (first != null && second != null)
        {
            return first.Value == second.Value
                   && Equals(first.LeftChild, second.LeftChild)
                   && Equals(first.RightChild, second.RightChild);
        }

        return false;
    }

    public bool IsBinarySearchTree() => IsBinarySearchTree(_root, int.MinValue, int.MaxValue);
    private static bool IsBinarySearchTree(Node? root, int min, int max)
    {
        if (root == null)
        {
            return true;
        }

        if (root.Value < min || root.Value > max)
        {
            return false;
        }

        return IsBinarySearchTree(root.LeftChild, min, max: root.Value - 1)
               && IsBinarySearchTree(root.RightChild, min: root.Value + 1, max);
    }

    public List<int> GetNodesAtDistance(int distance)
    {
        var list = new List<int>();
        GetNodesAtDistance(_root, distance, list);
        return list;
    }

    private static void GetNodesAtDistance(Node? root, int distance, ICollection<int> list)
    {
        if (root == null)
        {
            return;
        }

        if (distance == 0)
        {
            list.Add(root.Value);
            return;
        }

        GetNodesAtDistance(root.LeftChild, distance - 1, list);
        GetNodesAtDistance(root.RightChild, distance - 1, list);
    }

    public void TraverseLevelOrder()
    {
        for (int i = 0; i <= Height(); i++)
        {
            List<int> list = GetNodesAtDistance(i);
            foreach (int value in list)
            {
                Console.WriteLine(value);
            }
        }
    }

    private static bool IsLeaf(Node? node) => node is { LeftChild: null, RightChild: null };
}
