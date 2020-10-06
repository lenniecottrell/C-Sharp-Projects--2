using NewsletterAppMVC.Models;
using NewsletterAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsletterAppMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (NewsletterEntities db = new NewsletterEntities()) //new entity object, gives us access to the db
            {
                //var signups = db.SignUps.Where(x => x.Removed == null).ToList(); //lamba syntax

                var signups = (from c in db.SignUps
                               where c.Removed == null
                               select c).ToList(); //LINQ
                var signupVms = new List<SignupVm>(); //new list of viewmodels
                foreach (var signup in signups) //map from the model to the view models
                {
                    var signupVm = new SignupVm(); //mapping properties to the VM
                    signupVm.Id = signup.Id;
                    signupVm.FirstName = signup.FirstName;
                    signupVm.LastName = signup.LastName;
                    signupVm.EmailAddress = signup.EmailAddress;
                    signupVms.Add(signupVm);
                };


                return View(signupVms); //pass the viewmodels to the view
            }
        }

        public ActionResult Unsubscribe(int Id)
        {
            using (NewsletterEntities db = new NewsletterEntities())
            {
                var signup = db.SignUps.Find(Id);
                signup.Removed = DateTime.Now;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}