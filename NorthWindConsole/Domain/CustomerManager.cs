using NorthWindConsole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindConsole.Domain
{
    /// <summary>
    /// customer-related operations
    /// </summary>
    public class CustomerManager
    {
        private NORTHWNDEntities _dbContext;

        public CustomerManager()
        {
            //initialization codes
            _dbContext = new NORTHWNDEntities();
        }

        public List<Customer> GetCustomers()
        {
            var data = _dbContext.Customers.ToList();
            return data;
        }

        public Customer GetCustomerById(string id)
        {
            var data = _dbContext.Customers.FirstOrDefault(p => p.CustomerID == id);
            return data;
        }

        public string AddCustomer(Customer customer)
        {
            var newcustomer =_dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            if (newcustomer != null)
                return customer.CustomerID;
            else
                return null;
        }

        public bool UpdateCustomer(Customer customer)
        {
            _dbContext.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            int result = _dbContext.SaveChanges();
            if (result > 0)
                return true;
            else
                return false;
            
        }

        public List<Customer> SearchCustomersById(string id)
        {
            var customers = _dbContext.Customers.Where(p => p.CustomerID.Contains(id));
            if (customers != null)
                return customers.ToList();
            else
                return null;
        }
    }
}
