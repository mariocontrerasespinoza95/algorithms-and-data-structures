namespace DataStructures;

internal sealed class HashTable(int capacity)
{
    private class Entry(int key, string value)
    {
        public readonly int Key = key;
        public string Value = value;
    }

    private readonly System.Collections.Generic.LinkedList<Entry>[] _entries =
        new System.Collections.Generic.LinkedList<Entry>[capacity];

    public static void ProgramPrint()
    {
        var table = new HashTable(5);
        table.Put(6, "A");
        table.Put(8, "B");
        table.Put(11, "C");
        table.Put(6, "A+");
        Console.WriteLine(table.Get(6));
    }

    private void Put(int key, string value)
    {
        Entry? entry = GetEntry(key);
        if (entry != null)
        {
            entry.Value = value;
            return;
        }

        GetOrCreateBucket(key).AddLast(new Entry(key, value));
    }

    private string? Get(int key) => GetEntry(key)?.Value;

    public void Remove(int key)
    {
        Entry entry = GetEntry(key) ?? throw new Exception();
        System.Collections.Generic.LinkedList<Entry> bucket = GetBucket(key) ?? throw new Exception();
        bucket.Remove(entry);
    }

    private System.Collections.Generic.LinkedList<Entry>? GetBucket(int key) => _entries[Hash(key)];

    private System.Collections.Generic.LinkedList<Entry> GetOrCreateBucket(int key)
    {
        System.Collections.Generic.LinkedList<Entry>? bucket = GetBucket(key);
        return  bucket ?? [];
    }

    private Entry? GetEntry(int key)
    {
        System.Collections.Generic.LinkedList<Entry>? bucket = GetBucket(key);
        return bucket?.FirstOrDefault(entry => entry.Key == key);
    }

    private int Hash(int key)
    {
        return key % _entries.Length;
    }
}
