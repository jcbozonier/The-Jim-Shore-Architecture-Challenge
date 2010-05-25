namespace MoodDesignChallenge
{
    public class GuiActor
    {
        private readonly IFileReadingChannel FileReadingChannel;
        private readonly IEncodingChannel EncodingChannel;

        public GuiActor(IFileReadingChannel fileReadingChannel, IEncodingChannel encodingChannel)
        {
            FileReadingChannel = fileReadingChannel;
            EncodingChannel = encodingChannel;
        }

        public void Encode(string fromFilePath, string toFilePath)
        {
            var textToEncode = "";
            FileReadingChannel.Read(fromFilePath, x => { textToEncode = x; });
            EncodingChannel.Encode(textToEncode, x=> { });
        }
    }
}