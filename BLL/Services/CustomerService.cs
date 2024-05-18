using System;
using BLL.DTOs;
using DAL;
using DAL.Models;
using DAL.Repositories;

namespace BLL.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = DataAccessFactory.CustomerData(); // Use factory for dependency injection
        }

        public void RegisterCustomer(CustomerDTO customerDto)
        {
            var customer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                PhoneNumber = customerDto.PhoneNumber,
                Address = customerDto.Address,
                Password = customerDto.Password // In a real app, hash the password
            };

            _customerRepository.AddCustomer(customer);
        }

        public CustomerDTO Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Email and password must be provided.");
            }

            var customer = _customerRepository.GetCustomerByEmail(email);

            if (customer == null)
            {
                throw new Exception("Customer not found.");
            }

            if (customer.Password != password) // In a real app, verify hashed password
            {
                throw new Exception("Invalid password.");
            }

            return new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address
            };
        }
    }
}
