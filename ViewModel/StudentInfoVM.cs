using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School_Acoount_Management_System.ViewModel
{
    public class StudentInfoVM
    {
       

        public int StudentId { get; set; }
        [Required]
      //  [Display(Name="Emter Student Name")]
        public string StudentName { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string Section { get; set; }
        [Display(Name = "District Name")]
        public int DistrictInfoId { get; set; }
        public int Serial { get; set; }
        public string DistrictName { get; set; }
    }
}
