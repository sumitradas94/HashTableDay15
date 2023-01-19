using System.Text;

namespace HashTable
{
    public class LinkedHashMap<K, V> where K : IComparable
    {
        private readonly int Num_Buckets;
        readonly List<LinkedList<K, V>> Bucket_List;
        public StringBuilder Result;

        public LinkedHashMap(int Num_Buckets)
        {
            this.Num_Buckets = Num_Buckets;
            Bucket_List = new List<LinkedList<K, V>>(Num_Buckets);
            Result = new StringBuilder();

            for (int i = 0; i < Num_Buckets; i++)
                Bucket_List.Add(null);
        }
        public V Get(K Key)
        {
            int Index = Get_Index(Key);
            LinkedList<K, V> linked_list = Bucket_List[Index];
            if (linked_list == null)
                return default;
            HashNode<K, V> hash_node = linked_list.Search(Key);
            return (hash_node == null) ? default : hash_node.Value;
        }
        public int Get_Index(K Key)
        {
            int Hash_Code = Math.Abs(Key.GetHashCode());
            int Index = Hash_Code % Num_Buckets;
            return Index;
        }
        public void Add(K Key, V Value)
        {
            Result.Append(Key + " ");
            int Index = Get_Index(Key);
            LinkedList<K, V> linked_list = Bucket_List[Index];

            if (linked_list == null)
            {
                linked_list = new LinkedList<K, V>();
                Bucket_List[Index] = linked_list;
            }
            HashNode<K, V> hash_node = linked_list.Search(Key);
            if (hash_node == null)
            {
                hash_node = new HashNode<K, V>(Key, Value);
                linked_list.Append(hash_node);
            }
            else hash_node.Value = Value;
        }
    }
}