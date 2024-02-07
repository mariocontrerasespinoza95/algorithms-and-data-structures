namespace DataStructures;

internal sealed class PriorityQueueWithHeap
{
    private readonly Heap _heap = new();

    public void Enqueue(int item) => _heap.Insert(item);

    public int Dequeue() => _heap.Remove();

    public bool IsEmpty() => _heap.IsEmpty();
}
