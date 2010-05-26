using MoodDesignChallenge;

namespace ConsoleGUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var guiWriter = new GuiWriter();

            ROT13EncodingFileWriter.Do(guiWriter, args[0], args[1]);
        }
    }
}
