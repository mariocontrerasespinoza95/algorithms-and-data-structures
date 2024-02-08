/*
 * Can be used for sorting (HeapSort)
 * Graph algorithms (shortest path)
 * Priority queues
 * Finding the Kth smallest/largest value
 * 
 * Runtime Complexities
 * Insert O(log n)
 * Remove O(log n)
 * Get Max O(1)
 */

using Heaps;

var heap = new Heap();
heap.Insert(10);
heap.Insert(5);
heap.Insert(17);
heap.Insert(4);
heap.Insert(22);
heap.Remove();

int[] numbers = [5, 3, 8, 4, 1, 2];

MaxHeap.Heapify(numbers);
Console.WriteLine(MaxHeap.ToString(numbers));

numbers = [5, 3, 8, 4, 1, 2];
Console.WriteLine(MaxHeap.GetKthLargest(numbers, 6));
