using System;
using NUnit.Framework;


public class HeroRepositoryTests
{
    private HeroRepository hr;
    private Hero hero;

    [SetUp]
    public void SetUp()
    {
        this.hr = new HeroRepository();
        this.hero = new Hero("a", 1);
    }


    [Test]
    public void ConstructorCorrectReturn()
    {
        Assert.IsNotNull(hr);
        Assert.AreEqual(0, hr.Heroes.Count);
    }

    [Test]
    public void CreateHeroCorrectReturn()
    {
        Assert.AreEqual(this.hr.Create(hero), "Successfully added hero a with level 1");
    }

    [Test]
    public void CreateHeroNullExc()
    {
        Assert.Throws<ArgumentNullException>(() => this.hr.Create(null));
    }

    [Test]
    public void CreateHeroIOExc()
    {
        this.hr.Create(hero);
        Assert.Throws<InvalidOperationException>( () => this.hr.Create(hero));
    }

    [Test]
    public void RemoveHeroCorrectReturn()
    {
        this.hr.Create(hero);
        Assert.AreEqual(true, this.hr.Remove(hero.Name));
    }

    [Test]
    public void RemoveNullExc()
    {
        this.hr.Create(hero);
        Assert.Throws<ArgumentNullException>( () => this.hr.Remove(null)); 
    }

    [Test]
    public void HighestLevelCorrectReturn()
    {
        this.hr.Create(hero);
        Hero heroLevel5 = new Hero("Petar", 5);
        Hero heroLevel10 = new Hero("Semko", 10);

        this.hr.Create(heroLevel5);
        this.hr.Create(heroLevel10);

        Assert.AreEqual(heroLevel10, this.hr.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHeroCorrectReturn()
    {
        this.hr.Create(hero);

        Assert.AreEqual(hero, this.hr.GetHero("a"));
    }






}