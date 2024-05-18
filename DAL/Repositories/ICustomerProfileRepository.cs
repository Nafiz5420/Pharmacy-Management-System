﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
namespace DAL.Repositories
{
    public interface ICustomerProfileRepository
    {
        Customer GetCustomerById(int customerId);
        void UpdateCustomer(Customer customer);
    }
}
