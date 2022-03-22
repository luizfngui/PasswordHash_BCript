using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordHash_BCript.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}







