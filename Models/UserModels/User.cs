﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BobCoffeInc.Models
{
    public class User
    {
        public int Id { get; set; }
        public string full_name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string about { get; set; }
    }
}