using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Models;
using DAL.Interfaces;
namespace DAL.Repositories
{
    public class CustomerRepository : IRepo<Customer, int, bool>, ICustomerRepository
    {
        private readonly PharmacyContext _context;

        public CustomerRepository()
        {
            _context = new PharmacyContext();
        }

        public bool Create(Customer entity)
        {
            _context.Customers.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public Customer Read(int id)
        {
            return _context.Customers.SingleOrDefault(c => c.CustomerId == id);
        }

        public IEnumerable<Customer> ReadAll()
        {
            return _context.Customers.ToList();
        }

        public bool Update(Customer entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _context.Customers.SingleOrDefault(c => c.Email == email);
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
}