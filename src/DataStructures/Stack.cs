namespace DataStructures;

internal sealed class Stack(int size)
{
    private readonly int[] _items = new int[size];
    private int _count;

    public static void ProgramPrint()
    {
        var stack = new Stack(5);
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        Console.WriteLine(stack);
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack);
        Console.WriteLine(stack.Peek());
    }

    private bool IsEmpty() { return _count == 0; }

    private void Push(int item)
    {
        if (_count == _items.Length)
        {
            throw new StackOverflowException();
        }

        _items[_count++] = item;
    }

    private int Pop()
    {
        if (IsEmpty())
        {
            throw new Exception();
        }

        return _items[--_count];
    }

    private int Peek()
    {
        if (IsEmpty())
        {
            throw new Exception();
        }

        return _items[_count - 1];
    }

    public override string ToString()
    {
        return Array.ToString(_items);
    }
}
