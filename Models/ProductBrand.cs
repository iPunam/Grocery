using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Models
{
    public class ProductBrand
    {
        [Key]
        [Column(TypeName = "BigInt")]
        public long ProdBrandID { get; set; }

        [Required]
        [Column(TypeName = "nVarChar(50)")]
        [Display(Name = "Brand Name")]
        [StringLength(50, ErrorMessage = "Brand Name cannot be longer than 50 characters.")]
        public string ProdBrandName { get; set; }

        [Column(TypeName = "nVarChar(70)")]
        [Display(Name = "Brand Description")]
        [StringLength(70, ErrorMessage = "Category Description cannot be longer than 70 characters.")]
        public string ProdBrandDesc { get; set; }

        [Required]
        [Column(TypeName = "Int")]
        [Display(Name = "Brand Index")]
        [StringLength(4, ErrorMessage = "Category Index cannot be longer than 4 characters.")]
        public int ProdBrandIndex { get; set; }

       // public ICollection<Products> Products { get; set; }
    }
}
