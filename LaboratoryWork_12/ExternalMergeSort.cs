using System.Reflection;

namespace LaboratoryWork_12
{
    internal class ExternalMergeSort
    {
        private readonly int bufferSize;

        private readonly FileStream inputFileReader;
        private readonly string outputFilePath;
        private FileStream firstTempFileWriterReader;
        private FileStream secondTempFileWriterReader;


        public ExternalMergeSort(string inputFilePath, string outputFilePath, int bufferSize)
        {
            this.bufferSize = bufferSize;
            this.outputFilePath = outputFilePath;

            inputFileReader = File.OpenRead(inputFilePath);
            firstTempFileWriterReader = File.Create(inputFilePath + "_TEMP1");
            secondTempFileWriterReader = File.Create(inputFilePath + "_TEMP2");

            Sort();

            inputFileReader.Dispose();
            firstTempFileWriterReader.Dispose();
            secondTempFileWriterReader.Dispose();

            CleanFiles();

        }

        private void Sort()
        {
            SplitIntoParts();
            MergeParts();
        }

        private void SplitIntoParts()
        {
            BinaryReader reader = new(inputFileReader);
            BinaryWriter writer = new(firstTempFileWriterReader);
            for (int offset = 0; offset < inputFileReader.Length / 4; offset += bufferSize)
            {
                int[] buffer = new int[bufferSize];


                int realBufferSize;
                for (realBufferSize = 0; realBufferSize < bufferSize; realBufferSize++)
                {
                    if (reader.BaseStream.Position >= reader.BaseStream.Length)
                        break;
                    buffer[realBufferSize] = reader.ReadInt32();
                }

                if (realBufferSize != bufferSize)
                {
                    int[] tempBuffer = new int[realBufferSize];
                    for (int i = 0; i < tempBuffer.Length; i++)
                    {
                        tempBuffer[i] = buffer[i];
                    }
                    buffer = tempBuffer;

                }

                Array.Sort(buffer);
                foreach (int element in buffer)
                {
                    writer.Write(element);
                }
            }

        }


        private void MergeParts()
        {
            for (int sortedArraysSize = bufferSize; sortedArraysSize < inputFileReader.Length / 4; sortedArraysSize *= 2)
            {
                MergeParts(sortedArraysSize);
                (firstTempFileWriterReader, secondTempFileWriterReader) = (secondTempFileWriterReader, firstTempFileWriterReader);
            }
        }

        private void MergeParts(int arraysSize)
        {
            BinaryReader binaryReader = new BinaryReader(firstTempFileWriterReader);
            BinaryWriter binaryWriter = new BinaryWriter(secondTempFileWriterReader);
            binaryWriter.BaseStream.Position = 0;

            for (int offset = 0; offset < inputFileReader.Length / 4 - arraysSize; offset += 2 * arraysSize)
            {
                MergeParts(binaryReader, binaryWriter, offset, arraysSize);
            }
        }

        private void MergeParts(BinaryReader reader, BinaryWriter writer, int offset, int arraysSize)
        {
            int totalLengthLeft = (int)reader.BaseStream.Length / 4 - offset;
            int leftPartSize = Math.Min(arraysSize, totalLengthLeft);
            int rightPartSize = Math.Min(totalLengthLeft, 2 * arraysSize) - leftPartSize;

            int leftIndex = offset;
            int rightIndex = offset + leftPartSize;
            while (leftIndex + rightIndex < 2 * leftPartSize + rightPartSize + 2 * offset)
            {
                int minValue;
                if (leftIndex - offset >= leftPartSize)
                {
                    reader.BaseStream.Position = rightIndex * 4;
                    minValue = reader.ReadInt32();
                    rightIndex++;
                }
                else if (rightIndex - offset - leftPartSize >= rightPartSize)
                {
                    reader.BaseStream.Position = leftIndex * 4;
                    minValue = reader.ReadInt32();
                    leftIndex++;
                }
                else
                {
                    reader.BaseStream.Position = leftIndex * 4;
                    int leftValue = reader.ReadInt32();
                    reader.BaseStream.Position = rightIndex * 4;
                    int rightValue = reader.ReadInt32();
                    if (leftValue < rightValue)
                    {
                        minValue = leftValue;
                        leftIndex++;
                    }
                    else
                    {
                        minValue = rightValue;
                        rightIndex++;
                    }
                }
                writer.Write(minValue);
            }


        }

        private void CleanFiles()
        {
            File.Delete(outputFilePath);
            System.IO.File.Move(firstTempFileWriterReader.Name, outputFilePath);
            File.Delete(secondTempFileWriterReader.Name);
        }

    }
}
