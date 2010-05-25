using System;
using MoodDesignChallenge;

namespace ConsoleGUI
{
    public class GuiWriter : IProcessedTextChannel
    {
        public void Process(string text)
        {
            Console.WriteLine(text);
        }
    }
}