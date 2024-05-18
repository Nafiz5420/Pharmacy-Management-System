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
    public class PrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService()
        {
            _prescriptionRepository = new PrescriptionRepository();
        }

        public void UploadPrescription(UploadPrescriptionDTO uploadPrescriptionDto)
        {
            var prescription = new Prescription
            {
                CustomerId = uploadPrescriptionDto.CustomerId,
                ImageUrl = uploadPrescriptionDto.ImageUrl,
                Status = "Pending",
                UploadDate = DateTime.Now
            };

            _prescriptionRepository.AddPrescription(prescription);
        }

        public PrescriptionDTO GetPrescriptionById(int prescriptionId)
        {
            var prescription = _prescriptionRepository.GetPrescriptionById(prescriptionId);

            if (prescription == null)
            {
                throw new Exception("Prescription not found.");
            }

            return new PrescriptionDTO
            {
                PrescriptionId = prescription.PrescriptionId,
                CustomerId = prescription.CustomerId,
                ImageUrl = prescription.ImageUrl,
                Status = prescription.Status,
                UploadDate = prescription.UploadDate
            };
        }

        public List<PrescriptionDTO> GetPrescriptionsByCustomerId(int customerId)
        {
            var prescriptions = _prescriptionRepository.GetPrescriptionsByCustomerId(customerId);
            var prescriptionDtos = new List<PrescriptionDTO>();

            foreach (var prescription in prescriptions)
            {
                prescriptionDtos.Add(new PrescriptionDTO
                {
                    PrescriptionId = prescription.PrescriptionId,
                    CustomerId = prescription.CustomerId,
                    ImageUrl = prescription.ImageUrl,
                    Status = prescription.Status,
                    UploadDate = prescription.UploadDate
                });
            }

            return prescriptionDtos;
        }

        public void UpdatePrescriptionStatus(int prescriptionId, string status)
        {
            var prescription = _prescriptionRepository.GetPrescriptionById(prescriptionId);

            if (prescription == null)
            {
                throw new Exception("Prescription not found.");
            }

            prescription.Status = status;
            _prescriptionRepository.UpdatePrescription(prescription);
        }
    }
}