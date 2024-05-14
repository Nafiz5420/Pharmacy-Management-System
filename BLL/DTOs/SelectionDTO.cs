using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SelectionDTO
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ProductId { get; set; }
        public string SellerId { get; set; }
        public ProductDTO Product { get; set; }
        public SellerDTO Seller { get; set; }
    }
}