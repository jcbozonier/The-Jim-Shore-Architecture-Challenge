using System;
using MoodDesignChallenge;

namespace ConsoleGUI
{
    public class GuiWriter : IProcessedText
    {
        public void Process(string text)
        {
            Console.WriteLine(text);
        }
    }
}