namespace MoodDesignChallenge
{
    public class ROT13Encoding : IEncodingChannel
    {
        private ITextReceivedChannel TextReceivedChannel;

        public void SubscribeTo(ITextReceivedChannel textReceivedChannel)
        {
            TextReceivedChannel = textReceivedChannel;
        }

        public void Encode(string stringToEncode)
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

            TextReceivedChannel.Received(result);
        
        }
    }
}