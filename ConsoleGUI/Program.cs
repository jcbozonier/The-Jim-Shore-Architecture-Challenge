using System;
using MoodDesignChallenge;

namespace ConsoleGUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
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

            guiActor.AddSubscriber(fileReader);
            guiActor.AddSubscriber(fileWriter as IFileWritingChannel);
            guiActor.AddSubscriber(guiWriter);
            fileReader.AddSubscriber(encoder);
            encoder.AddSubscriber(encodedTextSubscribers);

            guiActor.Encode(args[0], args[1]);
        }
    }
}
