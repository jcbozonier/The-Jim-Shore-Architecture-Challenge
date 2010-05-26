using System;
using MoodDesignChallenge;
using MoodDesignChallenge.Stubs;
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

            Assert.That(fileReader.ReceivedWorkingDirectory, Is.EqualTo("frompath/"));
            Assert.That(fileWriter.ReceivedWorkingDirectory, Is.EqualTo("topath/"));
        }
    }
}
