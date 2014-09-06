using System;

class StringsAndObjects
{
    static void Main()
    {
        string strA = "Hello";
        string strB = "World";
        object obj = strA + " " + strB;
        Console.WriteLine(obj);
        string strC = (string)obj;
        Console.WriteLine(strC);
    }
}

