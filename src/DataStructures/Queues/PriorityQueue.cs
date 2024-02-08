namespace Queues;

internal sealed class PriorityQueue(int size)
{
    private readonly int[] _items = new int[size];
    private int _count;

    public static void ProgramPrint()
    {
        
    }

    public void Add(int item)
    {
        if (IsFull())
        {
            throw new Exception();
        }

        int i = ShiftItemsToInsert(item);
        _items[i] = item;
        _count++;
    }

    public int Remove()
    {
        if (IsEmpty())
        {
            throw new Exception();
        }

        return _items[--_count];
    }

    public int ShiftItemsToInsert(int item)
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

    public bool IsEmpty() => _count == 0;
    public bool IsFull() => _count == _items.Length;

    public override string ToString()
    {
        return ToString(_items);
    }
    
    private static string ToString<T>(IEnumerable<T> collection) => $"[{string.Join(", ", collection)}]";
}
