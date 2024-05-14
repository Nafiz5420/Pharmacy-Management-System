using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Model
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        public string Section { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Seller()
        {
            Products = new List<Product>();
        }

    }
}
