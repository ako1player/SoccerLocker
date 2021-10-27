using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoccerLocker.Models
{
    public class Cleats
    {
        public int Id { get; set; }
        public string cleatBrand { get; set; }
        public string cleatName { get; set; }
        public string size { get; set; }
        public decimal price { get; set; }
        public string color { get; set; }
    }
}