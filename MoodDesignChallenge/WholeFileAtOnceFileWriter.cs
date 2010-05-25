using System;
using System.IO;

namespace MoodDesignChallenge
{
    public class WholeFileAtOnceFileWriter : IProcessedTextChannel, IFileWritingChannel
    {
        private string FilePath;

        public void Process(string textToWrite)
        {
            File.WriteAllText(FilePath, textToWrite);
        }

        public void WriteTo(string toFilePath)
        {
            FilePath = toFilePath;
        }
    }
}