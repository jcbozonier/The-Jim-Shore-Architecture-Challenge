using System.Collections.Generic;

namespace MoodDesignChallenge.Stubs
{
    public static class ObserverExtensions
    {
        public static ITextHandOff CreateMultiObserver(this IEnumerable<ITextHandOff> channels)
        {
            var multiobserver = new TextHandoffBroadcast();
            foreach(var channel in channels)
                multiobserver.AddSubscriber(channel);
            return multiobserver;
        }
    }
}