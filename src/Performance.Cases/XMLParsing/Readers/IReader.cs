using Performance.Cases.XMLParsing.DTO;
using System.Collections.Generic;
using System.IO;

namespace Performance.Cases.XMLParsing.Readers
{
    public interface IReader
    {
        List<Book> Read(MemoryStream stream);
    }
}
