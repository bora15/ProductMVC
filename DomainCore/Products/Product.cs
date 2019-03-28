using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Products
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        [Required]
        [MaxLength(50)]
        public string Manufacturer { get; set; }

        [Required]
        [MaxLength(50)]
        public string Supplier { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
