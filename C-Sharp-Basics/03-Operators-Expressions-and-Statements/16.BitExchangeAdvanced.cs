using System;


class BitExchangeAdvanced
{
    static void Main(string[] args)
    {
        unchecked
        {
            uint number;
            string str = (Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int q = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            if (!(uint.TryParse(str, out number)))
            {
                Console.WriteLine("out of range");
                Environment.Exit(0);
            }

            int[] pBitsArray = new int[k];
            int[] qBitsArray = new int[k];


            for (int position = p, i = 0; i < pBitsArray.Length; position++, i++)
            {
                pBitsArray[i] = (int)((number >> position) & 1);
            }

            for (int position = q, i = 0; i < qBitsArray.Length; position++, i++)
            {
                qBitsArray[i] = (int)((number >> position) & 1);
            }

            for (int position = p, i = 0; i < qBitsArray.Length; position++, i++)
            {
                uint actualPosition = (uint)(qBitsArray[i] << position);
                number = number & (~((uint)1 << position));
                number = number | actualPosition;
            }

            for (int position = q, i = 0; i < pBitsArray.Length; position++, i++)
            {
                uint actualPosition = (uint)(pBitsArray[i] << position);
                number = number & (~((uint)1 << position));
                number = number | actualPosition;
            }

            
                            
            if ((p + q) <= k)
            {
                Console.WriteLine("overlapping");
            }
            else if (p + k > 31 || q + k > 31)
                  {
                     Console.WriteLine("out of range");
                  }
                  else Console.WriteLine(number);
            
        }


    }     
}
