using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Selection
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Category { get; set; }

        public string Description { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("Seller")]
        public int SellerId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Seller Seller { get; set; }
  
    }
}