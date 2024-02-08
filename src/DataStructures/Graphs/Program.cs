/*
 * We use Graphs to represent connected objects
 * Implementation
 *  Adjacency Matrix
 *  Adjacency List
 * Traversal algorithms
 * Breadth-first Search (BFS)
 * Depth-first Search (DFS)
 */

using Graphs;

var graph = new Graph();
graph.AddNode("A");
graph.AddNode("B");
graph.AddNode("C");
graph.AddNode("D");
graph.AddEdge("A", "B");
graph.AddEdge("B", "D");
graph.AddEdge("D", "C");
graph.AddEdge("A", "C");
graph.TraverseDepthFirst("A");
IEnumerable<string> list = graph.TopologicalSort();
Console.WriteLine($"[{string.Join(", ", list)}]");
