using MoodDesignChallenge;
using MoodDesignChallenge.Stubs;
using NUnit.Framework;

namespace Tests.UnitTests
{
    [TestFixture]
    public class MultiTextObserverSubscriberTests
    {
        [Test]
        public void When_notifying_one_observer()
        {
            var observerA = new TextHandOffObserver();

            var multiObserver = new MultipleTextHandOffObserverSubscriber();
            multiObserver.AddSubscriber(observerA);

            multiObserver.Handoff("TEST!");

            Assert.That(observerA.ReceivedText, Is.EqualTo("TEST!"));
        }

        [Test]
        public void When_notifying_two_observers()
        {
            var observerA = new TextHandOffObserver();
            var observerB = new TextHandOffObserver();
            
            new[] {observerA, observerB}.CreateMultiObserver().Handoff("TEST!");

            Assert.That(observerA.ReceivedText, Is.EqualTo("TEST!"));
            Assert.That(observerB.ReceivedText, Is.EqualTo("TEST!"));
        }
    }
}
