using System;
using System.Numerics;

namespace Problem05BitArray
{
    class BitArray
    {
        public const int MIN_COUNT = 1;
        public const int MAX_COUNT = 100000;
        private byte[] bits;

        public BitArray(int count)
        {
            if (count < MIN_COUNT || count > MAX_COUNT)
            {
                throw new ArgumentException("The count of bits must be in range [1...100000]!");
            }

            this.bits = new byte[count];
        }

        public byte this[int index]
        {
            get { return this.bits[index]; }
            set
            {
                if (index < 0 || index > this.bits.Length - 1)
                {
                    throw new IndexOutOfRangeException("The count of bits must be in range [0..." + (this.bits.Length - 1) + "]!");
                }
                if (value != 0 && value != 1)
                {
                    throw new ArgumentException("The bit must be 0 or 1!");
                }
                this.bits[index] = value;
            }
        }

        public override string ToString()
        {
            BigInteger number = 0;

            for (int i = 0; i < this.bits.Length; i++)
            {
                if (this.bits[i] == 1)
                {
                    number += BigInteger.Pow(2, i);
                }
            }

            return number.ToString();
        }
    }
}