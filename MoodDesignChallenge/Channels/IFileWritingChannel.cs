namespace MoodDesignChallenge
{
    public interface IFileWritingChannel
    {
        void Write(string textToWrite, string filePath);
    }
}