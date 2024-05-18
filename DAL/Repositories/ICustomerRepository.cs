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
    public interface ICustomerRepository : IRepo<Customer, int, bool>
    {
        Customer GetCustomerByEmail(string email);
        void AddCustomer(Customer customer);
    }
}
