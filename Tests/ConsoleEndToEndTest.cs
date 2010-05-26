using System.Diagnostics;
using System.IO;
using MoodDesignChallenge;
using MoodDesignChallenge.Stubs;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ConsoleEndToEndTest
    {
        [Test]
        public void EndToEndWithInMainProject()
        {
            var textObservable = new TextHandOffObserver();
            ROT13EncodingFileWriter.Do(textObservable, "e2e_from.txt", "e2e_to.txt");

            Assert.That(File.Exists("topath/e2e_to.txt"), "It should have created a results file.");
            Assert.That(File.ReadAllText("topath/e2e_to.txt"), Is.EqualTo(CorrectText));
            Assert.That(textObservable.ReceivedText, Is.EqualTo(CorrectText));
        }

        private string CorrectText = @"Gur dhvpx oebja sbk whzcrq 
bire gur ynml
Yvxr qbt naq fhpu.";
    }
}
