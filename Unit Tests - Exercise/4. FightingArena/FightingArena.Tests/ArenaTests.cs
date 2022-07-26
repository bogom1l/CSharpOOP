namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
        }


        [Test]
        public void TestConstructorInitializesEmptyCollectionOfWarriors()
        {
            Arena testArena = new Arena();

            List<Warrior> actualCollection = testArena.Warriors.ToList();
            List<Warrior> expectedCollection = new List<Warrior>();

            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void TestWarriorsCollectionsDataReturnsCorrectData()
        {
            Warrior pesho = new Warrior("Pesho", 30, 100);
            Warrior gosho = new Warrior("Gosho", 35, 85);

            this.arena.Enroll(pesho);
            this.arena.Enroll(gosho);

            List<Warrior> actualCollection = this.arena.Warriors.ToList();
            List<Warrior> expectedCollection = new List<Warrior>() { pesho, gosho };


            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void TestIfWarriosCollectionIsEncapsulatedProperly()
        {
            string actualType = typeof(Arena).GetProperties().First(pi => pi.Name == "Warriors").PropertyType.Name;
            string expectedType = typeof(IReadOnlyCollection<Warrior>).Name;

            Assert.AreEqual(expectedType, actualType);
        }

        [Test]
        public void CountShouldReturnZeroOnEmptyArena()
        {
            Assert.AreEqual(arena.Count, 0);    
        }

        [Test]
        public void CountShouldReturnCorrectValuesWhenThereAreEnrolledWarriars()
        {
            Warrior warrior = new Warrior("a", 1, 1);
            this.arena.Enroll(warrior);

            int actualCount = this.arena.Count;
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void EnrollShouldThrowAnExceptionWhenEnrollingExistingWarrior()
        {
            Warrior warrior = new Warrior("a", 1, 2);
            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException> ( () => { this.arena.Enroll(warrior); } );
        }

        [Test]
        public void FightBetweenInExistingAttackerShouldThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 1, 2);
            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => { this.arena.Fight("Invalid", "Pesho"); });
        }

        [Test]
        public void FightBetweenInExistingDefenderShouldThrowException()
        {
            Warrior warrior = new Warrior("Pesho", 1, 2);
            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => { this.arena.Fight("Pesho", "Invalid"); });
        }

        [Test]
        public void FightBetweenExistingWarriorShouldSucceed()
        {
            Warrior warriorA = new Warrior("a", 1, 100);
            Warrior warriorD = new Warrior("b", 3, 100);
            this.arena.Enroll(warriorA);
            this.arena.Enroll(warriorD);

            this.arena.Fight("a", "b");

            int actualAttackerHp = warriorA.HP;
            int expectedAttackerHp = 100 - warriorD.Damage;

            int actualDefenderHp = warriorD.HP;
            int expectedDefenderHp = 100 - warriorA.Damage;

            Assert.AreEqual(expectedDefenderHp, actualDefenderHp);
            Assert.AreEqual(expectedAttackerHp, actualAttackerHp);
        }



    }
}
