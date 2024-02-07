namespace DataStructures;

internal sealed class ArrayQueue(int capacity)
{
    private readonly int[] _items = new int[capacity];
    private int _rear;
    private int _front;
    private int _count;

    public static void ProgramPrint()
    {
        var queue = new ArrayQueue(5);
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        queue.Dequeue();
        Console.WriteLine(queue.Dequeue());
        queue.Enqueue(40);
        queue.Enqueue(50);
        queue.Enqueue(60);
        queue.Enqueue(70);
        queue.Dequeue();
        queue.Enqueue(80);
        Console.WriteLine(queue);
    }

    private void Enqueue(int item)
    {
        if (_count == _items.Length)
        {
            throw new Exception();
        }

        _items[_rear] = item;
        _rear = (_rear + 1) % _items.Length;
        _count++;
    }

    private int Dequeue()
    {
        int item = _items[_front];
        _items[_front] = 0;
        _front = (_front + 1) % _items.Length;
        _count--;
        return item;
    }

    public override string ToString()
    {
        return Array.ToString(_items);
    }
}
