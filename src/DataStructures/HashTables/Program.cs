/*
 * To store key/value pairs
 * Insert, remove, lookup run in O(1)
 * Hash function to map a key with to an index value
 *
 * Probing
 * Linear: (hash1 + i) % table_size
 * Quadratic: (hash1 + (i * i)) % table_size
 * Double Hash: (hash1 + i * hash2) % table_size
 */

using HashTables;

var table = new HashTable(5);
table.Put(6, "A");
table.Put(8, "B");
table.Put(11, "C");
table.Put(6, "A+");
table.Remove(8);
Console.WriteLine(table.Get(6));
