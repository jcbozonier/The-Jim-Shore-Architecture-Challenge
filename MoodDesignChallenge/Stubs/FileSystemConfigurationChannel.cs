using MoodDesignChallenge.Channels;

namespace Tests.FocusedIntegrationTests
{
    public class FileSystemConfigurationChannel : IFileSystemConfiguration
    {
        public string ReceivedFilePath;

        public void SetFilePath(string filePath)
        {
            ReceivedFilePath = filePath;
        }
    }
}