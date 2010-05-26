using System.IO;

namespace MoodDesignChallenge.FileSystem
{
    public class FileSystemConfiguration
    {
        private IFileSystemConfiguration FileReader;
        private IFileSystemConfiguration FileWriter;

        public void SetFileReaderToConfigure(IFileSystemConfiguration fileReader)
        {
            FileReader = fileReader;
        }

        public void SetFileWriterToConfigure(IFileSystemConfiguration fileWriter)
        {
            FileWriter = fileWriter;
        }

        public void Configure()
        {
            var readPath = File.ReadAllLines("configuration.txt")[0];
            var writePath = File.ReadAllLines("configuration.txt")[1];

            FileReader.SetWorkingDirectory(readPath);
            FileWriter.SetWorkingDirectory(writePath);
        }
    }
}