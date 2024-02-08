/*
 * Tries are another kind of trees with fast operations
 *
 * Runtime Complexities
 * Insert O(L)
 * Lookup O(L)
 * Delete O(L)
 * where L is the length of the word
 */

using Tries;

var trie = new Trie();
trie.Insert(word: "car");
trie.Insert(word: "card");
trie.Insert(word: "care");
Console.WriteLine(trie.Contains("car"));
Console.WriteLine(trie.Contains("care"));

trie.Remove(word: "care");
trie.Insert(word: "care");
trie.Insert(word: "careful");
trie.Insert(word: "egg");

List<string> words = trie.FindWords(prefix: "ca");
Console.WriteLine($"[{string.Join(", ", words)}]");
