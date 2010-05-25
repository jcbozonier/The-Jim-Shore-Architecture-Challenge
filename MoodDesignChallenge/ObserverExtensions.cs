namespace MoodDesignChallenge
{
    public static class ObserverExtensions
    {
        public static IProcessedTextChannel CreateMultiObserver(this IProcessedTextChannel[] channels)
        {
            var multiobserver = new MultipleTextObserverSubscriber();
            foreach(var channel in channels)
                multiobserver.AddSubscriber(channel);
            return multiobserver;
        }
    }
}