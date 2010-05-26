using System.Collections.Generic;

namespace MoodDesignChallenge.Stubs
{
    public class MultipleTextHandOffObserverSubscriber : ITextHandOff
    {
        private List<ITextHandOff> Channels;

        public MultipleTextHandOffObserverSubscriber()
        {
            Channels = new List<ITextHandOff>();
        }

        public void Handoff(string text)
        {
            foreach(var channel in Channels)
                channel.Handoff(text);
        }

        public void AddSubscriber(ITextHandOff textHandOff)
        {
            Channels.Add(textHandOff);
        }
    }
}