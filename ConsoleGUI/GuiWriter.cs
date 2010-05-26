using System;
using MoodDesignChallenge;
using MoodDesignChallenge.Stubs;

namespace ConsoleGUI
{
    public class GuiWriter : ITextHandOff
    {
        public void Handoff(string text)
        {
            Console.WriteLine(text);
        }
    }
}