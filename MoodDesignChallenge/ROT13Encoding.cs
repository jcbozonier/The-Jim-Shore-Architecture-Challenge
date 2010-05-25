namespace MoodDesignChallenge
{
    public class ROT13Encoding : IProcessedText
    {
        private IProcessedText _processedText;

        public void OnNewEncodedTextAvailableNotify(IProcessedText processedText)
        {
            _processedText = processedText;
        }

        public void Process(string stringToEncode)
        {
            var result = "";

            foreach (var character in stringToEncode)
            {
                if(character >= 'A' && character <= 'Z')
                {
                    if(character > 'M')
                        result += (char)(character - 13);
                    else
                        result += (char)(character  + 13);
                }
                else if (character >= 'a' && character <= 'z')
                {

                    if (character > 'm')
                        result += (char)(character - 13);
                    else
                        result += (char)(character + 13);
                }
                else
                    result += character;
            }

            _processedText.Process(result);
        
        }
    }
}