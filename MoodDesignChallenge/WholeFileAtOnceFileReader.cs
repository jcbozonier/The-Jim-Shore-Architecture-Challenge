using System.IO;
using MoodDesignChallenge.Channels;

namespace MoodDesignChallenge
{
    public class WholeFileAtOnceFileReader : IFileReadingChannel, IFilePathConfiguration
    {
        private IProcessedTextChannel _processedTextChannelChannel;
        private string FilePath;

        public void AddSubscriber(IProcessedTextChannel processedTextChannelChannel)
        {
            _processedTextChannelChannel = processedTextChannelChannel;
        }

        private void Read(string filePath)
        {
            var readText = File.ReadAllText(filePath);
            _processedTextChannelChannel.Process(readText);
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