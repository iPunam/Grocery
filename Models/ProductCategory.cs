
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Models
{
    public class ProductCategory
    {
        [Key]
        [Column(TypeName = "BigInt")]
        public long ProdCategoryID { get; set; }

        [Required]
        [Column(TypeName = "nVarChar(30)")]
        [Display(Name = "Category Name")]
        [StringLength(30, ErrorMessage = "Category Name cannot be longer than 30 characters.")]
        public string ProdCategoryName { get; set; }

        [Column(TypeName = "nVarChar(50)")]
        [Display(Name = "Category Description")]
        [StringLength(50, ErrorMessage = "Category Description cannot be longer than 50 characters.")]
        public string ProdCategoryDesc { get; set; }

        [Required]
        [Column(TypeName = "Int")]
        [Display(Name = "Category Index")]
        [StringLength(3, ErrorMessage = "Category Index cannot be longer than 3 characters.")]
        public int ProdCategoryIndex { get; set; }

        //public ICollection<Products> Products { get; set; }
    }
}
