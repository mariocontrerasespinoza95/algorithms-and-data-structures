/*
 * Same as graphs but edges have weight
 */

using WeightedGraphs;

var graph = new WeightedGraph();
graph.AddNode("A");
graph.AddNode("B");
graph.AddNode("C");
graph.AddNode("D");
graph.AddNode("E");
graph.AddNode("F");
graph.AddEdge(from: "A", to: "B", weight: 14);
graph.AddEdge(from: "A", to: "D", weight: 36);
graph.AddEdge(from: "B", to: "A", weight: 69);
graph.AddEdge(from: "B", to: "F", weight: 14);
graph.AddEdge(from: "C", to: "D", weight: 47);
graph.AddEdge(from: "C", to: "E", weight: 58);
graph.AddEdge(from: "C", to: "F", weight: 69);
graph.AddEdge(from: "D", to: "B", weight: 71);
graph.AddEdge(from: "D", to: "F", weight: 25);
graph.AddEdge(from: "E", to: "B", weight: 36);
graph.AddEdge(from: "E", to: "C", weight: 47);
graph.AddEdge(from: "F", to: "C", weight: 93);
graph.AddEdge(from: "F", to: "E", weight: 25);
        
Console.WriteLine("Shortest Path from A to F");
Console.WriteLine(graph.GetShortestPath("A", "F"));
Console.WriteLine();
        
Console.WriteLine("Shortest Path from B to C");
Console.WriteLine(graph.GetShortestPath("B", "C"));
Console.WriteLine();
        
Console.WriteLine("Shortest Path from C to E");
Console.WriteLine(graph.GetShortestPath("C", "E"));
Console.WriteLine();
        
Console.WriteLine("Shortest Path from D to A");
Console.WriteLine(graph.GetShortestPath("D", "A"));
Console.WriteLine();
        
Console.WriteLine("Shortest Path from E to B");
Console.WriteLine(graph.GetShortestPath("E", "B"));
Console.WriteLine();
        
WeightedGraph tree = graph.GetMinimumSpanningTree();
tree.Print();
