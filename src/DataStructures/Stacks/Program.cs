/*
 * Last-In First-Out (LIFO)
 * Can be implemented using Arrays / Linked Lists
 * All operations run in O(1)
 */

using Stacks;

var stack = new Stack(5);
stack.Push(10);
stack.Push(20);
stack.Push(30);
Console.WriteLine(stack);
Console.WriteLine(stack.Pop());
Console.WriteLine(stack);
Console.WriteLine(stack.Peek());
