using System.Collections.Generic;

namespace Performance.Cases.Algorithms.CycleDetection.Detectors
{
    public class HashSetSeek : ICycleDetector
    {
        public int Detect(int[] array)
        {
            var unique = new HashSet<int>();

            for (int i = 0; i < array.Length - 1; i++)
            {
                var element = array[i];

                if(!unique.Add(element))
                {
                    return element;
                }
            }

            return -1;
        }
    }
}
