using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Acoount_Management_System.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        
    }
}
