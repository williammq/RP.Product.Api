using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RP.Product.Api.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Sku { get; set; }
        [Required]
        public string CodeIntregration { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Price { get; set; }

        [Required]
        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        
        [Required]
        public int ProductCategoryId { get; set; }

        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; set; }

        [Required]
        public string State { get; set; }
        [Required]
        public string active { get; set; }
        [Required]
        public DateTime DateUpdate { get; set; }
       
    }
}
