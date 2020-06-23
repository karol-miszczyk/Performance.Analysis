using NUnit.Framework;
using Performance.Cases.XMLParsing.Readers;
using System;
using System.IO;

namespace Performance.Cases.Tests.XMLParsing.Readers
{
    [TestFixture]
    public class ReadersTests
    {
        private MemoryStream stream;

        [OneTimeSetUp]
        public void Before_Each_Test()
        {
            using (var fs = File.OpenRead("Data\\example.xml"))
            {
                stream = new MemoryStream((int)fs.Length);

                fs.CopyTo(stream);
            }
        }

        [TestCase(typeof(XmlReaderFromStream))]
        [TestCase(typeof(XDocumentUsingXPathFromStream))]
        [TestCase(typeof(XDocumentUsingXPathFromString))]
        [TestCase(typeof(XmlDocumentUsingXPathFromString))]
        public void Reads_All_Books(Type type)
        {
            var reader = Activator.CreateInstance(type) as IReader;

            stream.Seek(0, SeekOrigin.Begin);

            var books = reader.Read(this.stream);

            Assert.AreEqual(books.Count, 2);
            Assert.AreEqual(books[0].Author, "Gambardella, Matthew");
            Assert.AreEqual(books[0].Price, "44.95");
            Assert.AreEqual(books[0].Title, "XML Developer's Guide");
            Assert.AreEqual(books[1].Author, "Ralls, Kim");
            Assert.AreEqual(books[1].Price, "5.95");
            Assert.AreEqual(books[1].Title, "Midnight Rain");
        }
    }
}
