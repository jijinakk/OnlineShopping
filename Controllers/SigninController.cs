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

    }
}
    
