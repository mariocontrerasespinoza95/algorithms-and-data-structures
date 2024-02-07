namespace DataStructures;

internal sealed class LinkedList
{
    public static void ProgramPrint()
    {
        var list = new LinkedList<int>();
        list.AddLast(10);
        list.AddLast(20);
        list.AddLast(30);
        list.AddLast(40);
        list.AddLast(50);
        list.RemoveFirst();
        Console.WriteLine(list.IndexOf(10));
        list.Reverse();
        Console.WriteLine(list.Size);
        Console.WriteLine($"[{string.Join(", ", list.ToArray())}]");
        Console.WriteLine(list.GetKthFromTheEnd(1));
    }
}

internal class LinkedList<T> where T : notnull
{
    private class Node(T value)
    {
        public T Value = value;
        public Node? Next;
    }

    private Node? _first;
    private Node? _last;

    public void AddLast(T value)
    {
        var node = new Node(value);

        if (IsEmpty)
        {
            _first = _last = node;
        }
        else
        {
            _last!.Next = node;
            _last = node;
        }

        Size++;
    }

    public void AddFirst(T value)
    {
        var node = new Node(value);

        if (IsEmpty)
        {
            _first = _last = node;
        }
        else
        {
            node.Next = _first;
            _first = node;
        }

        Size++;
    }

    public int IndexOf(T item)
    {
        int index = 0;
        Node? current = _first;
        while (current != null)
        {
            if (current.Value.Equals(item))
            {
                return index;
            }

            current = current.Next;
            index++;
        }

        return -1;
    }

    public bool Contains(T item)
    {
        return IndexOf(item) >= 0;
    }

    public void RemoveFirst()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("The LinkedList is empty.");
        }

        if (_first == _last)
        {
            _first = _last = null;
            return;
        }
        else
        {
            Node? aux = _first!.Next;
            _first.Next = null;
            _first = aux;
        }

        Size--;
    }

    public void RemoveLast()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("The LinkedList is empty.");
        }

        if (_first == _last)
        {
            _first = _last = null;
        }
        else
        {
            Node? previous = GetPrevious(_last!);
            _last = previous;
            _last!.Next = null;
        }

        Size--;
    }

    public int Size { get; private set; }

    public T[] ToArray()
    {
        var array = new T[Size];

        Node? current = _first;
        int index = 0;
        while (current != null)
        {
            array[index++] = current.Value;
            current = current.Next;
        }

        return array;
    }

    public void Reverse()
    {
        if (IsEmpty)
        {
            return;
        }

        Node? previous = _first;
        Node? current = _first!.Next;

        while (current != null)
        {
            Node? next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }

        _last = _first;
        _last.Next = null;
        _first = previous;
    }

    public T GetKthFromTheEnd(int k)
    {
        if (IsEmpty)
        {
            throw new Exception();
        }

        Node? a = _first;
        Node? b = _first;

        for (int i = 0; i < k - 1; i++)
        {
            b = b?.Next;
            if (b == null)
            {
                throw new ArgumentException(nameof(b));
            }
        }

        while (b != _last)
        {
            a = a?.Next;
            b = b?.Next;
        }

        return a!.Value;
    }

    private Node? GetPrevious(Node node)
    {
        Node? current = _first;
        while (current != null)
        {
            if (current.Next == node)
            {
                return current;
            }

            current = current.Next;
        }

        return null;
    }

    private bool IsEmpty => _first == null;
}
