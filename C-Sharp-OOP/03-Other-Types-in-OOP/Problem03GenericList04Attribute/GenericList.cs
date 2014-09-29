using System;
using System.Collections.Generic;
using System.Linq;


namespace Problem03GenericList04Attribute
{
    [VersionAttribute(1.00)]
    [VersionAttribute(1.75)]
    [VersionAttribute(2.55)]
    public class GenericList<T> where T : IComparable<T>
    {
        private const int CAPACITY = 16;

        private T[] array;
        private int usedIndex;
    
        public GenericList()
            : this(CAPACITY)
        {
        }
        
        public GenericList(int capacity)
        {
            this.array = new T[capacity];
            this.usedIndex = 0;
        }

        public T[] Arrays
        {
            get { return this.array; }
        }

        public int Count
        {
            get { return this.array.Length; }
        }

        public void Adding(T element)
        {
            if (this.usedIndex == this.array.Length)
            {
                AutoGrowFunction();
            }
            this.array[this.usedIndex] = element;
            this.usedIndex++;
        }

        public T Accessing(int index)
        {
            if (index < 0 || index >= this.usedIndex)
            {
                throw new ArgumentOutOfRangeException("You entered an invalid index: " + index + " Index must be in range [0..." + (this.usedIndex - 1) + "]!");
            }
            T element = this.array[index];
            return element;
        }

        public void Removing(int index)
        {
            if (index < 0 || index > this.usedIndex)
            {
                throw new ArgumentOutOfRangeException("You entered a invalid index: " + index);
            }
           
            for (int i = index; i < this.usedIndex - 1; i++)
            {
                this.array[i] = this.array[i + 1];   
            }
            this.array[this.usedIndex - 1] = default(T);
            this.usedIndex--;
        }

        public void Inserting(T newElement, int index)
        {
            if (index < 0 || index >= this.usedIndex)
            {
                throw new ArgumentOutOfRangeException("You entered an invalid index: " + index + "!Index must be in range [0..." + (this.usedIndex - 1) + "]!");
            }

            if (this.usedIndex == this.array.Length)
            {
                AutoGrowFunction();
            }

            T oldElement = this.array[index];
            this.array[index] = newElement;
            this.usedIndex++;
            for (int i = index + 1; i < this.usedIndex; i++)
            {
                T currentElement = this.array[i];
                this.array[i] = oldElement;
                oldElement = currentElement;
            }
        }

        public void Clearing()
        {
            this.array = new T[this.array.Length];
            this.usedIndex = 0;
        }

        public int Finding(T element)
        {
            int index = -1;
            for (int i = 0; i < this.usedIndex; i++)
            {
                if (this.array[i].Equals(element))
                {
                    index = i;
                }
            }
            return index;
        }

        public bool Contains(T element)
        {
            bool isContains = false;
            for (int i = 0; i < this.usedIndex; i++)
            {
                if (this.array[i].Equals(element))
                {
                    isContains = true;
                }   
            }
            return isContains;
        }

        public void Printing()
        {
            string result = "";
            for (int i = 0; i < this.usedIndex - 1; i++)
            {
                result += this.array[i] + ", ";
            }
            result += this.array[this.usedIndex - 1];
            Console.WriteLine(result.ToString());
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < this.usedIndex - 1; i++)
            {
                 result += this.array[i] + ", ";
            }
            result += this.array[this.usedIndex - 1];
            return result.ToString();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.array.Length)
                {
                    throw new IndexOutOfRangeException("Invalid index: " + index);
                }
                T result = this.array[index];
                return result;
            }
        }

        private void AutoGrowFunction()
        {
            int newCapacity = this.array.Length * 2;
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < this.array.Length; i++)
            {
                newArray[i] = this.array[i];
            }

            this.array = newArray;
        }

        public T Min<K>()
        {
            return this.array.Min();
        }

        public T Max<K>()
        {
            return this.array.Max();            
        }
    }
}

//public static K Min<K>(GenericList<K> array) where K : IComparable<K>
//{
//    K minElement = array[0];
//    for (int index = 0; index < array.Count; index++)
//    {
//        if (array[index].CompareTo(minElement) < 0)
//        {
//            minElement = array[index];
//        }
//    }

//    if (minElement.Equals(default(K)))
//    {
//        throw new Exception("Cannot find maximal element in empty array.");
//    }
//    else
//    {
//        return minElement;
//    }
//}