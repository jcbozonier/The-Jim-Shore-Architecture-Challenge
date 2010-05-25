namespace MoodDesignChallenge
{
    public class RunNetwork
    {
        public static void RunSystem(IProcessedText guiWriter)
        {
            var configuration = new FileSystemConfiguration();
            var guiActor = new SystemControlCenter();
            var encoder = new ROT13Encoding();
            var fileReader = new WholeFileAtOnceFileReader();
            var fileWriter = new WholeFileAtOnceFileWriter();
            var encodedTextSubscribers = new IProcessedText[]
                                             {
                                                 guiActor, 
                                                 fileWriter
                                             }.CreateMultiObserver();

            configuration.SetFileReader(fileReader);
            configuration.SetFileWriter(fileWriter);
            guiActor.WhenReadyToStartReadingNotify(fileReader);
            guiActor.OnNewGUINotificationsNotify(guiWriter);
            fileReader.OnNewTextAvailableNotify(encoder);
            encoder.OnNewEncodedTextAvailableNotify(encodedTextSubscribers);

            configuration.Configure();

            guiActor.Encode();
        }
    }
}
