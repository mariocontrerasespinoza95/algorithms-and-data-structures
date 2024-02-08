namespace Arrays;

internal sealed class Array(int length)
{
    private int[] _items = new int[length];
    private int _count;
    
    public void Print() => Console.WriteLine(_items);

    public void Insert(int item)
    {
        if (_items.Length == _count)
        {
            int[] newItems = new int[_count * 2];

            for (int i = 0; i < _count; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
        }

        _items[_count++] = item;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new ArgumentException("Index out of range");
        }

        for (int i = index; i < _count; i++)
        {
            _items[i] = _items[i + 1];
        }

        _count--;
    }

    public int IndexOf(int item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[i] == item)
            {
                return i;
            }
        }

        return -1;
    }

    public int Max()
    {
        int max = _items.Length > 0 ? _items[0] : default;

        for (int i = 0; i < _count; i++)
        {
            if (_items[i] > max)
            {
                max = _items[i];
            }
        }

        return max;
    }

    public Array Intersect(Array array)
    {
        var intersectedValues = new Array(1);

        for (int i = 0; i < array._count; i++)
        {
            int alreadyIntersectedIndex = intersectedValues.IndexOf(_items[i]);
            if (alreadyIntersectedIndex > -1)
            {
                continue;
            }

            int intersectedIndex = array.IndexOf(_items[i]);
            if (intersectedIndex >= 0)
            {
                intersectedValues.Insert(_items[i]);
            }
        }

        return intersectedValues;
    }

    public void Reverse()
    {
        int superiorIndex = _count;
        for (int i = 0; superiorIndex - i > 1; i++)
        {
            int aux = _items[i];
            _items[i] = _items[--superiorIndex];
            _items[superiorIndex] = aux;
        }
    }

    public void InsertAt(int item, int index)
    {
        while (index > _count)
        {
            int[] newItems = new int[_count * 2];

            for (int i = 0; i < _count; i++)
            {
                newItems[i] = _items[i];
            }

            _items = newItems;
            _count = index + 1;
        }

        _items[index] = item;
    }
    
    public override string ToString() => ToString(_items);
    private static string ToString<T>(IEnumerable<T> array) => $"[{string.Join(", ", array)}]";
}
