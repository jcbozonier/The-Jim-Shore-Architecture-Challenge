using System;
using System.IO;

namespace MoodDesignChallenge
{
    public class WholeFileAtOnceFileReader
    {
        public void Read(string filePath, Func<string, string> resultChannel)
        {
            var readText = File.ReadAllText(filePath);
            resultChannel(readText);
        }
    }
}