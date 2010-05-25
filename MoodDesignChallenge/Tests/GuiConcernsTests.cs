using NUnit.Framework;

namespace MoodDesignChallenge.Tests
{
    [TestFixture]
    public class GuiConcernsTests
    {
        [Test]
        public void When_calling_encode_with_non_null_parameters()
        {
            var fileReadingChannel = new FileReadingStub();
            var fileWritingChannel = new FileWritingStub();

            var guiActor = new GuiActor();
            guiActor.SubscribeToChannel(fileReadingChannel);
            guiActor.SubscribeToChannel(fileWritingChannel);

            guiActor.Encode("from file", "to file");

            Assert.That(fileReadingChannel.FilePathToRead, Is.EqualTo("from file"));
            Assert.That(fileWritingChannel.FilePathToWrite, Is.EqualTo("to file"));
        }

        [Test]
        public void When_updating_the_display_with_the_encoded_text()
        {
            var displayChannel = new TextObserver(); 
            var guiActor = new GuiActor();
            guiActor.SubscribeToChannel(displayChannel);

            guiActor.Received("testing!");

            Assert.That(displayChannel.ReceivedText, Is.EqualTo("testing!"));
        }
    }

    public class FileWritingStub : IFileWritingChannel
    {
        public string FilePathToWrite;

        public void Write(string textToWrite, string filePath)
        {
            FilePathToWrite = filePath;
        }
    }

    public class FileReadingStub : IFileReadingChannel
    {
        public string FilePathToRead;

        public void Read(string filePath)
        {
            FilePathToRead = filePath;


        }
    }
}
