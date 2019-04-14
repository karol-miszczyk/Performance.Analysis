using BenchmarkDotNet.Running;
using Performance.Cases.Collections.Dictionary;
using Performance.Cases.Collections.List;
using Performance.Cases.String.Substring;

namespace Performance.Cases.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ListIteratingComparison>();
            summary = BenchmarkRunner.Run<DictionaryIteratingComparison>();
            summary = BenchmarkRunner.Run<RegularSubstring>();
            summary = BenchmarkRunner.Run<Slice>();
        }
    }
}
