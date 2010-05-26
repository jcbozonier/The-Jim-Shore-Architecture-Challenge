using System;
using System.IO;
using MoodDesignChallenge;
using MoodDesignChallenge.FileSystem;
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
                var testTextLineOne = "abc";
                var testTextLineTwo = "defdfssd fsdf dssd34$#33 dfsf";
                var writer = new OneLineAtATimeFileWriter();

                writer.SetWorkingDirectory(directoryPath);
                writer.SetFilePath(fileName);

                writer.Handoff(testTextLineOne);
                writer.Handoff(testTextLineTwo);

                var actualFileText = File.ReadAllText(directoryPath + fileName);

                Assert.That(actualFileText, Is.EqualTo(testTextLineOne + Environment.NewLine + testTextLineTwo));
            }
            finally
            {
                File.Delete(fullTestFilePath);
            }
        }
    }
}
