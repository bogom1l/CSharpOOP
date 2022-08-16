using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            //Planet tests

            [Test]
            public void TestConstructorPlanet()
            {
                Planet planet = new Planet("asd", 123);
                Assert.IsEmpty(planet.Weapons);
                Assert.AreEqual(0, planet.Weapons.Count);
                Assert.AreEqual("asd", planet.Name);
                Assert.AreEqual(123, planet.Budget);
            }

            [Test]
            public void PlanetName()
            {
                Assert.Throws<ArgumentException>(() => new Planet(null, 1));
            }

            [Test]
            public void PlanetBudget()
            {
                Assert.Throws<ArgumentException>(() => new Planet("a", -2));
            }

            [Test]
            public void MilitaryPowerRatioTest()
            {
                Planet planet = new Planet("asd", 123);

                Weapon weapon1 = new Weapon("a", 1, 2);

                Weapon weapon2 = new Weapon("b", 4, 6);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(8, planet.MilitaryPowerRatio);
            }

            [Test]
            public void ProfitTest()
            {
                Planet planet = new Planet("asd", 123);
                planet.Profit(1);
                Assert.AreEqual(124, planet.Budget);
            }

            [Test]
            public void SpendTest()
            {
                Planet planet = new Planet("asd", 123);
                planet.SpendFunds(3);
                
                Assert.AreEqual(120, planet.Budget);
                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(311));
            }

            [Test]
            public void TestAddWeapon()
            {
                Planet planet = new Planet("asd", 123);

                Weapon weapon1 = new Weapon("a", 1, 2);
                Weapon weapon2 = new Weapon("b", 4, 6);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon1));
                Assert.AreEqual(2, planet.Weapons.Count);
            }

            [Test]
            public void TestRemoveWeapon()
            {
                Planet planet = new Planet("asd", 123);

                Weapon weapon1 = new Weapon("a", 1, 2);
                Weapon weapon2 = new Weapon("b", 4, 6);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                planet.RemoveWeapon(weapon1.Name);

                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void UpgradeWeaponTest()
            {
                Planet planet = new Planet("asd", 123);

                Weapon weapon1 = new Weapon("a", 1, 2);
                Weapon weapon2 = new Weapon("b", 4, 6);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                planet.UpgradeWeapon(weapon1.Name);

                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("aaaaaaa"));

                Assert.AreEqual(3, weapon1.DestructionLevel);
            }

            [Test]
            public void TestDestructOpponent()
            {
                Planet planet1 = new Planet("asd", 100);
                Planet planet2 = new Planet("qwe", 5);

                Weapon weapon1 = new Weapon("a", 1, 2);
                Weapon weapon2 = new Weapon("b", 4, 6);

                planet1.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() => planet1.DestructOpponent(planet2));
                Assert.AreEqual($"{planet1.Name} is destructed!", planet2.DestructOpponent(planet1));
            }


            /////////////////////////////////////////////////////////////

            //Weapon tests

            [Test]
            public void TestConstructorWweapoan()
            {
                Weapon weapon = new Weapon("asd", 5, 10);
                Assert.AreEqual(5, weapon.Price);
                Assert.AreEqual(10, weapon.DestructionLevel);
                Assert.AreEqual("asd", weapon.Name);
            }

            [Test]
            public void TestPrice()
            {
                Assert.Throws<ArgumentException>(() => new Weapon("aa", -2, 11));
            }

            [Test]
            public void TestIncreaseDestructionLevel()
            {
                Weapon weapon = new Weapon("asd", 5, 10);
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(11, weapon.DestructionLevel);
            }

            [Test]
            public void TestIsNuclear()
            {
                Weapon weapon1 = new Weapon("asd", 5, 15);
                Weapon weapon2 = new Weapon("asd", 5, 5);

                Assert.IsTrue(weapon1.IsNuclear);
                Assert.False(weapon2.IsNuclear);
            }





        }
    }
}
