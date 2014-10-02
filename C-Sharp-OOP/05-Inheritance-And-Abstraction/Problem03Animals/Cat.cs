using System;

namespace Problem03Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, Gender gender) 
            : base(name, age, gender)
        {

        }

        public override void Move()
        {
            Console.WriteLine("\nThe cat {0} can run and jump fast.", this.Name);
        }

        public void ProduceSound()
        {
            Console.WriteLine("\nThe cat {0} says Myau...", this.Name); ;
        }
    }
}