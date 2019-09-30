using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webmarktingcopy.Models;

namespace webmarktingcopy.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
             return View();
        }
        public ActionResult profile()
        {
            return View();
        }
        public ActionResult aboutme()
        {
            return View();
        }
        
        public JsonResult Getprofiledata()
        {
            using (web_managementEntities dbContext = new web_managementEntities())
            {
                int userid = Convert.ToInt16(Session["id"]);
                User_registration ProfileList = dbContext.User_registration.Where(x => x.Id == userid).FirstOrDefault();

                return Json(ProfileList, JsonRequestBehavior.AllowGet);
            }
        }
       
        public JsonResult addUser(User_registration use)
        {


            if (use != null)
            {
                if (use.Password == use.Re_Password)
                {
                    use.Password = Util.encrypt(use.Password);
                    using (web_managementEntities dbContext = new web_managementEntities())
                    {
                        dbContext.User_registration.Add(use);
                        dbContext.SaveChanges();
                        return Json(use, JsonRequestBehavior.AllowGet);
                        ViewBag.Message = "Successfully Registration Done"; 
                        
                    }
                }
                  else
                {
                    return Json("Password not match");
                }

            }
            else
            {
                return Json("Some Error Occured");
            }
          

        }
        public JsonResult CheckUser(User_registration use)
        {
            if (use != null)
            {
                using (web_managementEntities dbContext = new web_managementEntities())
                {
                    use.Password= Util.encrypt(use.Password);
                    var existuser = dbContext.User_registration.Where(x => (x.Email == use.Email) && (x.Password == use.Password)).FirstOrDefault();

                    if (existuser != null)
                    {
                        Session["User_Name"] = existuser.User_Name.ToString();
                        Session["Email"] = existuser.Email.ToString();
                       Session["Id"] = existuser.Id.ToString();
                      
                         return Json(existuser, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Some Error Occured");
                    }


                }


            }
            else
            {
                return Json("Some Error Occured");
            }
            
        }
        [HttpPost]
        public string Updateuser(User_registration profileCntr)
        {
            if (profileCntr != null)
            {
                using (web_managementEntities dbContext = new web_managementEntities())
                {
                    User_registration lstUser = dbContext.User_registration.Where(x => x.Id == profileCntr.Id).FirstOrDefault();
                    lstUser.User_Name = profileCntr.User_Name;
                    lstUser.Mobile_n = profileCntr.Mobile_n;
                    lstUser.Postal_code = profileCntr.Postal_code;
                    lstUser.Country = profileCntr.Country;
                    lstUser.City = profileCntr.City;
                    lstUser.Address = profileCntr.Address;
                    lstUser.Email = profileCntr.Email;
                    lstUser.Gender = profileCntr.Gender;
                    dbContext.SaveChanges();
                    return " Updated";
                }
            }
            else
            {
                return "Oops! something went wrong.";
            }
        }
        public ActionResult LogOutSession()
        {
            Session.Remove("id");
            Session.Remove("User_Name");
            Session.Remove("Gender");
            Session.Remove("Mobile_n");
            Session.Remove("Address");
            Session.Remove("Email");
            Session.Remove("City");
            Session.Remove("Postal_code");
            Session.Remove("Country");
            return RedirectToAction("Login", "Home");
        }
    }
}