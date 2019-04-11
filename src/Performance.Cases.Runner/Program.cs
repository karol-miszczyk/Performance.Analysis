using BenchmarkDotNet.Running;
using Performance.Cases.Collections.Dictionary;
using Performance.Cases.Collections.List;

namespace Performance.Cases.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ListIteratingComparison>();
            summary = BenchmarkRunner.Run<DictionaryIteratingComparison>();

        }
    }
}
