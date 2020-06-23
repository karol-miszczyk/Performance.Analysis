using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace Performance.Cases.Collections.List
{
    [CoreJob, ClrJob, MemoryDiagnoser]
    public class ListIteratingComparison
    {
        private readonly List<string> list;

        public ListIteratingComparison()
        {
            this.list = new List<string>(CommonConsts.DEFAULT_SIZE);

            for (int i = 0; i < CommonConsts.DEFAULT_SIZE; i++)
            {
                list.Add(CommonConsts.TEXT);
            }
        }

        [Benchmark]
        public void ListWithForeachLoop()
        {
            foreach(var element in list)
            {
                string temporary = element;
            }
        }

        [Benchmark]
        public void ListWithForLoop()
        {
            for(int i = 0; i < list.Count; i++)
            {
                string temporary = list[i];
            }
        }

        [Benchmark]
        public void ListWithWhileLoop()
        {
            int i = 0;

            while(i < list.Count)
            {
                string temporary = list[i];
                i++;
            }
        }

        [Benchmark]
        public void ListWithDoWhileLoop()
        {
            int i = 0;

            do
            {
                string temporary = list[i];
                i++;
            }
            while (i < list.Count);
        }

        [Benchmark]
        public void ListWithLinqForeach()
        {
            list.ForEach(element => { var temporeary = element; });
        }

        [Benchmark]
        public void ListWithWhileOnEnumerator()
        {
            var listEnumerator = this.list.GetEnumerator();

            while(listEnumerator.MoveNext())
            {
                string temporary = listEnumerator.Current;
            }
        }

        [Benchmark]
        public void ListWithDoWhileOnEnumerator()
        {
            var listEnumerator = this.list.GetEnumerator();

            listEnumerator.MoveNext();

            do
            {
                string temporary = listEnumerator.Current;
            }
            while (listEnumerator.MoveNext());
        }
    }
}
