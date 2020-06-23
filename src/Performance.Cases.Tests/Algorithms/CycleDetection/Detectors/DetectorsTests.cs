using NUnit.Framework;
using Performance.Cases.Algorithms.CycleDetection.Detectors;
using System;

namespace Performance.Cases.Tests.Algorithms.CycleDetection.Detectors
{
    [TestFixture]
    public class DetectorsTests
    {
        private int[] onlyOneDuplicateNumber;

        [OneTimeSetUp]
        public void Before_All_Tests()
        {
            this.onlyOneDuplicateNumber = new int[5]
                {
                   1,2,3,4,3
                };
        }

        [TestCase(typeof(BubbleSortAndLinearSeek))]
        [TestCase(typeof(LinqOrderByAndLinearSeek))]
        [TestCase(typeof(HashSetSeek))]
        [TestCase(typeof(TortoiseAndHareSeek))]
        [TestCase(typeof(LinqSeek))]
        public void Finds_Repeated_Number(Type detectorType)
        {
            ICycleDetector target = Activator.CreateInstance(detectorType) as ICycleDetector;

            int actual = target.Detect(this.onlyOneDuplicateNumber);

            Assert.AreEqual(3, actual);
        }
    }
}
