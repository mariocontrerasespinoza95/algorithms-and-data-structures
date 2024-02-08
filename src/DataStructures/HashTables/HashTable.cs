namespace HashTables;

internal sealed class HashTable(int capacity)
{
    private class Entry(int key, string value)
    {
        public readonly int Key = key;
        public string Value = value;
    }

    private readonly LinkedList<Entry>[] _entries =
        new LinkedList<Entry>[capacity];

    public void Put(int key, string value)
    {
        Entry? entry = GetEntry(key);
        if (entry != null)
        {
            entry.Value = value;
            return;
        }

        GetOrCreateBucket(key).AddLast(new Entry(key, value));
    }

    public string? Get(int key) => GetEntry(key)?.Value;

    public void Remove(int key)
    {
        Entry entry = GetEntry(key) ?? throw new Exception();
        LinkedList<Entry> bucket = GetBucket(key) ?? throw new Exception();
        bucket.Remove(entry);
    }

    private LinkedList<Entry>? GetBucket(int key) => _entries[Hash(key)];

    private LinkedList<Entry> GetOrCreateBucket(int key)
    {
        LinkedList<Entry>? bucket = GetBucket(key);

        return  bucket ?? [];
    }

    private Entry? GetEntry(int key)
    {
        LinkedList<Entry>? bucket = GetBucket(key);
        return bucket?.FirstOrDefault(entry => entry.Key == key);
    }

    private int Hash(int key)
    {
        return key % _entries.Length;
    }
}
