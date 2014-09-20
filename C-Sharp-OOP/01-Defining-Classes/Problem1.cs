using System;

class Persons
{
    private string name;
    private int age;
    private string email;

    public Persons(string name, int age, string email)
    {
        this.Name = name;
        this.Age = age;
        this.Email = email;
    }

    public Persons(string name, int age) : this(name, age, null) { }


    public string Name
    {
        get { return this.name; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty!");
            }
            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 1 || value > 100)
            {
                throw new ArgumentException("Invalid age! It should be in the range [1...100].");
            }
            this.age = value;
        }
    }

    public string Email
    {
        get { return this.email; }
        set
        {
            if (value != null && !value.Contains("@"))
            {
                throw new ArgumentException("Email must be null or contains symbol @ !");
            }
            this.email = value;
        }
    }

    public override string ToString()
    {
        if(String.IsNullOrEmpty(this.Email))
        {
            return string.Format("Person name is {0} and is {1} years old.\n", this.Name, this.Age);
        }
        else
        {
            return string.Format("Person name is {0}.He is {1} years old.Email is {2}.\n", this.Name, this.Age, this.Email);
        }

    }
}

class Problem1
{
    static void Main(string[] args)
    {
        Persons per1 = new Persons("Gosho", 20, "gosho@abv.bg");
        Persons per2 = new Persons("Kiro", 22);
        Console.WriteLine(per1);
        Console.WriteLine(per2);

        //throw exception error - invalid age
        //Persons per3 = new Persons("Petya", 101);
        //Console.WriteLine(per3);

        //throw exception error - invalid email
        //Persons per4 = new Persons("Vania", 21, "vaniaemail.bg");
        //Console.WriteLine(per4);
    }
}