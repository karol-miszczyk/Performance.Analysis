using System.Linq;

namespace Performance.Cases.Algorithms.CycleDetection.Detectors
{
    public class LinqSeek : ICycleDetector
    {
        public int Detect(int[] array)
        {
            return array
                .GroupBy(x => x)
                .SelectMany(x => x.Skip(1))
                .First();
        }
    }
}
