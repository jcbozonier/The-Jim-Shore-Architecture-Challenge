using System.IO;

namespace MoodDesignChallenge.FileSystem
{
    public class OneLineAtATimeFileReader : IFileReading, IFileSystemConfiguration
    {
        private ITextHandOff _textHandOff;
        private string FilePath;
        private string CurrentDirectory = "";

        public void OnNewTextAvailableNotify(ITextHandOff textHandOff)
        {
            _textHandOff = textHandOff;
        }

        public void Read()
        {
            var filePath = Path.Combine(CurrentDirectory, FilePath);

            using(var file = File.OpenText(filePath))
            {
                while (!file.EndOfStream)
                {
                    var readLine = file.ReadLine();
                    _textHandOff.Handoff(readLine);
                }
            }
            
        }

        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
        }

        public void SetWorkingDirectory(string directoryPath)
        {
            CurrentDirectory = directoryPath;
        }
    }
}