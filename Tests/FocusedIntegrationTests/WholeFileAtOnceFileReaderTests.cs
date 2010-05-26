using System;
using MoodDesignChallenge.FileSystem;
using MoodDesignChallenge.Stubs;
using NUnit.Framework;

namespace Tests.FocusedIntegrationTests
{
    [TestFixture]
    public class WholeFileAtOnceFileReaderTests
    {
        private string TEST_FILE_PATH = "FocusedIntegrationTests/TestFiles/";

        [Test]
        public void When_reading_a_whole_empty_file_at_once()
        {
            var fileLineCount = 0;
            var textObserver = new TextHandOffAggregator();
            var reader = new OneLineAtATimeFileReader();

            reader.OnNewTextAvailableNotify(textObserver);
            reader.SetWorkingDirectory(TEST_FILE_PATH);
            reader.SetFilePath("emptyTestFile.txt");
            reader.Read();

            Assert.That(textObserver.ReceivedText.Count, Is.EqualTo(fileLineCount), "The result should contain all of the text in the file.");
        }

        [Test]
        public void When_reading_a_whole_single_line_file_at_once()
        {
            var textObserver = new TextHandOffObserver();
            var reader = new OneLineAtATimeFileReader();

            reader.OnNewTextAvailableNotify(textObserver);
            reader.SetWorkingDirectory(TEST_FILE_PATH);
            reader.SetFilePath("singleLineFile.txt");
            reader.Read();

            Assert.That(textObserver.ReceivedText, Is.EqualTo("42"));
        }

        [Test]
        public void When_reading_a_whole_multi_line_file_at_once()
        {
            var textObserver = new TextHandOffAggregator();
            var reader = new OneLineAtATimeFileReader();

            reader.OnNewTextAvailableNotify(textObserver);
            reader.SetWorkingDirectory(TEST_FILE_PATH);
            reader.SetFilePath("multilineFile.txt");
            reader.Read();

            Assert.That(textObserver.ReceivedText, Is.EqualTo(new []{"a", "b"}));
        }
    }
}
