using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoodDesignChallenge;
using NUnit.Framework;
using Tests.FocusedIntegrationTests;

namespace Tests
{
    [TestFixture]
    public class ConsoleEndToEndTest
    {
        [Test]
        public void EndToEndWithInMainProject()
        {
            var FakeGuiConsoleWindow = new TextHandOffAggregator();
            ROT13EncodingFileWriter.Do(FakeGuiConsoleWindow, "e2e_from.txt", "e2e_to.txt");

            Assert.That(File.Exists("topath/e2e_to.txt"), "It should have created a results file.");

            Assert.That(File.ReadAllText("topath/e2e_to.txt"), Is.EqualTo(FromLinesToText(CorrectText)));
            Assert.That(FakeGuiConsoleWindow.ReceivedText, Is.EqualTo(CorrectText));
        }

        private string FromLinesToText(List<string> linesOfText)
        {
            var textResult = "";
            var firstLineDone = false;
            linesOfText.ForEach(text =>
                                    {
                                        textResult += firstLineDone ? Environment.NewLine + text : text;
                                        firstLineDone = true;
                                    });
            return textResult;
        }

        private List<string> CorrectText = new List<string>()
        {
            "Gur dhvpx oebja sbk whzcrq ",
            "bire gur ynml",
            "Yvxr qbt naq fhpu."
        };
    }
}
