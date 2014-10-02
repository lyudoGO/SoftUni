using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age) 
            : base(name, age, Gender.male )
        {

        }

        public override void Move()
        {
            Console.WriteLine("\nThe tomcat {0} can run and jump slowly.", this.Name);
        }

        public void ProduceSound()
        {
            Console.WriteLine("\nThe tomcat {0} says Bau, Bau, Bau...", this.Name);
        }
    }
}