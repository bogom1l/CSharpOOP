namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDmg = 55;
            int expectedHP = 55;
            Warrior warrior = new Warrior(expectedName, expectedDmg, expectedHP);

            string actualName = warrior.Name;
            int actualDmg = warrior.Damage;
            int actualHP = warrior.HP;

            Assert.AreEqual(expectedName, actualName, "Constructor should initialize the Name of the Warrior!");
            Assert.AreEqual(expectedDmg, actualDmg, "Constructor should initialize the Dmg of the Warrior!");
            Assert.AreEqual(expectedHP, actualHP, "Constructor should initialize the HP of the Warrior!");

        }

        [TestCase(0)]
        [TestCase(10)]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackShouldThrowErrorWhenAttackingWarriorIsLow(int startHP)
        {
            Warrior warriorA = new Warrior("Pesho", 70, startHP);
            Warrior warriorD = new Warrior("Gosho", 55, 45);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorA.Attack(warriorD);
            }, "Your HP is too low in order to attack other warriors!");
        }


        [TestCase(0)]
        [TestCase(10)]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackShouldThrowErrorWhenDefendingWarriorIsLow(int startHP)
        {
            Warrior warriorA = new Warrior("Pesho", 45, 65);
            Warrior warriorD = new Warrior("Gosho", 35, startHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorA.Attack(warriorD);
            }, "Enemy HP must be greater than 30 in order to attack him!");
        }


        [TestCase(50, 60)]
        [TestCase(50, 51)]
        public void AttackShouldThrowErrorWhenDefendingWarriorIsStronger(int attHP, int defDmg)
        {
            Warrior warriorA = new Warrior("Pesho", 50, attHP);
            Warrior warriorD = new Warrior("Gosho", defDmg, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorA.Attack(warriorD);
            }, "You are trying to attack too strong enemy");

        }


        [TestCase(70, 50)]
        [TestCase(60, 55)]
        [TestCase(60, 60)]
        public void SuccessAttackShouldDecreaseAttackerHP(int attHP, int defDmg)
        {
            //Arrange
            Warrior warriorA = new Warrior("Pesho", 50, attHP);
            Warrior warriorD = new Warrior("Gosho", defDmg, 55);

            //Act
            warriorA.Attack(warriorD);

            int actualHp = warriorA.HP;
            int expectedHp = attHP - defDmg;

            Assert.AreEqual(expectedHp, actualHp, "Successfull attack should decrease the attacker HP!");
        }


        [TestCase(70, 40)]
        [TestCase(60, 55)]
        [TestCase(60, 59)]
        public void SuccessAttackShouldKillEnemyIfMyDmgIsOverTheirHP(int attDmg, int defHP)
        {
            //Arrange
            Warrior warriorA = new Warrior("Pesho", attDmg, 100);
            Warrior warriorD = new Warrior("Gosho", 40, defHP);

            //Act
            warriorA.Attack(warriorD);

            //Assert
            int expectedDefenderHp = 0;
            int actualDefenderHp = warriorD.HP;

            Assert.AreEqual(expectedDefenderHp, actualDefenderHp, "asdTODOmurzime");
        }


        [TestCase(50, 100)]
        [TestCase(50, 60)]
        [TestCase(50, 51)]
        [TestCase(50, 50)]
        public void SuccessAttackShouldDecreaseEnemyHPIfWeDoNotKillThem(int attDmg, int defHP)
        {
            //Arrange
            Warrior warriorA = new Warrior("Pesho", attDmg, 100);
            Warrior warriorD = new Warrior("Gosho", 30, defHP);

            //Act
            warriorA.Attack(warriorD);

            //Assert
            int expectedDefenderHp = defHP - attDmg;
            int actualDefenderHp = warriorD.HP;

            Assert.AreEqual(expectedDefenderHp, actualDefenderHp, "losho, kiselov, losho");
        }



    }
}