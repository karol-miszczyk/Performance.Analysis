using Performance.Cases.XMLParsing.DTO;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Performance.Cases.XMLParsing.Readers
{
    public class XDocumentUsingXPathFromString : IReader
    {
        public List<Book> Read(MemoryStream stream)
        {
            XDocument doc;

            using (var streamReader = new StringReader(Encoding.UTF8.GetString(stream.ToArray()).Substring(1)))
            {
                using (var textReader = new XmlTextReader(streamReader))
                {
                    doc = XDocument.Load(textReader);
                }
            }

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
