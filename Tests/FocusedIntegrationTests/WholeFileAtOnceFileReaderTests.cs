﻿using System;
using MoodDesignChallenge;
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
            var textObserver = new ProcessedTextObserver();
            var reader = new WholeFileAtOnceFileReader();
            reader.AddSubscriber(textObserver);
            reader.Read(TEST_FILE_PATH + "emptyTestFile.txt");

            Assert.That(textObserver.ReceivedText, Is.EqualTo(""), "The result should contain all of the text in the file.");
        }

        [Test]
        public void When_reading_a_whole_single_line_file_at_once()
        {
            var textObserver = new ProcessedTextObserver();
            var reader = new WholeFileAtOnceFileReader();
            reader.AddSubscriber(textObserver);
            reader.Read(TEST_FILE_PATH + "singleLineFile.txt");

            Assert.That(textObserver.ReceivedText, Is.EqualTo("42"));
        }

        [Test]
        public void When_reading_a_whole_multi_line_file_at_once()
        {
            var textObserver = new ProcessedTextObserver();
            var reader = new WholeFileAtOnceFileReader();
            reader.AddSubscriber(textObserver);
            reader.Read(TEST_FILE_PATH + "multilineFile.txt");

            Assert.That(textObserver.ReceivedText, Is.EqualTo("a" + Environment.NewLine + "b"));
        }
    }
}