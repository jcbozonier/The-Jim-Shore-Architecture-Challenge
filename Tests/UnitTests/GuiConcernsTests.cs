using System;
using MoodDesignChallenge;
using NUnit.Framework;

namespace Tests.UnitTests
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
            guiActor.AddSubscriber(fileReadingChannel);
            guiActor.AddSubscriber(fileWritingChannel);

            guiActor.Encode("from file", "to file");

            Assert.That(fileReadingChannel.FilePathToRead, Is.EqualTo("from file"));
            Assert.That(fileWritingChannel.FilePathToWrite, Is.EqualTo("to file"));
        }

        [Test]
        public void When_updating_the_display_with_the_encoded_text()
        {
            var displayChannel = new ProcessedTextObserver(); 
            var guiActor = new GuiActor();
            guiActor.AddSubscriber(displayChannel);

            guiActor.Process("testing!");

            Assert.That(displayChannel.ReceivedText, Is.EqualTo("testing!"));
        }
    }

    public class FileWritingStub : IFileWritingChannel
    {
        public string FilePathToWrite;

        public void Write(string textToWrite)
        {
        }

        public void WriteTo(string filePath)
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
