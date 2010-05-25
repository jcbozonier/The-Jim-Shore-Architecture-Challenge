using System.Collections.Generic;

namespace MoodDesignChallenge
{
    public class MultipleTextObserverSubscriber : IProcessedText
    {
        private List<IProcessedText> Channels;

        public MultipleTextObserverSubscriber()
        {
            Channels = new List<IProcessedText>();
        }

        public void Process(string text)
        {
            foreach(var channel in Channels)
                channel.Process(text);
        }

        public void AddSubscriber(IProcessedText processedText)
        {
            Channels.Add(processedText);
        }
    }
}