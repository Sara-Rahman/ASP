using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using School_Acoount_Management_System.Data;
using School_Acoount_Management_System.Models;
using School_Acoount_Management_System.ViewModel;

namespace School_Acoount_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext context;

        public HomeController(DatabaseContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            var a = context.DistrictInfo.ToList();
            ViewBag.DistrictList = new SelectList(a, "DistrictInfoId", "DistrictName");
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(StudentInfoVM a)
        {
            if (ModelState.IsValid)
            {
                StudentInfo b = new StudentInfo()
                {
                    StudentId = a.StudentId,
                    StudentName = a.StudentName,
                    Class = a.Class,
                    Section = a.Section,
                    DistrictInfoId=a.DistrictInfoId
                };
                context.StudentInfo.Add(b);
                context.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = "You have added " + a.StudentName;
            }
            var ab = context.DistrictInfo.ToList();
            ViewBag.DistrictList = new SelectList(ab, "DistrictInfoId", "DistrictName");
            return View();
        }
        public IActionResult StudentList()
        {
            //List<StudentInfo> studentlist = context.StudentInfo.ToList();
            //var s = new List<StudentInfoVM>();
            var studentlist = context.StudentInfo.ToList();
            var districtlist = context.DistrictInfo.ToList();
            var s = new List<StudentInfoVM>();
            if (studentlist != null && districtlist != null)
            {
                var queryResult = from a in studentlist
                                  join b in districtlist
                                  on a.DistrictInfoId equals b.DistrictInfoId
                                  select new
                                  {
                                      StudentId = a.StudentId,
                                      StudentName = a.StudentName,
                                      Class = a.Class,
                                      Section = a.Section,
                                      DistrictInfoId = b.DistrictInfoId,
                                      DistrictName = b.DistrictName
                                  };

                int count = 1;
                foreach (var item in queryResult)
                {
                    StudentInfoVM b = new StudentInfoVM()
                    {
                        StudentId = item.StudentId,
                        StudentName = item.StudentName,
                        Class = item.Class,
                        Section = item.Section,
                        DistrictName = item.DistrictName
                    };
                    b.Serial = count;
                    count++;
                    s.Add(b);

                }

                return View(s);
            }
            return View();
        }

        public IActionResult UpdateStudent(int id)
        {
            StudentInfo d = context.StudentInfo.Where(s => s.StudentId == id).FirstOrDefault();
            var ab = context.DistrictInfo.ToList();
            ViewBag.DistrictList = new SelectList(ab, "DistrictInfoId", "DistrictName");
            StudentInfoVM st = new StudentInfoVM()
            {
                StudentId = d.StudentId,
                StudentName = d.StudentName,
                Class = d.Class,
                Section = d.Section,
                DistrictInfoId=d.DistrictInfoId

            };
            return View(st);
        }
        [HttpPost]
        public IActionResult UpdateStudent(StudentInfoVM a)
        {


            StudentInfo stt = new StudentInfo()
            {
                StudentId = a.StudentId,
                StudentName = a.StudentName,
                Class = a.Class,
                Section = a.Section

            };
            context.StudentInfo.Update(stt);
            context.SaveChanges();
            return View();
        }
        public IActionResult StudentDetails(int id)
        {
            StudentInfo a = context.StudentInfo.Where(s => s.StudentId == id).FirstOrDefault();
            var studentlist = context.StudentInfo.ToList();
            var districtlist = context.DistrictInfo.ToList();

            if (a != null && districtlist != null)
            {
                var q = (from c in districtlist
                         join d in studentlist
                         on c.DistrictInfoId equals d.DistrictInfoId
                         where d.DistrictInfoId == a.DistrictInfoId
                         select new
                         {
                             Section = a.Section,
                             Class = a.Class,
                             StudentName = a.StudentName,
                             StudentId = a.StudentId,
                             DisName = c.DistrictName

                         }).FirstOrDefault();

                StudentInfoVM studentInfoVM = new StudentInfoVM()
                {
                    Section = q.Section,
                    Class = q.Class,
                    StudentName = q.StudentName,
                    StudentId = q.StudentId,
                    DistrictName = q.DisName

                };
                return View(studentInfoVM);
            }
            else
            {
                return NotFound();
            }


        }




        public IActionResult DeleteStudent(int id)
        {
            StudentInfo d = context.StudentInfo.Where(s => s.StudentId == id).FirstOrDefault();
            if (d != null)
            {
                StudentInfoVM st = new StudentInfoVM()
                {
                    StudentId = d.StudentId,
                    StudentName = d.StudentName,
                    Class = d.Class,
                    Section = d.Section

                };
                return View(st);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult DeleteStudent(StudentInfoVM a)
        {
            StudentInfo e = context.StudentInfo.Where(s => s.StudentId == a.StudentId).FirstOrDefault();
            context.StudentInfo.Remove(e);
            context.SaveChanges();
            return RedirectToAction("StudentList");
        }
        public IActionResult AddDistrict()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDistrict(DistrictInfo a )
        {
            context.DistrictInfo.Add(a);
            context.SaveChanges();
            return View();
        }
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRole(Role r)
        {
            context.Roles.Add(r);
            context.SaveChanges();
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(User a)
        {
            a.RoleId = 2;
            context.Users.Add(a);
            context.SaveChanges();
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
