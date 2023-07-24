using NUnit.Framework;
using System.Linq;

namespace RobotFactory.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProduceRobot_CheckCapacity()
        {
            Factory factory = new Factory("testFactory", 3);

            Robot robot = new Robot("battle", 25.00, 1);
            Robot robot1 = new Robot("service", 15.00, 2);
            Robot robot2 = new Robot("eng", 35.00, 3);
            factory.Robots.Add(robot);
            factory.Robots.Add(robot1);
            factory.Robots.Add(robot2);

            string actualResult = factory.ProduceRobot("special", 45.00, 4);
            string expectedResult = $"The factory is unable to produce more robots for this production day!";

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void ProduceRobot_WorksCorrectly()
        {
            Factory factory = new Factory("testFactory", 3);

            factory.ProduceRobot("battle", 25.00, 1);
            factory.ProduceRobot("service", 15.00, 2);


            string actualResult = factory.ProduceRobot("eng", 35.00, 3);
            string expectedResult = $"Produced --> {factory.Robots.Last()}";

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void ProduceSupplement_AddSupplementCorrectly()
        {
            Factory factory = new Factory("testFactory", 3);

            string actualResult = factory.ProduceSupplement("mineral", 3);
            string expectedResult = $"Supplement: mineral IS: 3";

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void UpgradeRobot_WhenSupplementIsPresent()
        {
            Factory factory = new Factory("testFactory", 3);

            factory.ProduceRobot("battle", 25.00, 1);
            factory.ProduceRobot("service", 15.00, 2);

            factory.ProduceSupplement("mineral", 1);
            factory.ProduceSupplement("mineral", 1);

            factory.UpgradeRobot(factory.Robots.First(), factory.Supplements.First());

            Assert.IsFalse(factory.UpgradeRobot(factory.Robots.First(), factory.Supplements.First()));
        }
        [Test]
        public void UpgradeRobot_WhenInterfaceIsDifferent()
        {
            Factory factory = new Factory("testFactory", 3);

            factory.ProduceRobot("battle", 25.00, 1);
            factory.ProduceRobot("service", 15.00, 2);

            factory.ProduceSupplement("mineral", 1);
            factory.ProduceSupplement("gas", 2);

            factory.UpgradeRobot(factory.Robots.First(), factory.Supplements.First());

            Assert.IsFalse(factory.UpgradeRobot(factory.Robots.First(), factory.Supplements.Last()));
        }
        [Test]
        public void UpgradeRobot_WorksCorrectly()
        {
            Factory factory = new Factory("testFactory", 3);

            factory.ProduceRobot("battle", 25.00, 1);
            factory.ProduceRobot("service", 15.00, 2);

            factory.ProduceSupplement("mineral", 1);
            factory.ProduceSupplement("gas", 1);

            factory.UpgradeRobot(factory.Robots.First(), factory.Supplements.First());

            Assert.IsTrue(factory.UpgradeRobot(factory.Robots.First(), factory.Supplements.Last()));
        }
        [Test]
        public void SellRobot_Test()
        {
            Factory factory = new Factory("testFactory", 3);

            factory.ProduceRobot("battle", 25.00, 1);
            factory.ProduceRobot("service", 15.00, 2);

            
            Robot actualResult = factory.SellRobot(15);
            Robot expectedResult = factory.Robots.Last();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}