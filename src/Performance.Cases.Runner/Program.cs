using BenchmarkDotNet.Running;
using Performance.Cases.String.Substring;
using Performance.Cases.XMLParsing;

namespace Performance.Cases.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run<CycleDetectorsBenchmark>();
            //var summary = BenchmarkRunner.Run<XmlLoad>();

            
            //var summary = BenchmarkRunner.Run<ListIteratingComparison>();

            //summary = BenchmarkRunner.Run<DictionaryIteratingComparison>();
            var summary = BenchmarkRunner.Run<RegularSubstring>();
            //summary = BenchmarkRunner.Run<Slice>();
            //summary = BenchmarkRunner.Run<XmlLoad>();
        }
    }
}
