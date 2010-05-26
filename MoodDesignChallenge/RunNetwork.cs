using MoodDesignChallenge.FileSystem;
using MoodDesignChallenge.Stubs;

namespace MoodDesignChallenge
{
    public class RunNetwork
    {
        public static void RunSystem(ITextHandOff guiWriter, string fromFile, string toFile)
        {
            var configuration = new FileSystemConfiguration();
            var encoder = new ROT13Encoding();
            var fileReader = new WholeFileAtOnceFileReader();
            var fileWriter = new WholeFileAtOnceFileWriter();
            var encodedTextSubscribers = new[]
                                             {
                                                 guiWriter, 
                                                 fileWriter
                                             }.CreateMultiObserver();

            configuration.SetFileReader(fileReader);
            configuration.SetFileWriter(fileWriter);
            fileReader.OnNewTextAvailableNotify(encoder);
            encoder.OnNewEncodedTextAvailableNotify(encodedTextSubscribers);

            configuration.Configure();

            fileReader.SetFilePath(fromFile);
            fileWriter.SetFilePath(toFile);

            fileReader.Read();
        }
    }
}
