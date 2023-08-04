using OnlineShopping.Models;
using OnlineShopping.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OnlineShopping.Controllers
{
    public class SigninController : Controller
    {
        // GET: Signin
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// GET: Login
        /// </summary>
        /// <returns></returns>
        public ActionResult Signin()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Signin(Signin signin)
        {

            if (ModelState.IsValid)
            {
                SigninRespository signinRepository = new SigninRespository();
                string role = signinRepository.GetUserRole(signin.username, signin.password);

                if (role == "customer")
                {
                    return RedirectToAction("UserHomePage", "User");

                }
                else if (role == "seller")
                {
                    return RedirectToAction("");
                }
                else if (role == "Admin")
                {
                    return RedirectToAction("AdminHomePage", "Admin");
                }
                else
                {
                    ViewBag.Message = "Invalid username or password";
                }
            }

            return RedirectToAction("EditDetails");


        }

    }
}
    
