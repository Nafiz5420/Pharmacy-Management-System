using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;


namespace finalproject.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly CustomerService _customerService;

        public CustomerController()
        {
            _customerService = new CustomerService();
        }

        [HttpPost]
        [Route("api/customer/register")]
        public IHttpActionResult Register([FromBody] CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _customerService.RegisterCustomer(customerDto);
                return Ok("Registration done");
            }
            catch (Exception ex)
            {
                // Log the exception (you could use a logging framework)
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/customer/login")]
        public IHttpActionResult Login([FromBody] CustomerLoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var customer = _customerService.Login(loginDto.Email, loginDto.Password);
                return Ok("Login done");
            }
            catch (ArgumentException argEx)
            {
                // Log the exception
                System.Diagnostics.Debug.WriteLine(argEx.Message);
                return BadRequest(argEx.Message);
            }
            catch (Exception ex)
            {
                // Log the exception
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return Unauthorized();
            }
        }
    }
}