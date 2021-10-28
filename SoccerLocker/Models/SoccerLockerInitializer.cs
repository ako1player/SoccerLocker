using SoccerLocker.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SoccerLocker.Models
{
    public class SoccerLockerInitializer : DropCreateDatabaseAlways<SoccerLockerContext>
    {
        protected override void Seed(SoccerLockerContext context)
        {
            IList<Cleats> slCleats = new List<Cleats>();
            
            slCleats.Add(new Cleats() { cleatBrand = "Nike", cleatName = "Tiempo", size = "7", price = 80.99m, color = "Red" });
            slCleats.Add(new Cleats() { cleatBrand = "Adidas", cleatName = "Predator", size = "10", price = 100.99m, color = "Black" });
            slCleats.Add(new Cleats() { cleatBrand = "Adidas", cleatName = "Mundial", size = "9", price = 70.99m, color = "red" });
            slCleats.Add(new Cleats() { cleatBrand = "Nike", cleatName = "Mercurial", size = "11", price = 120.99m, color = "red" });

            context.Cleats.AddRange(slCleats);
            
            base.Seed(context);
        }
    }
}