using Microsoft.EntityFrameworkCore;
using School_Acoount_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Acoount_Management_System.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }
        public DbSet<StudentInfo>StudentInfo { get; set; }
        public DbSet<DistrictInfo> DistrictInfo { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
