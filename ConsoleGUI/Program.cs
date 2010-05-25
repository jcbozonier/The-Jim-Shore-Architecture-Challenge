using System;
using MoodDesignChallenge;
using MoodDesignChallenge.Channels;

namespace ConsoleGUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationActor();
            var guiActor = new GuiActor();
            var encoder = new ROT13Encoding();
            var fileReader = new WholeFileAtOnceFileReader();
            var fileWriter = new WholeFileAtOnceFileWriter();
            var guiWriter = new GuiWriter();
            var encodedTextSubscribers = new IProcessedTextChannel[]
                                               {
                                                   guiActor, 
                                                   fileWriter
                                               }.CreateMultiObserver();

            configuration.ActorToReadFromFilePath(fileReader);
            configuration.ActorToWriteToFilePath(fileWriter);
            guiActor.AddSubscriber(fileReader);
            guiActor.AddSubscriber(guiWriter);
            fileReader.AddSubscriber(encoder);
            encoder.AddSubscriber(encodedTextSubscribers);

            configuration.Configure();

            guiActor.Encode();
        }
    }
}
