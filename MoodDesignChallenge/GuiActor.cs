namespace MoodDesignChallenge
{
    public class GuiActor : ITextReceivedChannel
    {
        private IFileReadingChannel FileReadingChannel;
        private IFileWritingChannel FileWritingChannel;
        private ITextReceivedChannel DisplayChannel;

        public void Encode(string fromFilePath, string toFilePath)
        {
            var textToEncode = "";
            FileReadingChannel.Read(fromFilePath);
            FileWritingChannel.Write(textToEncode, toFilePath);
        }

        public void SubscribeToChannel(IFileReadingChannel fileReadingChannel)
        {
            FileReadingChannel = fileReadingChannel;
        }

        public void SubscribeToChannel(IFileWritingChannel fileWritingChannel)
        {
            FileWritingChannel = fileWritingChannel;
        }

        public void SubscribeToChannel(ITextReceivedChannel displayChannel)
        {
            DisplayChannel = displayChannel;
        }

        public void Received(string text)
        {
            DisplayChannel.Received(text);
        }
    }
}