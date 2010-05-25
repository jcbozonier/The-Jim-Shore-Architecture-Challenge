using System;

namespace MoodDesignChallenge
{
    public interface IFileReadingChannel
    {
        void Read(string filePath, Action<string> resultChannel);
    }
}