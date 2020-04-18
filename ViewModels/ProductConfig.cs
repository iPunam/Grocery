using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.ViewModels
{
    public class ProductConfig
    {
        public long ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Desc { get; set; }

        [Required]
        public int Index { get; set; }
    }
}
