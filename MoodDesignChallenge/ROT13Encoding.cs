using MoodDesignChallenge.Stubs;

namespace MoodDesignChallenge
{
    public class ROT13Encoding : ITextHandOff
    {
        private ITextHandOff _textHandOff;

        public void OnNewEncodedTextAvailableNotify(ITextHandOff textHandOff)
        {
            _textHandOff = textHandOff;
        }

        public void Handoff(string stringToEncode)
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

            _textHandOff.Handoff(result);
        
        }
    }
}