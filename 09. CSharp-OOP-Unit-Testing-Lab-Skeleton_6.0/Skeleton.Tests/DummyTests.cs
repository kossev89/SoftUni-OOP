using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthWhenAttacked()
        {
            //Arange
            Dummy dummy = new(60, 5);

            //Act
            dummy.TakeAttack(10);

            //Assert
            Assert.That(dummy.Health, Is.EqualTo(50), "Dummy does not lose health.");
        }
        [Test]
        public void DeadDummyThrowsExceptionWhenAttacked()
        {
            //Arange
            Dummy dummy = new(60, 5);

            //Act
            for (int i = 0; i < 6; i++)
            {
                dummy.TakeAttack(10);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10), "No exception thrown");
        }
        [Test]
        public void DeadDummyCanGiveXP()
        {
            //Arange
            Dummy dummy = new(60, 5);

            //Act
            for (int i = 0; i < 6; i++)
            {
                dummy.TakeAttack(10);
            }
            int experience = dummy.GiveExperience();

            //Assert
            Assert.That(experience, Is.EqualTo(5), "No experience is given!");
        }
        [Test]
        public void AliveDummyCannotGiveXP()
        {
            //Arange
            Dummy dummy = new(60, 5);

            //Act
                dummy.TakeAttack(10);

            //Assert
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "No exception thrown");
        }

    }
}