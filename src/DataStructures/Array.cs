namespace DataStructures;

internal sealed class Array(int length)
{
    private int[] _items = new int[length];
    private int _count;

    public static void ProgramPrint()
    {
        var numbers = new Array(3);

        numbers.Insert(10);
        numbers.Insert(20);
        numbers.Insert(30);
        numbers.Insert(40);
        numbers.InsertAt(50, 5);
        Console.WriteLine("Index of 40: {0}", numbers.IndexOf(40));
        Console.WriteLine("Index of 50: {0}", numbers.IndexOf(50));
        Console.WriteLine("Max value: {0}", numbers.Max());
        numbers.Print();
        numbers.Reverse();
        numbers.Print();

        Console.WriteLine();
        var numbers2 = new Array(3);

        numbers2.Insert(10);
        numbers2.Insert(30);
        numbers2.Print();

        Console.WriteLine();
        Console.WriteLine("Intersected values");
        numbers.Intersect(numbers2).Print();
    }

    public override string ToString() => ToString(_items);
    public static string ToString<T>(IEnumerable<T> array) => $"[{string.Join(", ", array)}]";
    private void Print() => Console.WriteLine($"[{string.Join(", ", _items)}]");

    private void Insert(int item)
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

    private int IndexOf(int item)
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

    private int Max()
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

    private Array Intersect(Array array)
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

    private void Reverse()
    {
        int superiorIndex = _count;
        for (int i = 0; superiorIndex - i > 1; i++)
        {
            int aux = _items[i];
            _items[i] = _items[--superiorIndex];
            _items[superiorIndex] = aux;
        }
    }

    private void InsertAt(int item, int index)
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
}
