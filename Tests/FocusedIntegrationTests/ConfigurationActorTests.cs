using System;
using MoodDesignChallenge;
using MoodDesignChallenge.Channels;
using NUnit.Framework;

namespace Tests.FocusedIntegrationTests
{
    [TestFixture]
    public class ConfigurationActorTests
    {
        [Test]
        public void When_starting_up()
        {
            var fileReader = new FileReaderConfigurationChannel();
            var fileWriter = new FileWriterConfigurationChannel();
            var configurationActor = new ConfigurationActor();

            configurationActor.ActorToReadFromFilePath(fileReader);
            configurationActor.ActorToWriteToFilePath(fileWriter);

            configurationActor.Configure();

            Assert.That(fileReader.ReceivedFilePath, Is.EqualTo("e2e_from.txt"));
            Assert.That(fileWriter.ReceivedFilePath, Is.EqualTo("e2e_to.txt"));
        }
    }

    public class FileWriterConfigurationChannel : IFilePathConfiguration
    {
        public string ReceivedFilePath;

        public void SetFilePath(string filePath)
        {
            ReceivedFilePath = filePath;
        }
    }

    public class FileReaderConfigurationChannel : IFilePathConfiguration
    {
        public string ReceivedFilePath;
        public void SetFilePath(string filePath)
        {
            ReceivedFilePath = filePath;
        }
    }
}
