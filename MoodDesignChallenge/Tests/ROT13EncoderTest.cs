using NUnit.Framework;

namespace MoodDesignChallenge.Tests
{
    [TestFixture]
    public class ROT13EncoderTest
    {
        [Test]
        public void When_ROT13_encoding_an_empty_string()
        {
            var expectedString = "";

            var textObserver = new TextObserver();
            var encoder = new ROT13Encoding();
            encoder.Encode("", textObserver.Received);

            Assert.That(textObserver.ReceivedText, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_ROT13_encoding_a_lowercase_letter()
        {
            var expectedString = "n";

            var textObserver = new TextObserver();
            var encoder = new ROT13Encoding();
            encoder.Encode("a", textObserver.Received);

            Assert.That(textObserver.ReceivedText, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_ROT13_encoding_an_uppercase_letter()
        {
            string actualString = null;
            var expectedString = "N";

            var encoder = new ROT13Encoding();
            encoder.Encode("A", encodedString => actualString = encodedString);

            Assert.That(actualString, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_ROT13_encoding_a_whitespace_character()
        {
            string actualString = null;
            var expectedString = "\t";

            var encoder = new ROT13Encoding();
            encoder.Encode("\t", encodedString => actualString = encodedString);

            Assert.That(actualString, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_ROT13_encoding_a_multicharacter_string()
        {
            string actualString = null;
            var expectedString = "no";

            var encoder = new ROT13Encoding();
            encoder.Encode("ab", encodedString=>actualString = encodedString);

            Assert.That(actualString, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_encoding_a_character_that_lies_between_Z_and_a_in_ascii()
        {
            string actualString = null;
            var expectedString = ((char)('Z' + 1)).ToString();

            var encoder = new ROT13Encoding();
            encoder.Encode(expectedString, encodedString=>actualString = encodedString);

            Assert.That(actualString, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_encoding_a_character_that_lies_beyond_lowercase_z_in_ascii()
        {
            string actualString = null;
            var expectedString = ((char) ('z' + 1)).ToString();

            var encoder = new ROT13Encoding();
            encoder.Encode(expectedString, encodedString=>actualString = encodedString);

            Assert.That(actualString, Is.EqualTo(expectedString));
        }
    }
}
