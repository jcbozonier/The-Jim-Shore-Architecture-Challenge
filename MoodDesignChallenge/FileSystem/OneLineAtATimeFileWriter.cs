using System;
using System.IO;

namespace MoodDesignChallenge.FileSystem
{
    public class OneLineAtATimeFileWriter : ITextHandOff, IFileSystemConfiguration
    {
        private string FilePath;
        private string WorkingDirectory;
        private bool FirstWriteToFile = true;

        public void Handoff(string textToWrite)
        {
            var fullFilePath = Path.Combine(WorkingDirectory, FilePath);
            if(FirstWriteToFile && File.Exists(fullFilePath))
                File.Delete(fullFilePath);
            var formattedTextToWrite = FirstWriteToFile
                                           ? textToWrite
                                           : Environment.NewLine + textToWrite;
            File.AppendAllText(fullFilePath, formattedTextToWrite);
            FirstWriteToFile = false;
        }

        public void SetFilePath(string toFilePath)
        {
            FilePath = toFilePath;
        }

        public void SetWorkingDirectory(string directoryPath)
        {
            WorkingDirectory = directoryPath;
        }
    }
}