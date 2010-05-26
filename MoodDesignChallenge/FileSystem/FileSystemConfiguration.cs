using System.IO;
using MoodDesignChallenge.Channels;

namespace MoodDesignChallenge
{
    public class FileSystemConfiguration
    {
        private IFileSystemConfiguration FileReader;
        private IFileSystemConfiguration FileWriter;

        public void SetFileReader(IFileSystemConfiguration fileReader)
        {
            FileReader = fileReader;
        }

        public void SetFileWriter(IFileSystemConfiguration fileWriter)
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