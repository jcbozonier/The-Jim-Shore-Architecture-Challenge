using System.IO;
using MoodDesignChallenge.Channels;

namespace MoodDesignChallenge
{
    public class WholeFileAtOnceFileReader : IFileReading, IFileSystemConfiguration
    {
        private IProcessedText _processedText;
        private string FilePath;

        public void OnNewTextAvailableNotify(IProcessedText processedText)
        {
            _processedText = processedText;
        }

        private void Read(string filePath)
        {
            var readText = File.ReadAllText(filePath);
            _processedText.Process(readText);
        }

        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
        }

        public void Read()
        {
            Read(FilePath);
        }
    }
}