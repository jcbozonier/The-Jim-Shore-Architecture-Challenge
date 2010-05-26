using System;
using System.IO;
using MoodDesignChallenge;
using NUnit.Framework;

namespace Tests.FocusedIntegrationTests
{
    [TestFixture]
    public class WholeFileAtOnceFileWriterTests
    {
        [Test]
        public void When_writing_a_whole_empty_file_at_once()
        {
            var fileName = "writtenEmptyFile.txt";
            var directoryPath = "FocusedIntegrationTests/TestOutput/";

            var fullTestFilePath = Path.Combine(directoryPath, fileName);
            try
            {
                var testText = "abc" + Environment.NewLine + "defdfssd fsdf dssd34$#33 dfsf";
                var writer = new WholeFileAtOnceFileWriter();

                writer.SetWorkingDirectory(directoryPath);
                writer.SetFilePath(fileName);
                writer.Process(testText);

                var actualFileText = File.ReadAllText(directoryPath + fileName);

                Assert.That(actualFileText, Is.EqualTo(testText));
            }
            finally
            {
                File.Delete(fullTestFilePath);
            }
        }
    }
}
