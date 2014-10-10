
using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem02StringDisperser
{
    public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable
    {
        public StringDisperser(params string[] parameters)
        {
            this.Parameters = parameters;
        }

        public string[] Parameters { get; set; }

        public override string ToString()
        {
            return string.Join("", this.Parameters);
        }

        public override bool Equals(object obj)
        {
            StringDisperser stringDisperser = obj as StringDisperser;
            if (obj == null)
            {
                return false;
            }

            return this.ToString() == stringDisperser.ToString();
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                hashCode = hashCode.GetHashCode() ^ this.Parameters[i].GetHashCode();
            }

            return hashCode;
        }

        public static bool operator ==(StringDisperser strDisperser, StringDisperser strDisperser1)
        {
            return StringDisperser.Equals(strDisperser, strDisperser1);
        }

        public static bool operator !=(StringDisperser strDisperser, StringDisperser strDisperser1)
        {
            return !StringDisperser.Equals(strDisperser, strDisperser1);
        }

        object ICloneable.Clone()  // Implicit interface implementation
        {
            return this.Clone();
        }

        public StringDisperser Clone()
        {
            int length = this.Parameters.Length;
            string[] strings = new string[length];

            for (int i = 0; i < length; i++)
            {
                strings[i] = this.Parameters[i];
            }

            StringDisperser cloneDisperser = new StringDisperser(strings);
            return cloneDisperser;
        }

        public int CompareTo(StringDisperser other)
        {
            int result = this.ToString().CompareTo(other.ToString());
            return result;
        }

        public IEnumerator<char> GetEnumerator()
        {
            string str = this.ToString();
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                yield return ch;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
