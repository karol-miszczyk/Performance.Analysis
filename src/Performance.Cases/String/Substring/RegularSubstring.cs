using BenchmarkDotNet.Attributes;

namespace Performance.Cases.String.Substring
{
    [CoreJob, ClrJob]
    public class RegularSubstring
    {
        [Benchmark]
        public void FullLengthWithoutSecondParameter()
        {
            var result = CommonConsts.TEXT.Substring(0);
        }

        [Benchmark]
        public void FullLengthWithSecondParameter()
        {
            var result = CommonConsts.TEXT.Substring(0, CommonConsts.BASE_LENGHT);
        }

        [Benchmark]
        public void OneOperation()
        {
            var result = CommonConsts.TEXT.Substring(10, 15);
        }

        [Benchmark]
        public void TwoOperations()
        {
            var result = CommonConsts.TEXT.Substring(11, 5).Substring(1, 3);
        }

        [Benchmark]
        public void ThreeOperations()
        {
            var result = CommonConsts.TEXT.Substring(1, 15).Substring(3, 7).Substring(1, 2);
        }
    }
}
