using System.IO;

namespace MoodDesignChallenge
{
    public class WholeFileAtOnceFileWriter
    {
        public void Write(string textToWrite, string filePath)
        {
            File.WriteAllText(filePath, textToWrite);
        }
    }
}