using MoodDesignChallenge.FileSystem;
using MoodDesignChallenge.Stubs;

namespace MoodDesignChallenge
{
    public class ROT13EncodingFileWriter
    {
        public static void Do(ITextHandOff guiWriter, string fromFile, string toFile)
        {
            var configuration = new FileSystemConfiguration();
            var encoder = new ROT13Encoding();
            var fileReader = new OneLineAtATimeFileReader();
            var fileWriter = new OneLineAtATimeFileWriter();
            var encodedTextSubscribers = new[]
                                             {
                                                 guiWriter, 
                                                 fileWriter
                                             }.CreateMultiObserver();

            configuration.SetFileReaderToConfigure(fileReader);
            configuration.SetFileWriterToConfigure(fileWriter);
            fileReader.OnNewTextAvailableNotify(encoder);
            encoder.OnNewEncodedTextAvailableNotify(encodedTextSubscribers);

            configuration.Configure();

            fileReader.SetFilePath(fromFile);
            fileWriter.SetFilePath(toFile);

            fileReader.Read();
        }
    }
}
