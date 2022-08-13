using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository _heroRepository;

    [SetUp]
    public void SetUp()
    {
        this._heroRepository = new HeroRepository();
    }

    [Test]
    public void TestCreate()
    {
        Assert.AreEqual(0, this._heroRepository.Heroes.Count);

        this._heroRepository.Create(new Hero("Ivan", 10));

        Assert.AreEqual(1, this._heroRepository.Heroes.Count);
        Assert.Throws<ArgumentNullException>(() => this._heroRepository.Create(null));
        Assert.Throws<InvalidOperationException>(() => this._heroRepository.Create(new Hero("Ivan", 10)));
    }

    [Test]
    public void TestRemove()
    {
        Assert.Throws<ArgumentNullException>(() => this._heroRepository.Remove(null));
        Assert.Throws<ArgumentNullException>(() => this._heroRepository.Remove(" "));

        this._heroRepository.Create(new Hero("Ivan", 10));

        Assert.IsFalse(this._heroRepository.Remove("Pesho"));
        Assert.IsTrue(this._heroRepository.Remove("Ivan"));
    }

    [Test]
    public void TestGetHeroWithHighestLevel()
    {
        Hero hero1 = new Hero("Name1", 1);
        Hero hero2 = new Hero("Name2", 2);
        Hero hero3 = new Hero("Name3", 3);
        Hero hero4 = new Hero("Name4", 4);

        this._heroRepository.Create(hero1);
        this._heroRepository.Create(hero2);
        this._heroRepository.Create(hero3);
        this._heroRepository.Create(hero4);

        Assert.AreEqual(hero4, this._heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void TestGetHero()
    {
        Hero hero1 = new Hero("Name1", 1);
        Hero hero2 = new Hero("Name2", 2);

        this._heroRepository.Create(hero1);
        this._heroRepository.Create(hero2);

        Assert.AreEqual(hero1, this._heroRepository.GetHero("Name1"));
    }



}