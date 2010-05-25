using System;
using System.IO;

namespace MoodDesignChallenge
{
    public class WholeFileAtOnceFileReader : IFileReadingChannel
    {
        public void Read(string filePath, Action<string> resultChannel)
        {
            var readText = File.ReadAllText(filePath);
            resultChannel(readText);
        }
    }
}