using System;

namespace Problem03Animals
{
    public enum Gender
    {
        female,
        male,
    }

    public abstract class Animal : ISound
    {
        private string name;
        private int age;
        private Gender gender;

        public Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name 
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age 
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public Gender Gender 
        {
            get { return this.gender; }
            set { this.gender = value; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.name, this.age, this.gender);
        }

        public virtual void Move()
        {
            Console.WriteLine("\nAnimals have difrent moves.");
        }

        public void ProduceSound()
        {
          
        }
    }
}