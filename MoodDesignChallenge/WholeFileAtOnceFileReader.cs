using System.IO;

namespace MoodDesignChallenge
{
    public class WholeFileAtOnceFileReader : IFileReadingChannel
    {
        private ITextReceivedChannel _textReceivedChannelChannel;

        public void SubscribeTo(ITextReceivedChannel textReceivedChannelChannel)
        {
            _textReceivedChannelChannel = textReceivedChannelChannel;
        }

        public void Read(string filePath)
        {
            var readText = File.ReadAllText(filePath);
            _textReceivedChannelChannel.Received(readText);
        }
    }
}