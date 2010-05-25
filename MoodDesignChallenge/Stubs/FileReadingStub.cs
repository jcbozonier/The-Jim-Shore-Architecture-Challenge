using MoodDesignChallenge;

namespace Tests.UnitTests
{
    public class FileReadingStub : IFileReading
    {
        public bool FileWasRead;

        public void Read()
        {
            FileWasRead = true;
        }
    }
}