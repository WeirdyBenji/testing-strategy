using System;
using System.ComponentModel.DataAnnotations;

namespace TwitterApi.Models
{
    public class User
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public String Password { get; set; }

        [Required]
        public String Email { get; set; }
    }
}