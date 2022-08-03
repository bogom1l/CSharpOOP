namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    public class RobotsTests
    {
        private RobotManager rm;
        [SetUp]
        public void StartUp()
        {
            this.rm = new RobotManager(3);
        }


        [Test]
        public void ConstructorCorrectReturn()
        {
            var robots = new RobotManager(0);  
            Assert.AreEqual(0, robots.Count);
            Assert.AreEqual(0, robots.Capacity);
        }

        [Test]
        public void CapacityArgExc()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-3));
        }

        [Test]
        public void AddIOExc1()
        {
            this.rm.Add(new Robot("name", 1));
            Assert.Throws<InvalidOperationException>(() => this.rm.Add(new Robot("name", 1)));
        }

        [Test]
        public void AddIOExc2()
        {
            this.rm.Add(new Robot("name", 1));
            this.rm.Add(new Robot("asd", 1));
            this.rm.Add(new Robot("qwe", 1));
            Assert.Throws<InvalidOperationException>(() => this.rm.Add(new Robot("rrrr", 1)));
        }

        [Test]
        public void AddCorrectReturn()
        {
            this.rm.Add(new Robot("qwe", 1));
            Assert.AreEqual(1, this.rm.Count);
        }

        [Test]
        public void RemoveIOExc()
        {
            this.rm.Add(new Robot("asd", 1));
            Assert.Throws<InvalidOperationException>(() => this.rm.Remove("rrrr"));
        }

        [Test]
        public void RemoveCorrectReturn()
        {
            this.rm.Add(new Robot("asd", 1));
            this.rm.Remove("asd");
            Assert.AreEqual(0, this.rm.Count);
        }

        [Test]
        public void WorkIOExc1()
        {
            Assert.Throws<InvalidOperationException>(() => this.rm.Work("rrrr", "asd", 6));
        }

        [Test]
        public void WorkIOExc2()
        {
            this.rm.Add(new Robot("asd", 5));
            Assert.Throws<InvalidOperationException>(() => this.rm.Work("asd", "kkk", 16));
        }

         [Test]
        public void WorkCorrectReturn()
        {
            Robot robot = new Robot("asd", 15);
            this.rm.Add(robot);
            this.rm.Work("asd", "kkk", 10);
            Assert.AreEqual(5, robot.Battery);
        }

        [Test]
        public void ChargeIOExc()
        {
            this.rm.Add(new Robot("qwe", 5));
            Assert.Throws<InvalidOperationException>(() => this.rm.Charge("asd"));
        }

        [Test]
        public void ChargeCorrectReturn()
        {
            Robot robot = new Robot("asd", 15);
            this.rm.Add(robot);
            this.rm.Charge("asd");
            Assert.AreEqual(robot.Battery, robot.MaximumBattery);

            Robot robo2t = new Robot("Goshe", 5);
            this.rm.Add(robo2t);
            this.rm.Charge("Goshe");
            Assert.AreEqual(robot.Battery, robot.MaximumBattery);
        }


    }
}
