using System;
using System.IO;
using MoodDesignChallenge.Channels;

namespace MoodDesignChallenge
{
    public class WholeFileAtOnceFileWriter : IProcessedText, IFileSystemConfiguration
    {
        private string FilePath;

        public void Process(string textToWrite)
        {
            File.WriteAllText(FilePath, textToWrite);
        }

        public void SetFilePath(string toFilePath)
        {
            FilePath = toFilePath;
        }
    }
}