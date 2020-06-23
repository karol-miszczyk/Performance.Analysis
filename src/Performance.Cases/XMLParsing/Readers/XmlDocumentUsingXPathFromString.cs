using Performance.Cases.XMLParsing.DTO;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Performance.Cases.XMLParsing.Readers
{
    public class XmlDocumentUsingXPathFromString : IReader
    {
        public List<Book> Read(MemoryStream stream)
        {
            var xmlDoc = new XmlDocument();

            xmlDoc.LoadXml(Encoding.UTF8.GetString(stream.ToArray()).Substring(1));

            var books = new List<Book>();

            var nodes = xmlDoc.DocumentElement.SelectNodes("/catalog/book");

            foreach (XmlNode xmlNode in nodes)
            {
                books.Add(new Book
                {
                    Author = xmlNode.SelectSingleNode("author").InnerText,
                    Price = xmlNode.SelectSingleNode("price").InnerText,
                    Title = xmlNode.SelectSingleNode("title").InnerText,
                });
            }

            return books;
        }
    }
}
