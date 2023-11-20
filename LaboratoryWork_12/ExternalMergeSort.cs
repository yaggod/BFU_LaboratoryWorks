using System.Reflection;

namespace LaboratoryWork_12
{
    internal class ExternalMergeSort
    {
        private readonly int bufferSize;

        private readonly FileStream inputFileReader;
        private readonly FileStream tempFileWriter;
        private readonly FileStream outputFileWriter;


        public ExternalMergeSort(string inputFilePath, string outputFilePath, int bufferSize)
        {
            this.bufferSize = bufferSize;

            using (inputFileReader = File.OpenRead(inputFilePath))
            {
                using (tempFileWriter = File.Create(inputFilePath + "_TEMP"))
                {
                    using(outputFileWriter = File.Create(outputFilePath))
                    {
                        Sort();
                    }
                }
            }
        }

        private void Sort()
        {
            SplitIntoParts();
        }

        private void SplitIntoParts()
        {
            BinaryReader reader = new BinaryReader(inputFileReader);
            BinaryWriter writer = new BinaryWriter(tempFileWriter);
            for(int offset = 0; offset < inputFileReader.Length; offset += bufferSize)
            {
                int[] buffer = new int[bufferSize];


                int realBufferSize;
                for(realBufferSize = 0; realBufferSize < bufferSize; realBufferSize++)
                {
                    buffer[realBufferSize] = reader.ReadInt32();
                    if (writer.BaseStream.Position == writer.BaseStream.Length)
                        break;
                }

                if(realBufferSize != bufferSize)
                {
                    int[] tempBuffer = new int[realBufferSize];
                    for(int i = 0; i < tempBuffer.Length; i++)
                    {
                        tempBuffer[i] = buffer[i];
                    }
                    buffer = tempBuffer;

                }

                Array.Sort(buffer);
                foreach(int element in buffer)
                {
                    writer.Write(element);
                }
            }

            reader.Dispose();
            writer.Dispose();
        }

        
        
    }
}
