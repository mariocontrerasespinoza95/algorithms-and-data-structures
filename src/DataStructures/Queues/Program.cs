/*
 * First-In First-Out (FIFO)
 * Sharing a resource amongst many consumers
 * Priority queues (items are processed based on priority)
 *
 * Runtime Complexities
 * Enqueue O(1)
 * Dequeue O(1)
 * Peek O(1)
 * IsEmpty O(1)
 */

using Queues;

Console.WriteLine("Array Queue");
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

Console.WriteLine("Priority Queue");
var priorityQueue = new PriorityQueue(5);
priorityQueue.Add(5);
priorityQueue.Add(3);
priorityQueue.Add(6);
priorityQueue.Add(1);
priorityQueue.Add(4);
Console.WriteLine(priorityQueue);

while (!priorityQueue.IsEmpty())
{
    Console.WriteLine(priorityQueue.Remove());
}
