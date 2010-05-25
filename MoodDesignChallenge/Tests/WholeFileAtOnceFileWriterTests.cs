﻿using System;
using System.IO;
using NUnit.Framework;

namespace MoodDesignChallenge.Tests
{
    [TestFixture]
    public class WholeFileAtOnceFileWriterTests
    {
        [Test]
        public void When_writing_a_whole_empty_file_at_once()
        {
            try
            {
                var testText = "abc" + Environment.NewLine + "defdfssd fsdf dssd34$#33 dfsf";
                var writer = new WholeFileAtOnceFileWriter();
                writer.Write(testText, "writternEmptyFile.txt");

                var actualFileText = File.ReadAllText("writternEmptyFile.txt");

                Assert.That(actualFileText, Is.EqualTo(testText));
            }
            finally
            {
                File.Delete("writternEmptyFile.txt");
            }
        }
    }
}
