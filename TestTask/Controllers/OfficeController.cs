using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class OfficeController : Controller
    {
        Users user = new Users();
        Consultations consultation = new Consultations();
        Subscribers subscriber = new Subscribers();

        // GET: Office
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username,string password)
        {    var data ="";
          if (username.Trim() == "Info" && password.Trim()=="P#sSw0%d")
            {
                data = "SUCCESS";
                Session["username"] = "Admin";
                Session["password"] = "P#sSw0%d";
            }
            else
            {data = "ERROR";
             }
            return Json(new { Massage = data }, JsonRequestBehavior.AllowGet);
             }

        public ActionResult Home()
        {
            if (Convert.ToString(Session["username"]) == "" && Convert.ToString(Session["password"]) == "")
            {
                return RedirectToAction("Index", "Office");
            }
            else
            {
                return View();

            }
        }
        public ActionResult FreeEstimate()
        {
            if (Convert.ToString(Session["username"]) == "" && Convert.ToString(Session["password"]) == "")
            {
                return RedirectToAction("Index", "Office");
            }
            else
            {
                return View();

            }
        }
        public JsonResult GetFEs()
        {

            List<Users> allusers = new List<Users>();
            allusers = user.Allusers();
            return Json(new { data = allusers }, JsonRequestBehavior.AllowGet );

        }
        public JsonResult GetFE(int id)
        {
            Users userget = user.Getuser(id);

            return Json(new {data=userget },JsonRequestBehavior.AllowGet);

        }
        public JsonResult UpdateFE(int id, Users newuser)
        {
            user.Updateuser(id, newuser);
            return Json(JsonRequestBehavior.AllowGet);

        }
        public JsonResult DeleteFE(int id)
        {
            user.Delete(id);
            return Json(JsonRequestBehavior.AllowGet);

        }
        public ActionResult FreeConsultation()
        {
            //if (Convert.ToString(Session["username"]) == "" && Convert.ToString(Session["password"]) == "")
            //{
            //    return RedirectToAction("Index", "Office");
            //}
            //else
            //{
                return View();

            //}
        }
        public JsonResult GetFCs()
        {

            List<Consultations> allconsult = new List<Consultations>();
            allconsult = consultation.AllConsultations();
            return Json(new { data = allconsult }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetFC(int id)
        {
            Consultations consutget = consultation.GetConsultation(id);

            return Json(new { data = consutget }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult UpdateFC(int id, Consultations updateconsult)
        {
            consultation.Updateconsultations(id, updateconsult);
            return Json(JsonRequestBehavior.AllowGet);

        }
        public JsonResult DeleteFC(int id)
        {
            consultation.Delete(id);
            return Json(JsonRequestBehavior.AllowGet);

        }
        public ActionResult E_mailnewsletter()
        {
            //if (Convert.ToString(Session["username"]) == "" && Convert.ToString(Session["password"]) == "")
            //{
            //    return RedirectToAction("Index", "Office");
            //}
            //else
            //{
            return View();

            //}
        }
        public JsonResult GetEMNLs()
        {

            List<Subscribers> allSubs = new List<Subscribers>();
            allSubs = subscriber.AllSubscribers();
            return Json(new { data = allSubs }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetEMNL(int id)
        {
            Subscribers subscribget = subscriber.GetSubscriber(id);

            return Json(new { data = subscribget }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult UpdateEMNL(int id, Subscribers updatesubscriber)
        {
            subscriber.UpdateSub(id, updatesubscriber);
            return Json(JsonRequestBehavior.AllowGet);

        }
        public JsonResult DeleteEML(int id)
        {
            subscriber.Delete(id);
            return Json(JsonRequestBehavior.AllowGet);

        }
        public ActionResult Logout()
        {

            Session.Clear();
            Session["password"] = null;
            Session["username"] = null;
            return RedirectToAction("Index", "Office");


        }




    }
}