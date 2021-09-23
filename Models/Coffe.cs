using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BobCoffeInc.Models
{
    public class Coffe
    {
       
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string ImagePath { get; set; }
    }
    
}