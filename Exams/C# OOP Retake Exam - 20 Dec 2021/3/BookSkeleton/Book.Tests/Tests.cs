namespace Book.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConstructorCorrectReturn()
        {
            Book book = new Book("someBookName", "me");

            Assert.IsNotNull(book);
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [Test]
        public void BookNameArgException()
        {
            Assert.Throws<ArgumentException>(() => new Book("", "a"));
            Assert.Throws<ArgumentException>(() => new Book(null, "a"));
        }

        [Test]
        public void AuthorArgException()
        {
            Assert.Throws<ArgumentException>(() => new Book("a", ""));
            Assert.Throws<ArgumentException>(() => new Book("a", null));
        }

        [Test]
        public void AddFootnoteIOException()
        {
            Book book = new Book("asd", "qwe");

            book.AddFootnote(123, "test");
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(123, "test"));
        }

        [Test]
        public void AddFootnoteCorrectReturn()
        {
            Book book = new Book("asd", "qwe");

            book.AddFootnote(123, "test");
            Assert.AreEqual(1, book.FootnoteCount);
        }

        [Test]
        public void FindFootnoteIOException()
        {
            Book book = new Book("asd", "qwe");
            book.AddFootnote(123, "test");

            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(456));
        }

        [Test]
        public void FindFootnoteCorrectReturn()
        {
            Book book = new Book("asd", "qwe");
            book.AddFootnote(123, "test");

            Assert.AreEqual(book.FindFootnote(123) , $"Footnote #{123}: {"test"}");
        }

        [Test]
        public void AlterFootnoteIOException()
        {
            Book book = new Book("asd", "qwe");
            book.AddFootnote(123, "qwe");

            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(456, "whatever"));
        }

        [Test]
        public void AlterFootnoteCorrectReturn()
        {
            Book book = new Book("asd", "qwe");
            book.AddFootnote(123, "qwe");
            book.AlterFootnote(123, "newMessage");

            Assert.AreEqual($"Footnote #{123}: {"newMessage"}", book.FindFootnote(123));
        }



    }
}