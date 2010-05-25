namespace MoodDesignChallenge
{
    public class ProcessedTextObserver : IProcessedTextChannel
    {
        public string ReceivedText;

        public void Process(string text)
        {
            ReceivedText = text;
        }
    }
}