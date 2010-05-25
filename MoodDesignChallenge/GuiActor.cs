namespace MoodDesignChallenge
{
    public class GuiActor : IProcessedTextChannel
    {
        private IFileReadingChannel FileReadingChannel;
        private IFileWritingChannel FileWritingChannel;
        private IProcessedTextChannel DisplayChannel;

        public void Encode(string fromFilePath, string toFilePath)
        {
            FileWritingChannel.WriteTo(toFilePath);
            FileReadingChannel.Read(fromFilePath);
        }

        public void AddSubscriber(IFileReadingChannel fileReadingChannel)
        {
            FileReadingChannel = fileReadingChannel;
        }

        public void AddSubscriber(IFileWritingChannel fileWritingChannel)
        {
            FileWritingChannel = fileWritingChannel;
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