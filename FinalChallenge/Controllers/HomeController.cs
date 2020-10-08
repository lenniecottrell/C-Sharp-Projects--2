using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace FinalChallenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public class Student
        {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        }

        public class Context : DbContext
        {
            public Context(): base()
            {

            }

            public DbSet<Student> Students { get; set; }
        }


        public List<Student> Students()
        {
            using (var ctx = new Context())
            {
                var stud = new Student() { FirstName = "Elena", LastName = "Diaz", Email = "ed2020@email.com" };

                ctx.Students.Add(stud);
                ctx.SaveChanges;
            }
        }
    }
}