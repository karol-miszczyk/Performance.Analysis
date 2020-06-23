namespace Performance.Cases.Algorithms.CycleDetection.Detectors
{
    public class TortoiseAndHareSeek : ICycleDetector
    {
        public int Detect(int[] array)
        {
            int tortoise = array[0];
            int hare = array[0];

            while(true)
            {
                tortoise = array[tortoise];
                hare = array[array[hare]];

                if (tortoise == hare)
                    break;
            }

            int ptr1 = array[0];
            int ptr2 = tortoise;

            while(ptr1!=ptr2)
            {
                ptr1 = array[ptr1];
                ptr2 = array[ptr2];
            }

            return ptr1;
        }
    }
}
