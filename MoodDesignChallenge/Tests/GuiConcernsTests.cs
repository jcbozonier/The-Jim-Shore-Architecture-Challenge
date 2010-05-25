using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MoodDesignChallenge.Tests
{
    [TestFixture]
    public class GuiConcernsTests
    {
        [Test]
        public void When_calling_encode_with_non_null_parameters()
        {
            var testText = "test text";

            var fileReadingChannel = new FileReadingStub(testText);
            var encodingChannel = new EncodingStub();

            var guiActor = new GuiActor(fileReadingChannel, encodingChannel);

            guiActor.Encode("from file", "to file");

            Assert.That(fileReadingChannel.FilePathToRead, Is.EqualTo("from file"));
            Assert.That(encodingChannel.TextToEncode, Is.EqualTo(testText));
        }
    }

    public class EncodingStub : IEncodingChannel
    {
        public string TextToEncode;

        public void Encode(string stringToEncode, Action<string> resultChannel)
        {
            TextToEncode = stringToEncode;
        }
    }

    public class FileReadingStub : IFileReadingChannel
    {
        private readonly string TestText;
        public string FilePathToRead;

        public FileReadingStub(string testText)
        {
            TestText = testText;
        }

        public void Read(string filePath, Action<string> resultChannel)
        {
            FilePathToRead = filePath;
            resultChannel(TestText);
        }
    }
}
