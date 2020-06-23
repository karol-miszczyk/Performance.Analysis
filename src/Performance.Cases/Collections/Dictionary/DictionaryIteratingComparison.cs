using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace Performance.Cases.Collections.Dictionary
{
    [CoreJob, ClrJob, MemoryDiagnoser]
    public class DictionaryIteratingComparison
    {
        private readonly Dictionary<int, string> dictionary;

        public DictionaryIteratingComparison()
        {
            this.dictionary = new Dictionary<int, string>(CommonConsts.DEFAULT_SIZE);

            for (int i = 0; i < CommonConsts.DEFAULT_SIZE; i++)
            {
                dictionary.Add(i, CommonConsts.TEXT);
            }
        }

        [Benchmark]
        public void DictionaryWithForeachLoop()
        {
            foreach(var keyValuePair in dictionary)
            {
                var temporaryKey = keyValuePair.Key;
                var temporaryValue = keyValuePair.Value;
            }
        }

        [Benchmark]
        public void DictionaryWithForEachKeyLoop()
        {
            foreach(var key in dictionary.Keys)
            {
                var temporaryKey = key;
                var temporaryValue = dictionary[key];
            }
        }

        [Benchmark]
        public void DictionaryWithWhileOnEnumerator()
        {
            var dictionaryEnumerator = dictionary.GetEnumerator();

            while(dictionaryEnumerator.MoveNext())
            {
                var temporaryKey = dictionaryEnumerator.Current.Key;
                var temporaryValue = dictionaryEnumerator.Current.Value;
            }
        }

        [Benchmark]
        public void DictionaryWithDoWhileLoopOnEnumerator()
        {
            var dictionaryEnumerator = dictionary.GetEnumerator();

            dictionaryEnumerator.MoveNext();

            do
            {
                var temporaryKey = dictionaryEnumerator.Current.Key;
                var temporaryValue = dictionaryEnumerator.Current.Value;
            }
            while (dictionaryEnumerator.MoveNext());
        }

        [Benchmark]
        public void DictionaryIterateOverKeys()
        {
            for(int i = 0; i < CommonConsts.DEFAULT_SIZE; i++)
            {
                var value = this.dictionary[i];
            }
        }
    }
}
