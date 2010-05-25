namespace MoodDesignChallenge
{
    public class GuiActor : IProcessedTextChannel
    {
        private IFileReadingChannel FileReadingChannel;
        private IProcessedTextChannel DisplayChannel;

        public void Encode()
        {
            FileReadingChannel.Read();
        }

        public void AddSubscriber(IFileReadingChannel fileReadingChannel)
        {
            FileReadingChannel = fileReadingChannel;
        }

        public void AddSubscriber(IProcessedTextChannel displayChannel)
        {
            DisplayChannel = displayChannel;
        }

        public void Process(string text)
        {
            DisplayChannel.Process(text);
        }
    }
}