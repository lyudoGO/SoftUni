using System;

namespace Problem03Animals
{
    public class Frog : Animal
    {
        public Frog(string name, int age, Gender gender) 
            : base(name, age, gender)
        {

        }

        public override void Move()
        {
            Console.WriteLine("\nThe frog {0} can jump and swim.", this.Name);
        } 
        public void ProduceSound()
        {
            Console.WriteLine("\nThe frog {0} says Kwa, Kwa...", this.Name); ;
        }
    }
}