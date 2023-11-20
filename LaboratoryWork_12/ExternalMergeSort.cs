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
            for(int offset = 0; offset < inputFileReader.Length; offset += bufferSize)
            {

            }
        }

        
        
    }
}
