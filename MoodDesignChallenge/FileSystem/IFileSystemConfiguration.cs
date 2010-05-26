namespace MoodDesignChallenge.Channels
{
    public interface IFileSystemConfiguration
    {
        void SetFilePath(string filePath);
        void SetWorkingDirectory(string directoryPath);
    }
}
