namespace MoodDesignChallenge
{
    public class SystemControlCenter : IProcessedText
    {
        private IFileReading _fileReading;
        private IProcessedText _display;

        public void Encode()
        {
            _fileReading.Read();
        }

        public void WhenReadyToStartReadingNotify(IFileReading fileReading)
        {
            _fileReading = fileReading;
        }

        public void OnNewGUINotificationsNotify(IProcessedText display)
        {
            _display = display;
        }

        public void Process(string text)
        {
            _display.Process(text);
        }
    }
}