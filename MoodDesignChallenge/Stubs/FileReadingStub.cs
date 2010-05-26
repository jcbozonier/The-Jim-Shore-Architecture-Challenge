using MoodDesignChallenge.FileSystem;

namespace MoodDesignChallenge.Stubs
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