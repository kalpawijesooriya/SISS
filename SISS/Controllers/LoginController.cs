using SISS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SISS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(SISS.Models.Login login)
        {
            using (SISS_Context db = new SISS_Context())
            {
                var userDetails = db.Login.Where(x => x.userName == login.userName && x.password == login.password).FirstOrDefault();
                if (userDetails == null)
                {
                    login.LoginErrorMessage = "*Wrong Employee Number or Password.";//show login erroe message
                    return View("Index", login);
                }
                else
                {
                   
                    Session["userName"] = userDetails.userName.Trim();//retrive USerName of login user
                    Session["Role"] = userDetails.Role.Trim();
                    Session["Name"] = db.User.Where(x => x.UserEmployeeNumber == userDetails.UserEmployeeNumber).FirstOrDefault().officerName;
                    Session["userID"] = db.User.Where(x => x.UserEmployeeNumber == userDetails.UserEmployeeNumber).FirstOrDefault().UserEmployeeNumber;
                    string username = Session["userName"].ToString();
                    string role = userDetails.Role.ToString().Trim();//retrive the user role
                   // if (role.Equals("supervisor"))//if user is supervisor goto the supervisor page
                   // {
                        return RedirectToAction("Index", "Home");
                    //}
                  


                    //else
                       // return RedirectToAction("Index", "Login");
                }
            }
        }

        public ActionResult LogOut()// logout methord
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }



    }
}