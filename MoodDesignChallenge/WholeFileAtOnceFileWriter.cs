using System.IO;

namespace MoodDesignChallenge
{
    public class WholeFileAtOnceFileWriter : IFileWritingChannel
    {
        public void Write(string textToWrite, string filePath)
        {
            File.WriteAllText(filePath, textToWrite);
        }
    }
}