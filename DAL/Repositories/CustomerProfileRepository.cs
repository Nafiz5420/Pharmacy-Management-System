using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
namespace DAL.Repositories
{
    public class CustomerProfileRepository : ICustomerProfileRepository
    {
        private readonly PharmacyContext _context;

        public CustomerProfileRepository()
        {
            _context = new PharmacyContext();
        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.SingleOrDefault(c => c.CustomerId == customerId);
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
