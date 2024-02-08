namespace Stacks;

internal sealed class Stack(int size)
{
    private readonly int[] _items = new int[size];
    private int _count;

    private bool IsEmpty() { return _count == 0; }

    public void Push(int item)
    {
        if (_count == _items.Length)
        {
            throw new StackOverflowException();
        }

        _items[_count++] = item;
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            throw new Exception();
        }

        return _items[--_count];
    }

    public int Peek()
    {
        if (IsEmpty())
        {
            throw new Exception();
        }

        return _items[_count - 1];
    }

    public override string ToString()
    {
        return ToString(_items);
    }
    
    private static string ToString<T>(IEnumerable<T> collection) => $"[{string.Join(", ", collection)}]";
}
