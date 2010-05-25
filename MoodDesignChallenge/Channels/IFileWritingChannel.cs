namespace MoodDesignChallenge
{
    public interface IFileWritingChannel
    {
        void WriteTo(string toFilePath);
    }
}