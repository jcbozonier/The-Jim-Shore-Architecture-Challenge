using System.IO;
using MoodDesignChallenge.Channels;

namespace MoodDesignChallenge
{
    public class ConfigurationActor
    {
        private IFilePathConfiguration FileReader;
        private IFilePathConfiguration FileWriter;

        public void ActorToReadFromFilePath(IFilePathConfiguration fileReader)
        {
            FileReader = fileReader;
        }

        public void ActorToWriteToFilePath(IFilePathConfiguration fileWriter)
        {
            FileWriter = fileWriter;
        }

        public void Configure()
        {
            var readPath = File.ReadAllLines("configuration.txt")[0];
            var writePath = File.ReadAllLines("configuration.txt")[1];

            FileReader.SetFilePath(readPath);
            FileWriter.SetFilePath(writePath);
        }
    }
}