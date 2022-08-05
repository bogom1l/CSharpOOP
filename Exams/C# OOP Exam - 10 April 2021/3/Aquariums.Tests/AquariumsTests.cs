namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    //[TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            this.aquarium = new Aquarium("zdravko", 2);
        }

        [Test]
        public void ConstructorCorrectReturn()
        {
            Assert.IsNotNull(aquarium);
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void NameException()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 2));
            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 1));
        }

        [Test]
        public void CapacityException()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("asd", -2));
            Assert.Throws<ArgumentException>(() => new Aquarium("qwe", -5));
        }

        [Test]
        public void TestAdd()
        {
            this.aquarium.Add(new Fish("asd"));
            Assert.AreEqual(1, this.aquarium.Count);

            this.aquarium.Add(new Fish("fffff"));
            Assert.AreEqual(2, this.aquarium.Count);

            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(new Fish("qwe")));
        }

        [Test]
        public void TestRemoveFish()
        {
            this.aquarium.Add(new Fish("asd"));
            this.aquarium.Add(new Fish("qwe"));
            Assert.AreEqual(2, this.aquarium.Count);

            this.aquarium.RemoveFish("qwe");
            Assert.AreEqual(1, this.aquarium.Count);

            this.aquarium.RemoveFish("asd");
            Assert.AreEqual(0, this.aquarium.Count);

            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish("invalid"));
        }

        [Test]
        public void TestSellFish()
        {
            Fish fish1 = new Fish("asd");
            Fish fish2 = new Fish("qwe");

            this.aquarium.Add(fish1);
            this.aquarium.Add(fish2);
            Assert.AreEqual(2, this.aquarium.Count);

            Assert.IsTrue(fish1.Available);
            this.aquarium.SellFish("asd");
            Assert.IsFalse(fish1.Available);

            Assert.AreEqual(fish1, this.aquarium.SellFish("asd"));

            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish("invalid"));
        }

        [Test]
        public void TestReport()
        {
            Fish fish1 = new Fish("asd");
            Fish fish2 = new Fish("qwe");

            this.aquarium.Add(fish1);
            this.aquarium.Add(fish2);

            Assert.AreEqual("Fish available at zdravko: asd, qwe", this.aquarium.Report());
        }






    }
}
