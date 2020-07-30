using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Acoount_Management_System.Models
{
    public class DistrictInfo
    {
        [Key]
        public int DistrictInfoId { get; set; }
        public string DistrictName { get; set; }
    }
}
