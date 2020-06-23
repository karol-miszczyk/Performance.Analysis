using Performance.Cases.XMLParsing.DTO;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace Performance.Cases.XMLParsing.Readers
{
    public class XDocumentUsingXPathFromStream : IReader
    {
        public List<Book> Read(MemoryStream stream)
        {
            var doc = XDocument.Load(stream);

            var books = new List<Book>();

            IEnumerable<XElement> xElements = doc.Root.Descendants("book");

            foreach (XElement xElement in xElements)
            {
                books.Add(new Book
                {
                    Author = xElement.Element("author").Value,
                    Price = xElement.Element("price").Value,
                    Title = xElement.Element("title").Value,
                });
            }

            return books;
        }
    }
}
