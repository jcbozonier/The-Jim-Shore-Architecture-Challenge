using System;
using NUnit.Framework;

namespace MoodDesignChallenge.Tests
{
    [TestFixture]
    public class WholeFileAtOnceFileReaderTests
    {
        private string TEST_FILE_PATH = "Tests/TestFiles/";

        [Test]
        public void When_reading_a_whole_empty_file_at_once()
        {
            string actualResult = null;
            var reader = new WholeFileAtOnceFileReader();
            reader.Read(TEST_FILE_PATH + "emptyTestFile.txt", readText=>actualResult = readText);

            Assert.That(actualResult, Is.EqualTo(""), "The result should contain all of the text in the file.");
        }

        [Test]
        public void When_reading_a_whole_single_line_file_at_once()
        {
            string actualResult = null;
            var reader = new WholeFileAtOnceFileReader();

            reader.Read(TEST_FILE_PATH + "singleLineFile.txt", readText=>actualResult = readText);

            Assert.That(actualResult, Is.EqualTo("42"));
        }

        [Test]
        public void When_reading_a_whole_multi_line_file_at_once()
        {
            string actualResult = null;
            var reader = new WholeFileAtOnceFileReader();

            reader.Read(TEST_FILE_PATH + "multilineFile.txt", readText => actualResult = readText);

            Assert.That(actualResult, Is.EqualTo("a" + Environment.NewLine + "b"));
        }
    }
}
