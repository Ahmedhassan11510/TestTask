using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class UserController : Controller
    {
        Users user = new Users();
        Consultations consultation = new Consultations();
        Subscribers subscribers = new Subscribers();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(Users newuser)
        {
            //user.Users.Add(newuser);
            //user.SaveChanges();
            //var no = new Users();
            //no.Name = Name;
            //no.E_mail = E_mail;
            //no.Phone = Phone;
            //no.Masssage = Masssage;
            //no.Poromocode = Poromocode;

            user.Register(newuser);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        [HttpPost]
        public ActionResult AddConsultation(Consultations newconsultation)
        { consultation.Addconsultation(newconsultation);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpPost]
        public ActionResult AddSubcribe(Subscribers newsubscrib)
        {
            subscribers.Addsub(newsubscrib);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
    }
}