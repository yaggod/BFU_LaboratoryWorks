namespace LaboratoryWork_12
{
    internal class Program
    {
        private const int Million = 1 << 20;
        private const int Thousand = (1 << 10) - 15;

        private const string inputFileName = "input.bin";
        private const string outputFileName = "output.bin";
        
        static void Main(string[] args)
        {
            CreateBinaryFile(inputFileName, Thousand);
            ExternalMergeSort sorter = new(inputFileName, outputFileName, 4);
            Console.WriteLine(IsSortedFile(outputFileName) ? "Sorted" : "Not sorted");
        }

        private static void CreateBinaryFile(string fileName, int elementsCount)
        {
            Random random = new();
            using(FileStream stream = File.Create(fileName))
            {
                BinaryWriter writer = new BinaryWriter(stream);
                for(int  i = 0; i < elementsCount; i++)
                {
                    writer.Write(random.Next());
                }
                writer.Dispose();
            }
        }

        private static bool IsSortedFile(string fileName)
        {
            int counter = 0;
            int lastValue;
            using (FileStream stream = File.Open(fileName, FileMode.Open))
            {
                BinaryReader reader = new BinaryReader(stream);
                lastValue = reader.ReadInt32();
                while(reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int newValue = reader.ReadInt32();
                    if(newValue < lastValue)
                    {
                        return false;
                    }
                    lastValue = newValue;
                }
            }

                return true;
        }
    }

}