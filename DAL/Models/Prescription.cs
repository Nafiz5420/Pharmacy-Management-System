using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public int CustomerId { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
