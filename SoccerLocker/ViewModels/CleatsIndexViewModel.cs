using SoccerLocker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace SoccerLocker.ViewModels
{
    public class CleatsIndexViewModel
    {
        public IPagedList<Cleats> Cleats { get; set; }
        public string Search { get; set; }
        public IEnumerable<BrandWithCount> BrandWithCount { get; set; }
        public string Brand { get; set; }
        public string SortBy { get; set; }
        public Dictionary<string, string> Sorts { get; set; }
        public IEnumerable<SelectListItem> BrandFilterItems
        {
            get
            {
                var allBrands = BrandWithCount.Select(cc => new SelectListItem
                {
                    Value = cc.BrandName,
                    Text = cc.BrandNameWithCount
                });
                return allBrands;
            }
        }
    }
    public class BrandWithCount
    {
        public int CleatCount { get; set; }
        public string BrandName { get; set; }
        public string BrandNameWithCount
        {
            get
            {
                return BrandName + " (" + CleatCount.ToString() + ")";
            }
        }
    }
}