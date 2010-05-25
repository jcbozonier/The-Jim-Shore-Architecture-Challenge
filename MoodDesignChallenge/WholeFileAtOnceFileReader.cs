using System.IO;

namespace MoodDesignChallenge
{
    public class WholeFileAtOnceFileReader : IFileReadingChannel
    {
        private IProcessedTextChannel _processedTextChannelChannel;

        public void AddSubscriber(IProcessedTextChannel processedTextChannelChannel)
        {
            _processedTextChannelChannel = processedTextChannelChannel;
        }

        public void Read(string filePath)
        {
            var readText = File.ReadAllText(filePath);
            _processedTextChannelChannel.Process(readText);
        }
    }
}