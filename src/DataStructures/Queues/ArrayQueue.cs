namespace Queues;

internal sealed class ArrayQueue(int capacity)
{
    private readonly int[] _items = new int[capacity];
    private int _rear;
    private int _front;
    private int _count;

    public void Enqueue(int item)
    {
        if (_count == _items.Length)
        {
            throw new Exception();
        }

        _items[_rear] = item;
        _rear = (_rear + 1) % _items.Length;
        _count++;
    }

    public int Dequeue()
    {
        int item = _items[_front];
        _items[_front] = 0;
        _front = (_front + 1) % _items.Length;
        _count--;
        return item;
    }

    public override string ToString()
    {
        return ToString(_items);
    }

    private static string ToString<T>(IEnumerable<T> collection) => $"[{string.Join(", ", collection)}]";
}
