namespace MoodDesignChallenge.Tests
{
    public class TextObserver : ITextReceivedChannel
    {
        public string ReceivedText;

        public void Received(string text)
        {
            ReceivedText = text;
        }
    }
}