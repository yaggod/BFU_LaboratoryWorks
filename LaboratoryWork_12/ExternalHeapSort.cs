namespace LaboratoryWork_12
{
    internal class ExternalHeapSort
    {
        private readonly int bufferSize;

        private readonly FileStream inputFileReader;
        private readonly FileStream tempFileWriter;
        private readonly FileStream outputFileWriter;


        public ExternalHeapSort(string inputFilePath, string outputFilePath, int bufferSize)
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
            Merge();
        }

        private void SplitIntoParts()
        {
            byte[] bytesBuffer = new byte[bufferSize * 4];
            int[] buffer = new int[bufferSize];
            for (int offset = 0; offset < inputFileReader.Length; offset += bytesBuffer.Length)
            {
                int realLength = inputFileReader.Read(bytesBuffer, 0, bytesBuffer.Length);
                for (int i = 0; i < realLength / 4; i++)
                {
                    buffer[i] = BitConverter.ToInt32(bytesBuffer, i * 4);
                }
                Array.Sort(buffer);
                Buffer.BlockCopy(buffer, 0, bytesBuffer, 0, realLength);
                tempFileWriter.Write(bytesBuffer);
            }
        }
      
        private void Merge()
        {
            FileStream sourceFile = tempFileWriter;
            FileStream destinationFile = outputFileWriter;
            for(int sortedArraysSize = bufferSize; sortedArraysSize < inputFileReader.Length; sortedArraysSize *= 2)
            {
            
            }
        }
        
    }
}
