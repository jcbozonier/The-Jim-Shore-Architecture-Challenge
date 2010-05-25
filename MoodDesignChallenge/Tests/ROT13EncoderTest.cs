﻿using NUnit.Framework;

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
            encoder.SubscribeTo(textObserver);
            encoder.Encode("");

            Assert.That(textObserver.ReceivedText, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_ROT13_encoding_a_lowercase_letter()
        {
            var expectedString = "n";

            var textObserver = new TextObserver();
            var encoder = new ROT13Encoding();
            encoder.SubscribeTo(textObserver);
            encoder.Encode("a");

            Assert.That(textObserver.ReceivedText, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_ROT13_encoding_an_uppercase_letter()
        {
            var expectedString = "N";

            var textObserver = new TextObserver();
            var encoder = new ROT13Encoding();
            encoder.SubscribeTo(textObserver);
            encoder.Encode("A");

            Assert.That(textObserver.ReceivedText, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_ROT13_encoding_a_whitespace_character()
        {
            var expectedString = "\t";

            var textObserver = new TextObserver();
            var encoder = new ROT13Encoding();
            encoder.SubscribeTo(textObserver);
            encoder.Encode("\t");

            Assert.That(textObserver.ReceivedText, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_ROT13_encoding_a_multicharacter_string()
        {
            var expectedString = "no";

            var textObserver = new TextObserver();
            var encoder = new ROT13Encoding();
            encoder.SubscribeTo(textObserver);
            encoder.Encode("ab");

            Assert.That(textObserver.ReceivedText, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_encoding_a_character_that_lies_between_Z_and_a_in_ascii()
        {
            var expectedString = ((char)('Z' + 1)).ToString();
            var textObserver = new TextObserver();
            var encoder = new ROT13Encoding();
            encoder.SubscribeTo(textObserver);
            encoder.Encode(expectedString);

            Assert.That(textObserver.ReceivedText, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_encoding_a_character_that_lies_beyond_lowercase_z_in_ascii()
        {
            var expectedString = ((char) ('z' + 1)).ToString();
            var textObserver = new TextObserver();
            var encoder = new ROT13Encoding();
            encoder.SubscribeTo(textObserver);
            encoder.Encode(expectedString);

            Assert.That(textObserver.ReceivedText, Is.EqualTo(expectedString));
        }
    }
}
