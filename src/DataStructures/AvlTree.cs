namespace DataStructures;

internal sealed class AvlTree
{
    public static void ProgramPrint()
    {
        var tree = new AvlTree();
        tree.Insert(10);
        tree.Insert(20);
        tree.Insert(30);
    }

    private class AvlNode(int value)
    {
        internal int Value { get; init; } = value;
        internal int Height { get; set; }
        internal AvlNode? LeftChild { get; set; }
        internal AvlNode? RightChild { get; set; }

        public override string ToString()
        {
            return "Value=" + Value;
        }
    }

    private AvlNode? _root;

    private void Insert(int value) => _root = Insert(_root, value);
    private static AvlNode Insert(AvlNode? root, int value)
    {
        var node = new AvlNode(value);

        if (root == null)
        {
            return node;
        }

        if (value < root.Value)
        {
            root.LeftChild = Insert(root.LeftChild, value);
        }
        else
        {
            root.RightChild = Insert(root.RightChild, value);
        }

        SetHeight(root);

        return Balance(root);
    }

    private static AvlNode Balance(AvlNode root)
    {
        if (IsLeftHeavy(root))
        {
            if (BalanceFactor(root.LeftChild!) < 0)
            {
                root.LeftChild = RotateLeft(root.LeftChild!);
            }

            return RotateRight(root);
        }
        else if (IsRightHeavy(root))
        {
            if (BalanceFactor(root.RightChild!) > 0)
            {
                root.RightChild = RotateRight(root.RightChild!);
            }

            return RotateLeft(root);
        }

        return root;
    }

    private static AvlNode RotateLeft(AvlNode root)
    {
        AvlNode? newRoot = root.RightChild;

        root.RightChild = newRoot!.LeftChild;
        newRoot.LeftChild = root;

        SetHeight(root);
        SetHeight(newRoot);
        return newRoot;
    }

    private static AvlNode RotateRight(AvlNode root)
    {
        AvlNode? newRoot = root.LeftChild;

        root.LeftChild = newRoot!.RightChild;
        newRoot.RightChild = root;

        SetHeight(root);
        SetHeight(newRoot);
        return newRoot;
    }

    private static void SetHeight(AvlNode root) => root.Height = Math.Max(
                GetNodeHeight(root.LeftChild!),
                GetNodeHeight(root.RightChild!)) + 1;

    private static bool IsLeftHeavy(AvlNode node) => BalanceFactor(node) > 1;
    private static bool IsRightHeavy(AvlNode node) => BalanceFactor(node) < -1;
    private static int BalanceFactor(AvlNode? node) => node == null ? 0 : GetNodeHeight(node.LeftChild!) - GetNodeHeight(node.RightChild!);
    private static int GetNodeHeight(AvlNode? node) => node?.Height ?? -1;
}
