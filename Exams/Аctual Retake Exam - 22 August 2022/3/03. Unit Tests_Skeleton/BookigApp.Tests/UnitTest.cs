using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel _hotel;

        [SetUp]
        public void Setup()
        {
            this._hotel = new Hotel("Golden", 1);
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual("Golden", this._hotel.FullName);
            Assert.AreEqual(1, this._hotel.Category);
            Assert.AreEqual(0, this._hotel.Rooms.Count);
            Assert.AreEqual(0, this._hotel.Bookings.Count);
            Assert.AreEqual(0, this._hotel.Turnover);
        }


        [Test]
        public void TestFullName()
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(null, 2));
            Assert.Throws<ArgumentNullException>(() => new Hotel(" ", 2));
        }
        [Test]
        public void TestCategory()
        {
            Assert.Throws<ArgumentException>(() => new Hotel("asd", -3));
            Assert.Throws<ArgumentException>(() => new Hotel("asd", 22));
        }

        [Test]
        public void TestAddRoom()
        {
            this._hotel.AddRoom(new Room(1, 2));
            Assert.AreEqual(1, this._hotel.Rooms.Count);
        }

        [Test]
        public void TestBookRoom()
        {
            Assert.Throws<ArgumentException>(() => this._hotel.BookRoom(-2, 1, 1, 1));
            Assert.Throws<ArgumentException>(() => this._hotel.BookRoom(5, -5, 1, 1));
            Assert.Throws<ArgumentException>(() => this._hotel.BookRoom(5, 5, -11, 1));

            Room room = new Room(10, 2);
            this._hotel.AddRoom(room);

            this._hotel.BookRoom(1, 1, 1, 50);
            Assert.AreEqual(1, this._hotel.Bookings.Count);
            Assert.AreEqual(2, this._hotel.Turnover);
        }


    }
}