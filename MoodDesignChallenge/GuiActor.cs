namespace MoodDesignChallenge
{
    public class GuiActor
    {
        private IFileReadingChannel FileReadingChannel;
        private IFileWritingChannel FileWritingChannel;

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
    }
}