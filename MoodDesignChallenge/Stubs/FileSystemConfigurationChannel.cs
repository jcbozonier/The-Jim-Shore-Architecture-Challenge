using MoodDesignChallenge.Channels;

namespace MoodDesignChallenge.Stubs
{
    public class FileSystemConfigurationChannel : IFileSystemConfiguration
    {
        public string ReceivedWorkingDirectory;

        public void SetFilePath(string filePath)
        {
            
        }

        public void SetWorkingDirectory(string directoryPath)
        {
            ReceivedWorkingDirectory = directoryPath;
        }
    }
}