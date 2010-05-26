using System;
using System.IO;
using MoodDesignChallenge.Channels;

namespace MoodDesignChallenge
{
    public class WholeFileAtOnceFileReader : IFileReading, IFileSystemConfiguration
    {
        private IProcessedText _processedText;
        private string FilePath;
        private string CurrentDirectory = "";

        public void OnNewTextAvailableNotify(IProcessedText processedText)
        {
            _processedText = processedText;
        }

        public void Read()
        {
            var filePath = Path.Combine(CurrentDirectory, FilePath);
            var readText = File.ReadAllText(filePath);
            _processedText.Process(readText);
        }

        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
        }

        public void SetWorkingDirectory(string directoryPath)
        {
            CurrentDirectory = directoryPath;
        }
    }
}