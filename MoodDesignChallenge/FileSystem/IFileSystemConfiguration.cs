namespace MoodDesignChallenge.FileSystem
{
    public interface IFileSystemConfiguration
    {
        void SetFilePath(string filePath);
        void SetWorkingDirectory(string directoryPath);
    }
}
