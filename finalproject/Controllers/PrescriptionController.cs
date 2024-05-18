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
    public class PrescriptionController : ApiController
    {
        private readonly PrescriptionService _prescriptionService;

        public PrescriptionController()
        {
            _prescriptionService = new PrescriptionService();
        }

        [HttpPost]
        [Route("api/prescription/upload")]
        public IHttpActionResult UploadPrescription([FromBody] UploadPrescriptionDTO uploadPrescriptionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _prescriptionService.UploadPrescription(uploadPrescriptionDto);
                return Ok("Prescription uploaded");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/prescription/{prescriptionId}")]
        public IHttpActionResult GetPrescriptionById(int prescriptionId)
        {
            try
            {
                var prescription = _prescriptionService.GetPrescriptionById(prescriptionId);
                return Ok(prescription);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/prescription/customer/{customerId}")]
        public IHttpActionResult GetPrescriptionsByCustomerId(int customerId)
        {
            try
            {
                var prescriptions = _prescriptionService.GetPrescriptionsByCustomerId(customerId);
                return Ok(prescriptions);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("api/prescription/status")]
        public IHttpActionResult UpdatePrescriptionStatus([FromUri] int prescriptionId, [FromUri] string status)
        {
            try
            {
                _prescriptionService.UpdatePrescriptionStatus(prescriptionId, status);
                return Ok("Prescription status updated");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return InternalServerError(ex);
            }
        }
    }
}
