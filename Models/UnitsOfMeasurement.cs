using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Models
{
    public class UnitsOfMeasurement
    {
        [Key]
        [Column(TypeName = "BigInt")]
        public long UOMID { get; set; }

        [Required]
        [Column(TypeName = "nVarChar(10)")]
        [Display(Name = "UOM Name")]
        [StringLength(10, ErrorMessage = "Brand Name cannot be longer than 10 characters.")]
        public string UOMName { get; set; }

        [Column(TypeName = "nVarChar(40)")]
        [Display(Name = "UOM Description")]
        [StringLength(40, ErrorMessage = "Category Description cannot be longer than 40 characters.")]
        public string UOMDesc { get; set; }

        [Required]
        [Column(TypeName = "Int")]
        [Display(Name = "UOM Index")]
        [StringLength(2, ErrorMessage = "UOM Index cannot be longer than 2 characters.")]
        public int UOMIndex { get; set; }

        //public ICollection<Products> Products { get; set; }
    }
}
