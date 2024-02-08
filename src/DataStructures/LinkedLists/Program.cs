/*
 * Second most used data structures
 * Grow and shrink automatically
 * Take a bit more memory
 *
 * Runtime Complexities
 * Lookup
 *      By Index O(n)
 *      By Value O(n)
 * Insert
 *      Beginning/End O(1)
 *      Middle O(n)
 * Delete
 *      Beginning O(1)
 *      Middle O(n)
 *      End O(n) single / O(1) double
 */

var list = new LinkedLists.LinkedList<int>();
list.AddLast(10);
list.AddLast(20);
list.AddLast(30);
list.AddLast(40);
list.AddLast(50);
list.RemoveFirst();
Console.WriteLine(list.IndexOf(10));
list.Reverse();
Console.WriteLine(list.Size);
Console.WriteLine($"[{string.Join(", ", list.ToArray())}]");
Console.WriteLine(list.GetKthFromTheEnd(1));
