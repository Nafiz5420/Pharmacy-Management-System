using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ShoppingCartDTO
    {
        public int ShoppingCartId { get; set; }
        public int CustomerId { get; set; }
        public List<CartItemDTO> CartItems { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
