
namespace LaboratoryWork_13
{
    internal class Program
    {
        private const int HashBase = 32;
        private const int TabCharacterLength = 7;

        static void Main(string[] args)
        {
            HashTable<string> hashTable = GetInitializedHashTable();

            IEnumerable<string> tableRows = hashTable.GetValues().Select((item, index) => $"{index}\t|\t{item}");

            int longestRow = tableRows.Max(x => x.Length) + TabCharacterLength * 2;
            string rowSeparator = String.Concat(Enumerable.Repeat('-', longestRow));
            using (StreamWriter writer = File.CreateText("output.txt"))
            {
                foreach (string tableRow in tableRows)
                {
                    writer.WriteLine(rowSeparator);
                    writer.WriteLine(tableRow);
                }
                writer.WriteLine(rowSeparator);
            }
        }

        private static HashTable<string> GetInitializedHashTable()
        {
            string input = File.ReadAllText("input.txt", System.Text.Encoding.UTF8);
            string[] words = input.Split(new[] { '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Func<string, int> hashFunction = (s) => {
                return s.First();
            };
            HashTable<string> hashTable = new HashTable<string>(hashFunction, HashBase);
            foreach (string word in words)
            {
                hashTable.Add(word);
            }

            return hashTable;
        }

    }
}