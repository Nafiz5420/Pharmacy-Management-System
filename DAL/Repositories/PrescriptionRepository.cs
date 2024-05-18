using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using System.Data.Entity;
namespace DAL.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly PharmacyContext _context;

        public PrescriptionRepository()
        {
            _context = new PharmacyContext();
        }

        public void AddPrescription(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            _context.SaveChanges();
        }

        public Prescription GetPrescriptionById(int prescriptionId)
        {
            return _context.Prescriptions.SingleOrDefault(p => p.PrescriptionId == prescriptionId);
        }

        public List<Prescription> GetPrescriptionsByCustomerId(int customerId)
        {
            return _context.Prescriptions.Where(p => p.CustomerId == customerId).ToList();
        }

        public void UpdatePrescription(Prescription prescription)
        {
            _context.Entry(prescription).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}