using BenchmarkDotNet.Attributes;
using Performance.Cases.Algorithms.CycleDetection.Detectors;

namespace Performance.Cases.Algorithms.CycleDetection
{
    [CoreJob, ClrJob, MemoryDiagnoser]
    public class CycleDetectorsBenchmark
    {
        private readonly BubbleSortAndLinearSeek bubbleSortAndLinearSeek;
        private readonly LinqOrderByAndLinearSeek linqOrderByAndLinearSeek;
        private readonly HashSetSeek hashSetSeek;
        private readonly TortoiseAndHareSeek tortoiseAndHareSeek;
        private readonly LinqSeek linqSeek;

        private int[] onlyOneDuplicateNumber;

        public CycleDetectorsBenchmark()
        {
            this.bubbleSortAndLinearSeek = new BubbleSortAndLinearSeek();
            this.linqOrderByAndLinearSeek = new LinqOrderByAndLinearSeek();
            this.linqSeek = new LinqSeek();
            this.hashSetSeek = new HashSetSeek();
            this.tortoiseAndHareSeek = new TortoiseAndHareSeek();
        }

        [IterationSetup]
        public void Before_Each_Iteration()
        {
            this.onlyOneDuplicateNumber = new int[101]
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,1,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100
            };
        }

        [Benchmark]
        public void BubbleSortAndLinearSeek()
        {
            int result = this.bubbleSortAndLinearSeek.Detect(this.onlyOneDuplicateNumber);
        }

        [Benchmark]
        public void LinqOrderByAndLinearSeek()
        {
            int result = this.linqOrderByAndLinearSeek.Detect(this.onlyOneDuplicateNumber);
        }

        [Benchmark]
        public void LinqSeek()
        {
            int result = this.linqSeek.Detect(this.onlyOneDuplicateNumber);
        }

        [Benchmark]
        public void HashSetSeek()
        {
            int result = this.hashSetSeek.Detect(this.onlyOneDuplicateNumber);
        }

        [Benchmark]
        public void TortoiseAndHareSeek()
        {
            int result = this.tortoiseAndHareSeek.Detect(this.onlyOneDuplicateNumber);
        }
    }
}
