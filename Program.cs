namespace HashTable
{
    public class Program
    {
        public static void Main(string[] args)
        {

            LinkedHashMap<string, int> linked_hash_map = new LinkedHashMap<string, int>(5);

            string Sentence = "to be or not to be";
            string[] Words = Sentence.Split(" ");
            foreach (string word in Words)
            {
                int Value = linked_hash_map.Get(word);
                if (Value == default)
                    Value = 1;
                else Value++;
                linked_hash_map.Add(word, Value);
            }
            int Frequency = linked_hash_map.Get("to");
            Console.WriteLine("Frquency of word in mentioned statement is : " + Frequency);
            Frequency = linked_hash_map.Get("are");
            Console.WriteLine("\"are\" comes {0} times in the given paragraph", Frequency);
            Frequency = linked_hash_map.Get("they");
            Console.WriteLine("\"they\" comes {0} times in the given paragraph", Frequency);
        }
    }
}