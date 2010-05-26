using System;
using System.IO;
using MoodDesignChallenge.Channels;

namespace MoodDesignChallenge
{
    public class WholeFileAtOnceFileWriter : IProcessedText, IFileSystemConfiguration
    {
        private string FilePath;
        private string WorkingDirectory;

        public void Process(string textToWrite)
        {
            File.WriteAllText(Path.Combine(WorkingDirectory, FilePath), textToWrite);
        }

        public void SetFilePath(string toFilePath)
        {
            FilePath = toFilePath;
        }

        public void SetWorkingDirectory(string directoryPath)
        {
            WorkingDirectory = directoryPath;
        }
    }
}