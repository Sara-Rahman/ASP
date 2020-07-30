using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Acoount_Management_System.Models
{
    public class StudentInfo
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
       
        public int DistrictInfoId { get; set; }
    }
}
