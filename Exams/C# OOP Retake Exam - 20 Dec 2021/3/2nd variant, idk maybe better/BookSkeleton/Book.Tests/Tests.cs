using System.Numerics;

namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void TestConstructor()
        {
            Book book = new Book("Im so sorry", "Me");

            Assert.AreEqual(0, book.FootnoteCount);
            Assert.AreEqual("Im so sorry", book.BookName);
            Assert.AreEqual("Me", book.Author);
        }

        [Test]
        public void BookNameError()
        {
            Assert.Throws<ArgumentException>(() => new Book(null, "Me"));
        }

        [Test]
        public void AuthorError()
        {
            Assert.Throws<ArgumentException>(() => new Book("Im so sorry", null));
        }

        [Test]
        public void TestAddFootnote()
        {
            Book book = new Book("Im so sorry", "Me");
            book.AddFootnote(1, "Angry");
            Assert.AreEqual(1, book.FootnoteCount);

            book.AddFootnote(50, "Sad");
            book.AddFootnote(25, "Happy");
            Assert.AreEqual(3, book.FootnoteCount);

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, "Angry"));
        }

        [Test]
        public void TestFindFootnote()
        {
            Book book = new Book("Im so sorry", "Me");
            book.AddFootnote(1, "Angry");
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(25));

            Assert.AreEqual("Footnote #1: Angry", book.FindFootnote(1));
        }

        [Test]
        public void TestAlterFootnote()
        {
            Book book = new Book("Im so sorry", "Me");
            book.AddFootnote(1, "Angry");
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(25, "Its ok"));

            book.AddFootnote(123, "qwe");
            book.AlterFootnote(123, "newMessage");

            Assert.AreEqual($"Footnote #{123}: {"newMessage"}", book.FindFootnote(123));
        }


    }
}