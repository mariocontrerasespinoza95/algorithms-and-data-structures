using Array = Arrays.Array;

/*
 * Simplest data structure
 * Static vs dynamic
 * Great when you know how many times you have
 *
 * Runtime Complexities
 * Lookup by Index O(1)
 * Lookup by Value O(n)
 * Insert O(n)
 * Delete O(n)
 */

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
numbers2.RemoveAt(0);
numbers2.Print();
Console.WriteLine();

Console.WriteLine("Intersected values");
numbers.Intersect(numbers2).Print();
