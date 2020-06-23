using System.Linq;

namespace Performance.Cases.Algorithms.CycleDetection.Detectors
{
    public class LinqOrderByAndLinearSeek : ICycleDetector
    {
        public int Detect(int[] array)
        {
            var ordered = array.OrderBy(i => i).ToArray();

            for (int i = 0; i < ordered.Length - 2; i++)
            {
                if (array[i] == array[i + 1])
                    return array[i];
            }

            return -1;
        }
    }
}
