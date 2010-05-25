using System.Collections.Generic;

namespace MoodDesignChallenge
{
    public static class ObserverExtensions
    {
        public static IProcessedText CreateMultiObserver(this IEnumerable<IProcessedText> channels)
        {
            var multiobserver = new MultipleTextObserverSubscriber();
            foreach(var channel in channels)
                multiobserver.AddSubscriber(channel);
            return multiobserver;
        }
    }
}