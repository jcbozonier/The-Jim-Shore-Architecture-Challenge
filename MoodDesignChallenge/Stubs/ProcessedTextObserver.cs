namespace MoodDesignChallenge
{
    public class ProcessedTextObserver : IProcessedText
    {
        public string ReceivedText;

        public void Process(string text)
        {
            ReceivedText = text;
        }
    }
}