using System.IO;
using MoodDesignChallenge.Stubs;

namespace MoodDesignChallenge.FileSystem
{
    public class WholeFileAtOnceFileReader : IFileReading, IFileSystemConfiguration
    {
        private ITextHandOff _textHandOff;
        private string FilePath;
        private string CurrentDirectory = "";

        public void OnNewTextAvailableNotify(ITextHandOff textHandOff)
        {
            _textHandOff = textHandOff;
        }

        public void Read()
        {
            var filePath = Path.Combine(CurrentDirectory, FilePath);
            var readText = File.ReadAllText(filePath);
            _textHandOff.Handoff(readText);
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