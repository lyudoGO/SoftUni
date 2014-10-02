using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem03Animals
{
    class Problem03
    {
        static void Main(string[] args)
        {
            Dog sharo = new Dog("Sharo", 5, Gender.male);
            Dog rijka = new Dog("Rijka", 3, Gender.female);

            Frog jabcho = new Frog("Jabcho", 1, Gender.male);
            Frog jabokriak = new Frog("Jabokriak", 2, Gender.female);

            Kitten katy = new Kitten("Katy", 2);
            Kitten sisi = new Kitten("Sisi", 1);
            Cat mecho = new Cat("Mecho", 7, Gender.male);
            Animal gogo = new Tomcat("Gogo", 4);
            Tomcat acho = new Tomcat("Acho", 1);

            List<Animal> animals = new List<Animal>()
                {  
                    sharo,
                    rijka,
                    jabcho,
                    jabokriak,
                    katy,
                    sisi,
                    mecho,
                    gogo,
                    acho,
                };

            var animalsKind =
                from animal in animals
                group animal by animal.GetType().Name into gr
                select new { GroupName = gr.Key, AverageAge = gr.ToList().Average(animal => animal.Age) };

            foreach (var item in animalsKind)
            {
                Console.WriteLine("Kind name: {0, -7} Average age: {1}", item.GroupName, item.AverageAge);
            }

            sharo.ProduceSound(); sharo.Move();
            jabcho.ProduceSound(); jabcho.Move();
            mecho.ProduceSound(); mecho.Move();
            sisi.ProduceSound(); sisi.Move();
            acho.ProduceSound(); acho.Move();
        }
    }
}