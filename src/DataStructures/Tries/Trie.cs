namespace Tries;

internal sealed class Trie
{
    private class Node(char value)
    {
        internal char Value { get; init; } = value;
        private readonly Dictionary<char, Node> _children = [];
        internal bool IsEndOfWord { get; set; }

        public override string ToString() => "value=" + Value;

        internal bool HasChild(char ch) => _children.ContainsKey(ch);

        internal void AddChild(char ch) => _children[ch] = new Node(ch);

        internal Node? GetChild(char ch)
        {
            _children.TryGetValue(ch, out Node? child);
            return child;
        }

        internal IEnumerable<Node> GetChildren() => _children.Values.ToArray();

        internal bool HasChildren() => _children.Count > 0;

        internal void RemoveChild(char ch) => _children.Remove(ch);
    }

    private readonly Node _root = new(' ');

    public void Insert(string word)
    {
        ArgumentNullException.ThrowIfNull(word);

        Node current = _root;
        foreach (char ch in word)
        {
            if (!current!.HasChild(ch))
            {
                current.AddChild(ch);
            }

            current = current.GetChild(ch);
        }

        current!.IsEndOfWord = true;
    }

    public bool Contains(string? word)
    {
        if (word == null)
        {
            return false;
        }

        Node current = _root;
        foreach (char ch in word)
        {
            if (!current!.HasChild(ch))
            {
                return false;
            }

            current = current.GetChild(ch);
        }

        return current!.IsEndOfWord;
    }

    public void Traverse() => Traverse(_root);
    private static void Traverse(Node root)
    {
        Console.WriteLine(root.Value);

        foreach (Node? child in root.GetChildren())
        {
            Traverse(child);
        }
    }

    public void Remove(string? word)
    {
        if (word == null)
        {
            return;
        }

        Remove(_root, word, 0);
    }
    private static void Remove(Node? root, string word, int index)
    {
        if (root == null)
        {
            return;
        }
        
        if (index == word.Length)
        {
            root.IsEndOfWord = false;
            return;
        }

        char ch = word[index];
        Node? child = root.GetChild(ch);

        Remove(child, word, index + 1);

        if (child != null && !child.HasChildren() && !child.IsEndOfWord)
        {
            root.RemoveChild(ch);
        }
    }

    public List<string> FindWords(string prefix)
    {
        var words = new List<string>();
        Node? lastNode = FindLastNodeOf(prefix);
        FindWords(lastNode, prefix, words);

        return words;
    }

    private static void FindWords(Node? root, string prefix, List<string> words)
    {
        if (root == null)
        {
            return;
        }

        if (root.IsEndOfWord)
        {
            words.Add(prefix);
        }

        foreach (Node? child in root.GetChildren())
        {
            FindWords(child, prefix + child.Value, words);
        }
    }

    private Node? FindLastNodeOf(string? prefix)
    {
        if (prefix == null)
        {
            return null;
        }

        Node current = _root;
        foreach (char ch in prefix)
        {
            Node? child = current.GetChild(ch);
            if (child == null)
            {
                return null;
            }

            current = child;
        }

        return current;
    }
}
