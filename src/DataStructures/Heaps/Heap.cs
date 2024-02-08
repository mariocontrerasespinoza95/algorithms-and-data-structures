namespace Heaps;

internal sealed class Heap
{

    private readonly int[] _items = new int[10];
    private int _size;

    public void Insert(int value)
    {
        if (IsFull())
        {
            throw new Exception();
        }

        _items[_size++] = value;

        BubbleUp();
    }

    public int Remove()
    {
        if (IsEmpty())
        {
            throw new Exception();
        }

        int root = _items[0];
        _items[0] = _items[--_size];

        BubbleDown();

        return root;
    }

    public bool IsEmpty() => _size == 0;

    private bool IsFull() => _size == _items.Length;

    public int Max()
    {
        if (IsEmpty())
        {
            throw new Exception();
        }

        return _items[0];
    }

    private void BubbleUp()
    {
        int index = _size - 1;
        while (index > 0 && _items[index] > _items[Parent(index)])
        {
            Swap(index, Parent(index));
            index = Parent(index);
        }
    }

    private void BubbleDown()
    {
        int index = 0;
        while (index <= _size && !IsValidParent(index))
        {
            int largerChildIndex = LargerChildIndex(index);
            Swap(index, largerChildIndex);
            index = largerChildIndex;
        }
    }

    private int LargerChildIndex(int index)
    {
        if (!HasLeftChild(index))
        {
            return index;
        }

        if (!HasRightChild(index))
        {
            return LeftChildIndex(index);
        }

        return LeftChild(index) > RightChild(index) ?
                LeftChildIndex(index) :
                RightChildIndex(index);
    }

    private bool HasLeftChild(int index) => LeftChildIndex(index) <= _size;
    private bool HasRightChild(int index) => RightChildIndex(index) <= _size;

    private bool IsValidParent(int index)
    {
        if (!HasLeftChild(index))
        {
            return true;
        }

        bool isValid = _items[index] >= LeftChild(index);

        if (HasRightChild(index))
        {
            isValid &= _items[index] >= RightChild(index);
        }

        return isValid;
    }

    private int LeftChild(int index) => _items[LeftChildIndex(index)];
    private static int LeftChildIndex(int index) => index * 2 + 1;

    private int RightChild(int index) => _items[RightChildIndex(index)];
    private static int RightChildIndex(int index) => index * 2 + 2;

    private static int Parent(int index) => (index - 1) / 2;

    private void Swap(int first, int second) => (_items[second], _items[first]) = (_items[first], _items[second]);
}
