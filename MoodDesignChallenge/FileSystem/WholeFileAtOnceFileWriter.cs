using System.IO;
using MoodDesignChallenge.Stubs;

namespace MoodDesignChallenge.FileSystem
{
    public class WholeFileAtOnceFileWriter : ITextHandOff, IFileSystemConfiguration
    {
        private string FilePath;
        private string WorkingDirectory;

        public void Handoff(string textToWrite)
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