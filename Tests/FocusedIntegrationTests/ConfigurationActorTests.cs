using System;
using MoodDesignChallenge;
using NUnit.Framework;

namespace Tests.FocusedIntegrationTests
{
    [TestFixture]
    public class ConfigurationActorTests
    {
        [Test]
        public void When_starting_up()
        {
            var fileReader = new FileSystemConfigurationChannel();
            var fileWriter = new FileSystemConfigurationChannel();
            var configurationActor = new FileSystemConfiguration();

            configurationActor.SetFileReader(fileReader);
            configurationActor.SetFileWriter(fileWriter);

            configurationActor.Configure();

            Assert.That(fileReader.ReceivedFilePath, Is.EqualTo("e2e_from.txt"));
            Assert.That(fileWriter.ReceivedFilePath, Is.EqualTo("e2e_to.txt"));
        }
    }
}
