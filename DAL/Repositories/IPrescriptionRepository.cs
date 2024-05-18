using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    public interface IPrescriptionRepository
    {
        void AddPrescription(Prescription prescription);
        Prescription GetPrescriptionById(int prescriptionId);
        List<Prescription> GetPrescriptionsByCustomerId(int customerId);
        void UpdatePrescription(Prescription prescription);
    }
}
