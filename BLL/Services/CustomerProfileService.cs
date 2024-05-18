using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using DAL.Models;
using DAL.Repositories;
namespace BLL.Services
{
    public class CustomerProfileService
    {
        private readonly ICustomerProfileRepository _customerProfileRepository;

        public CustomerProfileService()
        {
            _customerProfileRepository = new CustomerProfileRepository();
        }

        public CustomerProfileDTO GetCustomerProfile(int customerId)
        {
            var customer = _customerProfileRepository.GetCustomerById(customerId);

            if (customer == null)
            {
                throw new Exception("Customer not found.");
            }

            return new CustomerProfileDTO
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address
            };
        }

        public void UpdateCustomerProfile(CustomerProfileDTO customerProfileDto)
        {
            var customer = _customerProfileRepository.GetCustomerById(customerProfileDto.CustomerId);

            if (customer == null)
            {
                throw new Exception("Customer not found.");
            }

            customer.Name = customerProfileDto.Name;
            customer.PhoneNumber = customerProfileDto.PhoneNumber;
            customer.Address = customerProfileDto.Address;

            _customerProfileRepository.UpdateCustomer(customer);
        }

        public void ChangeCustomerPassword(ChangePasswordDTO changePasswordDto)
        {
            var customer = _customerProfileRepository.GetCustomerById(changePasswordDto.CustomerId);

            if (customer == null)
            {
                throw new Exception("Customer not found.");
            }

            if (customer.Password != changePasswordDto.OldPassword) // In a real app, verify hashed password
            {
                throw new Exception("Old password is incorrect.");
            }

            customer.Password = changePasswordDto.NewPassword; // In a real app, hash the password

            _customerProfileRepository.UpdateCustomer(customer);
        }
    }
}
