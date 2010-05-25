namespace MoodDesignChallenge
{
    public interface IEncodingChannel
    {
        void Received(string stringToEncode);
    }
}