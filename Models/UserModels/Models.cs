using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BobCoffeInc.Models
{
        public class LoginModel
        {
            [Required]
            public string username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string password { get; set; }
        }

        public class RegisterModel
        {
            [Required]
            public string full_name { get; set; }

            [Required]
            public string username { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            public string email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string password { get; set; }

            
            [Required]
            public string about { get; set; }
        }
    
}