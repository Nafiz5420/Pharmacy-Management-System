using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PrescriptionDTO
    {
        public int PrescriptionId { get; set; }
        public int CustomerId { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
