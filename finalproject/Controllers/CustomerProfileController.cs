using System;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace finalproject.Controllers
{
    public class CustomerProfileController : ApiController
    {
        private readonly CustomerProfileService _customerProfileService;

        public CustomerProfileController()
        {
            _customerProfileService = new CustomerProfileService();
        }

        [HttpGet]
        [Route("api/customer/profile/{customerId}")]
        public IHttpActionResult GetProfile(int customerId)
        {
            try
            {
                var customerProfile = _customerProfileService.GetCustomerProfile(customerId);
                return Ok(customerProfile);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("api/customer/profile")]
        public IHttpActionResult UpdateProfile([FromBody] CustomerProfileDTO customerProfileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _customerProfileService.UpdateCustomerProfile(customerProfileDto);
                return Ok("Profile updated");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("api/customer/changePassword")]
        public IHttpActionResult ChangePassword([FromBody] ChangePasswordDTO changePasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _customerProfileService.ChangeCustomerPassword(changePasswordDto);
                return Ok("Password changed");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
