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

            var guiActor = new GuiActor();
            guiActor.AddSubscriber(fileReadingChannel);

            guiActor.Encode();

            Assert.That(fileReadingChannel.FileWasRead, Is.True);
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

    public class FileReadingStub : IFileReadingChannel
    {
        public bool FileWasRead;

        public void Read()
        {
            FileWasRead = true;
        }
    }
}
