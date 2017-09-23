using NorthWindConsole.Data;
using NorthWindConsole.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to NorthWind e-Commerce");
            Console.WriteLine("Enter 1 for Customers \nEnter 2 to search by customer id \nEnter 3 to get a customer by id \nEnter 4 for Products List");

            string input = Console.ReadLine();
            if (input != null)
            {
                input = input.Trim(); //trim
                if (input == "1")
                {
                    GetCustomers();
                }
                else if (input == "2")
                {
                    Console.WriteLine("Enter customer id you want to search by");
                    var query = Console.ReadLine();
                    GetCustomers(query);
                }
                else if (input == "3")
                {
                    Console.WriteLine("Enter customer id");
                    var id = Console.ReadLine();
                    GetCustomer(id);
                }
            }
            Console.ReadKey();
        }

        private static void GetCustomers(string id = null)
        {
            CustomerManager customerManager = new CustomerManager();
            List<Customer> customers = null;
            if (string.IsNullOrEmpty(id))
                customers = customerManager.GetCustomers();
            else
                customers = customerManager.SearchCustomersById(id);

            foreach(Customer customer in customers)
            {
                Console.WriteLine($"{customer.CustomerID} {customer.ContactName} {customer.Phone} \n");
                //Console.WriteLine("{0} {1} {2}",customer.CustomerID, customer.ContactName, customer.Phone);
            }
        }

        private static void GetCustomer(string id)
        {
            CustomerManager customerManager = new CustomerManager();
            var customer = customerManager.GetCustomerById(id);
            if (customer != null)
                Console.WriteLine($"{customer.CustomerID} {customer.ContactName} {customer.Phone} \n");
            else
                Console.WriteLine($"Cannot find customer with id {id}");
        }


    }
}
