﻿using System.Diagnostics;
using System.IO;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ConsoleEndToEndTest
    {
        [Test]
        public void Do()
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = "ConsoleGUI.exe";
                process.StartInfo.Arguments = "e2e_from.txt e2e_to.txt";

                process.Start();
                process.WaitForExit(2000);

                Assert.That(File.Exists("e2e_to.txt"), "It should have created a results file.");
                Assert.That(File.ReadAllText("e2e_to.txt"), Is.EqualTo(CorrectText));
            }
            finally
            {
                File.Delete("e2e_to.txt");
            }
        }

        private string CorrectText = @"Gur dhvpx oebja sbk whzcrq 
bire gur ynml
Yvxr qbt naq fhpu.";
    }
}
