using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLosesDurabilityAfterEachAtack()
        {
            //Arrange
            Axe axe = new(10, 5);
            Dummy dummy = new(40, 10);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(4), "Axe durability doesn't change after attack.");
        }
        [Test]
        public void AttackWithBrokenWepon()
        {
            //Arrange
            Axe axe = new(10, 5);
            Dummy dummy = new(60, 10);

            //Act
            for (int i = 0; i < 5; i++)
            {
                axe.Attack(dummy);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
        
    }
}