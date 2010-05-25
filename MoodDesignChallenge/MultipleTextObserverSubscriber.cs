using System.Collections.Generic;

namespace MoodDesignChallenge
{
    public class MultipleTextObserverSubscriber : IProcessedTextChannel
    {
        private List<IProcessedTextChannel> Channels;

        public MultipleTextObserverSubscriber()
        {
            Channels = new List<IProcessedTextChannel>();
        }

        public void Process(string text)
        {
            foreach(var channel in Channels)
                channel.Process(text);
        }

        public void AddSubscriber(IProcessedTextChannel processedTextChannel)
        {
            Channels.Add(processedTextChannel);
        }
    }
}