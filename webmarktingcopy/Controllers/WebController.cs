using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webmarktingcopy.Models;

namespace webmarktingcopy.Controllers
{
    public class WebController : Controller
    {
        //
        // GET: /Web/
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult addUser(User_registration use)
        {


            if (use != null)
            {
                if (use.Password == use.Re_Password)
                {

                    using (web_managementEntities dbContext = new  web_managementEntities())
                    {
                        dbContext.User_registration.Add(use);
                        dbContext.SaveChanges();
                        return Json(use, JsonRequestBehavior.AllowGet);
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

	}
	}
 