namespace LaboratoryWork_12
{
    internal class Program
    {
        private const int Million = 1 << 20;
        static void Main(string[] args)
        {
            CreateBinaryFile("input.bin", Million);

            ExternalMergeSort sorter = new("input.bin", "output.bin", 64);
        }

        private static void CreateBinaryFile(string fileName, int elementsCount)
        {
            Random random = new();
            using(FileStream stream = File.OpenWrite(fileName))
            {
                BinaryWriter writer = new BinaryWriter(stream);
                for(int  i = 0; i < elementsCount; i++)
                {
                    writer.Write(random.Next());
                }
                writer.Dispose();
            }
        }
    }

}