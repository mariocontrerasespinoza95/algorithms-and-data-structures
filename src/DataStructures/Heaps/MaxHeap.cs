namespace Heaps;

internal static class MaxHeap
{
    public static void Heapify(IList<int> array)
    {
        int lastParentIndex = array.Count / 2 - 1;
        for (int i = lastParentIndex; i >= 0; i--)
        {
            Heapify(array, i);
        }
    }

    private static void Heapify(IList<int> array, int index)
    {
        int largerIndex = index;

        int leftIndex = index * 2 + 1;
        if (leftIndex < array.Count &&
            array[leftIndex] > array[largerIndex])
        {
            largerIndex = leftIndex;
        }

        int rightIndex = index * 2 + 2;
        if (rightIndex < array.Count &&
            array[rightIndex] > array[largerIndex])
        {
            largerIndex = rightIndex;
        }

        if (index == largerIndex)
        {
            return;
        }

        Swap(array, index, largerIndex);
        Heapify(array, largerIndex);
    }

    private static void Swap(IList<int> array, int first, int second) =>
        (array[second], array[first]) = (array[first], array[second]);

    public static int GetKthLargest(IReadOnlyCollection<int> array, int k)
    {
        if (k < 1 || k > array.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(k));
        }

        var heap = new Heap();
        foreach (int number in array)
        {
            heap.Insert(number);
        }

        for (int i = 0; i < k - 1; i++)
        {
            heap.Remove();
        }

        return heap.Max();
    }
    
    public static string ToString<T>(IEnumerable<T> collection) => $"[{string.Join(", ", collection)}]";
}
