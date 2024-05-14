using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Seller")]
        public int SellerId { get; set; }

        public virtual Seller Seller { get; set; }

        public virtual ICollection<Selection> Selections { get; set; }
        public Product()
        {
            Selections = new List<Selection>();

        }
    }
    }
