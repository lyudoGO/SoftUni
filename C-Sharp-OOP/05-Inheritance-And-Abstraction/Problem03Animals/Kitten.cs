using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age) 
            : base(name, age, Gender.female)
        {

        }

        public override void Move()
        {
            Console.WriteLine("\nThe kitten {0} can run and jump slowly.", this.Name);
        }

        public void ProduceSound()
        {
            Console.WriteLine("\nThe kitten {0} says Myau, Myau, Myau...", this.Name);
        }
    }
}