using Performance.Cases.XMLParsing.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Performance.Cases.XMLParsing.Readers
{
    public class XmlReaderFromStream : IReader
    {
        public List<Book> Read(MemoryStream stream)
        {
            using (var xmlReader = XmlReader.Create(stream))
            {
                var books = new List<Book>();

                while (xmlReader.Read())
                {
                    if (xmlReader.Name == "book" && xmlReader.NodeType == XmlNodeType.Element)
                    {
                        var book = new Book();

                        while (xmlReader.Read())
                        {
                            if (xmlReader.Name == "book" && xmlReader.NodeType == XmlNodeType.EndElement)
                            {
                                books.Add(book);
                                break;
                            }

                            switch (xmlReader.Name)
                            {
                                case "author": book.Author = xmlReader.ReadString(); break;
                                case "price": book.Price = xmlReader.ReadString(); break;
                                case "title": book.Title = xmlReader.ReadString(); break;
                            }
                        }
                    }
                }

                return books;
            }
        }
    }
}
