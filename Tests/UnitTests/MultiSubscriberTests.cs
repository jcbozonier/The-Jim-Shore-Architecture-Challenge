using MoodDesignChallenge;
using NUnit.Framework;

namespace Tests.UnitTests
{
    [TestFixture]
    public class MultiTextObserverSubscriberTests
    {
        [Test]
        public void When_notifying_one_observer()
        {
            var observerA = new ProcessedTextObserver();

            var multiObserver = new MultipleTextObserverSubscriber();
            multiObserver.AddSubscriber(observerA);

            multiObserver.Process("TEST!");

            Assert.That(observerA.ReceivedText, Is.EqualTo("TEST!"));
        }

        [Test]
        public void When_notifying_two_observers()
        {
            var observerA = new ProcessedTextObserver();
            var observerB = new ProcessedTextObserver();
            
            new[] {observerA, observerB}.CreateMultiObserver().Process("TEST!");

            Assert.That(observerA.ReceivedText, Is.EqualTo("TEST!"));
            Assert.That(observerB.ReceivedText, Is.EqualTo("TEST!"));
        }
    }
}
