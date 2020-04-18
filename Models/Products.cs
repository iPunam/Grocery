using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grocery.Models
{
    public class Products
    {
        [Key]
        [Column(TypeName = "BigInt")]
        public long ProdID { get; set; }

        [Required]
        [Column(TypeName = "nVarChar(20)")]
        [Display(Name = "Product No.")]
        [StringLength(20, ErrorMessage = "Product No. cannot be longer than 20 characters.")]
        public string ProdNum { get; set; }

        [Required]
        [Column(TypeName = "nVarChar(100)")]
        [Display(Name = "Product Name")]
        [StringLength(100, ErrorMessage = "Product Name cannot be longer than 100 characters.")]
        public string ProdName { get; set; }

        [Required]
        [Column(TypeName = "nVarChar(200)")]
        [Display(Name = "Product Description")]
        [StringLength(200, ErrorMessage = "Product Name cannot be longer than 200 characters.")]
        public string ProdDesc { get; set; }

        [Column(TypeName = "nVarChar(512)")]
        [Display(Name = "Product Notes")]
        [StringLength(512, ErrorMessage = "Product Notes cannot be longer than 512 characters.")]
        public string ProdNotes { get; set; }

        [Column(TypeName = "nVarChar(200)")]
        [Display(Name = "Product Image")]
        [StringLength(200, ErrorMessage = "Product Image cannot be longer than 200 characters.")]
        public string ProdImageName { get; set; }

        [Column(TypeName = "BigInt")]
        public long ProdCategoryID { get; set; }

        [Column(TypeName = "BigInt")]
        public long ProdBrandID { get; set; }

        [Column(TypeName = "BigInt")]
        public long UOMID { get; set; }
    }
}
