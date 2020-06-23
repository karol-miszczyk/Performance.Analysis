namespace Performance.Cases.Algorithms.CycleDetection.Detectors
{
    public class BubbleSortAndLinearSeek : ICycleDetector
    {
        public int Detect(int[] array)
        {
            int temp;

            for (int p = 0; p <= array.Length - 2; p++)
            {
                for (int i = 0; i <= array.Length - 2; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                    }
                }
            }

            for (int i = 0; i < array.Length - 2; i++)
            {
                if (array[i] == array[i + 1])
                    return array[i];
            }

            return -1;
        }
    }
}
