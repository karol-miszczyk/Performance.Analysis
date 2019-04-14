using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Performance.Cases.String.Substring
{
    [CoreJob, ClrJob]
    public class Slice
    {
        private readonly ReadOnlyMemory<char> memory;

        public Slice()
        {
            this.memory = CommonConsts.TEXT.AsMemory();
        }

        [Benchmark]
        public void WithPreCastFullLengthWithoutSecondParameter()
        {
            var result = this.memory.Slice(0);
        }

        [Benchmark]
        public void WithoutPreCastFullLengthWithoutSecondParameter()
        {
            var result = CommonConsts.TEXT.AsSpan().Slice(0);
        }

        [Benchmark]
        public void WithPreCastFullLengthWithSecondParameter()
        {
            var result = this.memory.Slice(0, CommonConsts.BASE_LENGHT);
        }

        [Benchmark]
        public void WithoutPreCastFullLengthWithSecondParameter()
        {
            var result = CommonConsts.TEXT.AsSpan().Slice(0, CommonConsts.BASE_LENGHT);
        }

        [Benchmark]
        public void WithPreCastOneOperation()
        {
            var result = this.memory.Slice(10, 15);
        }

        [Benchmark]
        public void WithoutPreCastOneOperation()
        {
            var result = CommonConsts.TEXT.AsSpan().Slice(10, 15);
        }

        [Benchmark]
        public void WithPreCastTwoOperations()
        {
            var result = this.memory.Slice(11, 5).Slice(1, 3);
        }

        [Benchmark]
        public void WithoutPreCastTwoOperations()
        {
            var result = CommonConsts.TEXT.AsSpan().Slice(11, 5).Slice(1, 3);
        }

        [Benchmark]
        public void WithPreCastThreeOperations()
        {
            var result = this.memory.Slice(1, 15).Slice(3, 7).Slice(1, 2);
        }

        [Benchmark]
        public void WithoutPreCastThreeOperations()
        {
            var result = CommonConsts.TEXT.AsSpan().Slice(1, 15).Slice(3, 7).Slice(1, 2);
        }
    }
}
