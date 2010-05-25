using System;

namespace MoodDesignChallenge
{
    public interface IEncodingChannel
    {
        void Encode(string stringToEncode, Action<string> resultChannel);
    }
}