namespace MoodDesignChallenge
{
    public class ROT13Encoding : IProcessedTextChannel
    {
        private IProcessedTextChannel _processedTextChannel;

        public void AddSubscriber(IProcessedTextChannel processedTextChannel)
        {
            _processedTextChannel = processedTextChannel;
        }

        public void Process(string stringToEncode)
        {
            var result = "";

            foreach (var character in stringToEncode)
            {
                if (character >= 'A' && character <= 'Z' || 
                    character >= 'a' && character <= 'z')
                {
                    result += (char)(character + 13);
                }
                else
                    result += character;
            }

            _processedTextChannel.Process(result);
        
        }
    }
}