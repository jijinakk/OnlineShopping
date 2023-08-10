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
            try
            {
                if (ModelState.IsValid)
                {
                    SigninRespository signinRepository = new SigninRespository();
                    string role = signinRepository.GetUserRole(signin.username, signin.password);

                    if (role == "customer")
                    {
                        Session["UserId"] = signin.id.ToString();
                        Session["Username"] = signin.username.ToString();

                        ViewBag.username = signin.username;
                        return RedirectToAction("GetProductsForUser", "User");

                    }
                    else if (role == "seller")
                    {
                        return RedirectToAction("");
                    }
                    else if (role == "Admin")
                    {
                        return RedirectToAction("GetProducts", "Product");
                    }
                    else
                    {
                        ViewBag.Message = "Invalid username or password";
                    }
                }

                return View();


            }
            catch
            {
                return View();
            }

        }
}
}
    
