namespace DataStructures;

internal sealed class PriorityQueue(int size)
{
    private readonly int[] _items = new int[size];
    private int _count;

    public static void ProgramPrint()
    {
        var queue = new PriorityQueue(5);
        queue.Add(5);
        queue.Add(3);
        queue.Add(6);
        queue.Add(1);
        queue.Add(4);
        Console.WriteLine(queue);

        while (!queue.IsEmpty())
        {
            Console.WriteLine(queue.Remove());
        }
    }

    private void Add(int item)
    {
        if (IsFull())
        {
            throw new Exception();
        }

        int i = ShiftItemsToInsert(item);
        _items[i] = item;
        _count++;
    }

    private int Remove()
    {
        if (IsEmpty())
        {
            throw new Exception();
        }

        return _items[--_count];
    }

    private int ShiftItemsToInsert(int item)
    {
        int i;
        for (i = _count - 1; i >= 0; i--)
        {
            if (_items[i] > item)
            {
                _items[i + 1] = _items[i];
            }
            else
            {
                break;
            }
        }

        return i + 1;
    }

    private bool IsEmpty() => _count == 0;
    private bool IsFull() => _count == _items.Length;

    public override string ToString()
    {
        return Array.ToString(_items);
    }
}
