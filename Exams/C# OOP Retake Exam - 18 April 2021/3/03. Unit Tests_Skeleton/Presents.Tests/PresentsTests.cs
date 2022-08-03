namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            this.bag = new Bag();
        }

        [Test]
        public void Constructor1()
        {
            Assert.IsNotNull(bag);
        }
        [Test]
        public void Create1()
        {
            Assert.Throws<ArgumentNullException>(() => this.bag.Create(null));
        }
        [Test]
        public void Create2()
        {
            Present present = new Present("asd", 1);
            this.bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => this.bag.Create(present));
        }
        [Test]
        public void Create3()
        {
            Present present = new Present("asd", 1);
            Assert.AreEqual("Successfully added present asd.", this.bag.Create(present));
        }
        [Test]
        public void Remove1()
        {
            Present present = new Present("asd", 1);
            Assert.IsFalse(this.bag.Remove(present));
        }
        [Test]
        public void Remove2()
        {
            Present present = new Present("asd", 1);
            this.bag.Create(present);
            Assert.IsTrue(this.bag.Remove(present));
        }
        [Test]
        public void GetPresentWithLeastMagic1()
        {
            Present present1 = new Present("asd", 1);
            Present present2 = new Present("qwe", 2);
            this.bag.Create(present1);
            this.bag.Create(present2);
            Present presentToReturn = present1;

            Assert.That(this.bag.GetPresentWithLeastMagic(), Is.EqualTo(presentToReturn));
        }

        //[Test]
        //public void GetPresentWithLeastMagic2()
        //{
        //    Assert.That(this.bag.GetPresentWithLeastMagic(), Is.EqualTo(null));
        //}

        [Test]
        public void GetPresent1()
        {
            Present presentToReturn = new Present("qwe", 2);
            this.bag.Create(presentToReturn);

            Assert.That(this.bag.GetPresent("qwe"), Is.EqualTo(presentToReturn));
        }
        [Test]
        public void GetPresent2()
        {
            Present presentToReturn = new Present("qwe", 2);
            this.bag.Create(presentToReturn);

            Assert.That(this.bag.GetPresent("asd"), Is.EqualTo(null));
        }
        [Test]
        public void GetPresents1()
        {
            Present present1 = new Present("qwe", 2);
            Present present2 = new Present("asd", 5);
            this.bag.Create(present1);
            this.bag.Create(present2);

            List<Present> presentsNow = new List<Present>();
            presentsNow.Add(present1);
            presentsNow.Add(present2);

            Assert.AreEqual(presentsNow, this.bag.GetPresents());
        }
  

    }
}
