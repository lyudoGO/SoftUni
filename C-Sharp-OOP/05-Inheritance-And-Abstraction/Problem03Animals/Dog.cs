using System;

namespace Problem03Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, Gender gender) 
            : base(name, age, gender)
        {

        }

        public override void Move()
        {
            Console.WriteLine("\nThe dog {0} can bite and run.", this.Name);
        }

        public void ProduceSound()
        {
            Console.WriteLine("\nThe dog {0} says Bau, Bau...", this.Name);
        }
    }
}