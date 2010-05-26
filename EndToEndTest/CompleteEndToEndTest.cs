using System.Diagnostics;
using System.IO;
using NUnit.Framework;

namespace EndToEndTest
{
    [TestFixture]
    public class CompleteEndToEndTest
    {
        [Test]
        public void ConsoleTest()
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = "../../../ConsoleGUI/bin/debug/ConsoleGUI.exe";
                process.StartInfo.Arguments = "e2e_from.txt e2e_to.txt";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardOutput = true;

                process.Start();
                process.WaitForExit(2000);

                var outputText = process.StandardOutput.ReadToEnd();

                Assert.That(File.Exists("To/e2e_to.txt"), "It should have created a results file.");
                Assert.That(File.ReadAllText("To/e2e_to.txt"), Is.EqualTo(CorrectText));
                Assert.That(outputText, Is.Not.Empty);
                Assert.That(outputText, Contains.Substring(CorrectText));
            }
            finally
            {
                File.Delete("../../../ConsoleGUI/bin/debug/To/e2e_to.txt");
            }
        }

        private string CorrectText = @"Gur dhvpx oebja sbk whzcrq 
bire gur ynml
Yvxr qbt naq fhpu.";
    }
}
