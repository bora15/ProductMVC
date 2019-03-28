using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Naziv")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Opis")]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Kategorija")]
        public string Category { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Proizvođać")]
        public string Manufacturer { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Dobavljač")]
        public string Supplier { get; set; }

        [Required]
        [DisplayName("Cena")]
        public decimal Price { get; set; }
    }
}
