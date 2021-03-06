﻿using MoodDesignChallenge;
using MoodDesignChallenge.Stubs;
using NUnit.Framework;

namespace Tests.UnitTests
{
    [TestFixture]
    public class ROT13EncoderTest
    {
        [Test]
        public void When_ROT13_encoding_an_empty_string()
        {
            var expectedString = "";

            var textObserver = new TextHandOffObserver();
            var encoder = new ROT13Encoding();
            encoder.OnNewEncodedTextAvailableNotify(textObserver);
            encoder.Handoff("");

            Assert.That(textObserver.ReceivedText, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_ROT13_encoding_a_lowercase_letter()
        {
            var expectedString = "n";

            var textObserver = new TextHandOffObserver();
            var encoder = new ROT13Encoding();
            encoder.OnNewEncodedTextAvailableNotify(textObserver);
            encoder.Handoff("a");

            Assert.That(textObserver.ReceivedText, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_ROT13_encoding_an_uppercase_letter()
        {
            var expectedString = "N";

            var textObserver = new TextHandOffObserver();
            var encoder = new ROT13Encoding();
            encoder.OnNewEncodedTextAvailableNotify(textObserver);
            encoder.Handoff("A");

            Assert.That(textObserver.ReceivedText, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_ROT13_encoding_a_whitespace_character()
        {
            var expectedString = "\t";

            var textObserver = new TextHandOffObserver();
            var encoder = new ROT13Encoding();
            encoder.OnNewEncodedTextAvailableNotify(textObserver);
            encoder.Handoff("\t");

            Assert.That(textObserver.ReceivedText, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_ROT13_encoding_a_multicharacter_string()
        {
            var expectedString = "no";

            var textObserver = new TextHandOffObserver();
            var encoder = new ROT13Encoding();
            encoder.OnNewEncodedTextAvailableNotify(textObserver);
            var originalText = "ab";
            encoder.Handoff(originalText);

            Assert.That(textObserver.ReceivedText, Is.EqualTo(expectedString));

            encoder.Handoff(textObserver.ReceivedText);

            Assert.That(textObserver.ReceivedText, Is.EqualTo(originalText));
        }

        [Test]
        public void When_encoding_a_character_that_lies_between_Z_and_a_in_ascii()
        {
            var expectedString = ((char)('Z' + 1)).ToString();
            var textObserver = new TextHandOffObserver();
            var encoder = new ROT13Encoding();
            encoder.OnNewEncodedTextAvailableNotify(textObserver);
            encoder.Handoff(expectedString);

            Assert.That(textObserver.ReceivedText, Is.EqualTo(expectedString));
        }

        [Test]
        public void When_encoding_a_character_that_lies_beyond_lowercase_z_in_ascii()
        {
            var expectedString = ((char) ('z' + 1)).ToString();
            var textObserver = new TextHandOffObserver();
            var encoder = new ROT13Encoding();
            encoder.OnNewEncodedTextAvailableNotify(textObserver);
            encoder.Handoff(expectedString);

            Assert.That(textObserver.ReceivedText, Is.EqualTo(expectedString));
        }
    }
}
