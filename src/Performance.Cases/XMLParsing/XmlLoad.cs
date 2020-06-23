using BenchmarkDotNet.Attributes;
using Performance.Cases.XMLParsing.Readers;
using System.IO;

namespace Performance.Cases.XMLParsing
{
    [CoreJob, ClrJob, MemoryDiagnoser]
    public class XmlLoad
    {
        private readonly MemoryStream xmlStream;

        private readonly XmlReaderFromStream xmlReaderFromStream;
        private readonly XDocumentUsingXPathFromStream xDocumentUsingXPathFromStream;
        private readonly XDocumentUsingXPathFromString xDocumentUsingXPathFromString;
        private readonly XmlDocumentUsingXPathFromString xmlDocumentUsingXPathFromString;


        public XmlLoad()
        {
            this.xmlReaderFromStream = new XmlReaderFromStream();
            this.xDocumentUsingXPathFromStream = new XDocumentUsingXPathFromStream();
            this.xDocumentUsingXPathFromString = new XDocumentUsingXPathFromString();
            this.xmlDocumentUsingXPathFromString = new XmlDocumentUsingXPathFromString();

            var path = "XMLParsing\\Data\\example.xml";

            using (var fs = File.OpenRead(path))
            {
                xmlStream = new MemoryStream((int)fs.Length);

                fs.CopyTo(xmlStream);
            }
        }

        [IterationSetup]
        public void Before_Each_Iteration()
        {
            this.xmlStream.Seek(0, SeekOrigin.Begin);
        }

        [Benchmark]
        public void XmlDocumentUsingXPathFromString()
        {
            var books = this.xmlDocumentUsingXPathFromString.Read(this.xmlStream);
        }

        [Benchmark]
        public void XDocumentUsingXPathFromString()
        {
            var books = this.xDocumentUsingXPathFromString.Read(this.xmlStream);
        }

        [Benchmark]
        public void XDocumentUsingXPathFromStream()
        {
            var books = this.xDocumentUsingXPathFromStream.Read(this.xmlStream);
        }

        [Benchmark]
        public void XmlReaderFromStream()
        {
            var books = this.xmlReaderFromStream.Read(this.xmlStream);
        }
    }
}
