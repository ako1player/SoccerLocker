using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoccerLocker.Models
{
    public class Brand
    {
        public int ID { get; set; }
        [Display(Name = "Brand")]
        public string name { get; set; }
        public virtual ICollection<Cleats> Cleats { get; set; }
    }
}