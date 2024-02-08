/*
 * Represent hierarchical data
 * Databases
 * Autocompletion
 * Compilers
 * Compression algorithms
 *
 * Runtime Complexities
 * Lookup O(log n)
 * Insert O(log n)
 * Delete O(log n)
 */

using Trees;

var tree = new Tree();
tree.Insert(7);
tree.Insert(4);
tree.Insert(9);
tree.Insert(1);
tree.Insert(6);
tree.Insert(8);
tree.Insert(10);

Console.WriteLine("Pre Order");
tree.TraversePreOrder();
Console.WriteLine();

Console.WriteLine("In Order");
tree.TraverseInOrder();
Console.WriteLine();

Console.WriteLine("Height");
Console.WriteLine(tree.Height());
Console.WriteLine();

Console.WriteLine("Min");
Console.WriteLine(tree.Min());
Console.WriteLine();

var tree2 = new Tree();
tree2.Insert(7);
tree2.Insert(4);
tree2.Insert(9);
tree2.Insert(1);
tree2.Insert(6);
tree2.Insert(8);
tree2.Insert(10);
Console.WriteLine("Equals");
Console.WriteLine(tree.Equals(tree2));
Console.WriteLine();

Console.WriteLine("Is Binary Tree");
Console.WriteLine(tree.IsBinarySearchTree());
Console.WriteLine();

Console.WriteLine("Print Nodes At Distance");
List<int> list = tree.GetNodesAtDistance(1);
foreach (int item in list)
{
    Console.WriteLine(item);
}

Console.WriteLine();

Console.WriteLine("Traverse Level Order");
tree.TraverseLevelOrder();
Console.WriteLine();
