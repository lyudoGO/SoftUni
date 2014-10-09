using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01Customer
{
    class Problem01
    {
        static void Main()
        {

            Customer gosho = new Customer("Gosho", "Goshev", "Goshev", 8011127561, "selo Obelia", "029871212",
                             "kilesha@gmail.com", new List<Payment>() { new Payment("Karburator", 15M), new Payment("Guma", 25M) });

            Customer newGosho = (Customer)gosho.Clone();
            newGosho.Id = 7011127561;

            Customer[] customers = new Customer[]
            {
                new Customer("Angel", "Angelov", "Angelov", 9001126565, "Kaspichan", "0888101010", 
                             "gele@abv.bg", new List<Payment>() {new Payment("Laptop", 700M)}),
                new Customer("Iva", "Mihova", "Mihova", 9205104545, "Plovdiv", "0888123456", 
                "ivcheto@abv.bg", new List<Payment>() {new Payment("Roklia", 50M), new Payment("Sandali", 45M), new Payment("Chervilo", 9.50M) }),
                new Customer("Anelia", "Petrova", "Petrova", 911036545, "Ruse", "0877987654", 
                             "vechnata@mail.bg", new List<Payment>() {new Payment("Kanape - kojeno", 1450M), new Payment("Masa", 250M), 
                              new Payment("Stolove", 280M), new Payment("Lampa", 35.45M), new Payment("Shkaf", 125.5M),}),
                gosho,
                newGosho
            };

            PrintList(customers);

            Array.Sort(customers);

            Console.WriteLine(new string('#', 110));
            Console.WriteLine("Print list after sort:\n");
            PrintList(customers);
        }

        public static void PrintList(Customer[] customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
                Console.WriteLine(new string('.', 110));
            }
        }
    }
}
