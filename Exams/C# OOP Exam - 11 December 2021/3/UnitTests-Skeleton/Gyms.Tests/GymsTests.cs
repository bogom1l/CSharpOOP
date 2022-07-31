namespace Gyms.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class GymsTests
    {
        private Gym gym;

        [SetUp]
        public void SetUp()
        {
            this.gym = new Gym("ZalataNaHulk", 5);
        }

        [Test]
        public void ConstructorCorrectReturn()
        {
            Assert.IsNotNull(this.gym);
            Assert.AreEqual(0, this.gym.Count);
            Assert.AreEqual(5, this.gym.Capacity);
            Assert.AreEqual("ZalataNaHulk", gym.Name);
        }

        [Test]
        public void NameNullOrEmptyException()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(string.Empty, 1));
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 1));
        }

        [Test]
        public void CapacityLessThanZeroException()
        {
            Assert.Throws<ArgumentException>(() => new Gym("asd", -5));
        }

        [Test]
        public void CountCorrectReturn()
        {
            Gym gym = new Gym("asd", 5);
            gym.AddAthlete(new Athlete("goshko"));
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void AddAthleteException()
        {
            Gym gym = new Gym("asd", 0);
            Athlete athlete = new Athlete("koitoidae");
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete));

        }
        [Test]
        public void AddAtheleteCorrectReturn()
        {
            Athlete athlete = new Athlete("koitoidae");
            this.gym.AddAthlete(athlete);
            Assert.IsNotNull(athlete);
            Assert.AreEqual(1, this.gym.Count);
            Assert.AreEqual(5, this.gym.Capacity);
        }

        [Test]
        public void RemoveAthleteDoesntExistException()
        {
            this.gym.AddAthlete(new Athlete("zdravko"));
            Assert.Throws<InvalidOperationException>(() => this.gym.RemoveAthlete("koitoidae"));
        }

        [Test]
        public void RemoveAthleteCorrectReturn()
        {
            this.gym.AddAthlete(new Athlete("zdravko"));
            this.gym.RemoveAthlete("zdravko");
            Assert.AreEqual(0, this.gym.Count);

            this.gym.AddAthlete(new Athlete("asd"));
            this.gym.AddAthlete(new Athlete("qwe"));
            this.gym.RemoveAthlete("qwe");
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void InjureAthleteException()
        {
            Assert.Throws<InvalidOperationException>(() => this.gym.InjureAthlete("koitoidae"));
        }

        [Test]
        public void InjureAthleteCorrectReturn()
        {
            Athlete athlete = new Athlete("zdravko");
            this.gym.AddAthlete(athlete);
            this.gym.InjureAthlete("zdravko");

            Assert.AreEqual(true, athlete.IsInjured);

            Athlete injAthl = new Athlete("gesha");
            this.gym.AddAthlete(injAthl);
            this.gym.InjureAthlete(injAthl.FullName);

            Assert.AreEqual(injAthl, gym.InjureAthlete(injAthl.FullName));
        }

        [Test]
        public void ReportCorrectReturn()
        {
            Athlete athleteA = new Athlete("zdravko");
            Athlete athleteB = new Athlete("bebe");
            this.gym.AddAthlete(athleteA);
            this.gym.AddAthlete(athleteB);

            Assert.AreEqual("Active athletes at ZalataNaHulk: zdravko, bebe", gym.Report());

            athleteA.IsInjured = true;
            Assert.AreEqual("Active athletes at ZalataNaHulk: bebe", gym.Report());
        }


    }
}
