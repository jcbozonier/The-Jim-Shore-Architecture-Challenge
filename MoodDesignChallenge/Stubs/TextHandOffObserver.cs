namespace MoodDesignChallenge.Stubs
{
    public class TextHandOffObserver : ITextHandOff
    {
        public string ReceivedText;

        public void Handoff(string text)
        {
            ReceivedText = text;
        }
    }
}