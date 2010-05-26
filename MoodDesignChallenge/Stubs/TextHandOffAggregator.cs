using System.Collections.Generic;
using MoodDesignChallenge;

namespace Tests.FocusedIntegrationTests
{
    public class TextHandOffAggregator : ITextHandOff
    {
        public readonly List<string> ReceivedText;

        public TextHandOffAggregator()
        {
            ReceivedText = new List<string>();
        }

        public void Handoff(string text)
        {
            ReceivedText.Add(text);
        }
    }
}