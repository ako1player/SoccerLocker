using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoccerLocker.Models
{
    public class Cleats
    {
        [Required]
        public int Id { get; set; }
        [Display(Name ="Brand")]
        public int? BrandID { get; set; }
        public virtual Brand Brand { get; set; }
        [Required]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string cleatName { get; set; }
        [Required]
        [Display(Name = "Size(US)")]
        [StringLength(50)]
        public string size { get; set; }
        [Required]
        [Display(Name = "Price($)")]
        public decimal price { get; set; }
        [Required]
        [Display(Name = "Color")]
        [StringLength(50)]
        public string color { get; set; }
    }
}