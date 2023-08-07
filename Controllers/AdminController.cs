using OnlineShopping.Models;
using OnlineShopping.Respository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopping.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminLayout()
        {
            return View();
        }
        public ActionResult AdminHomePage()
        {
            return View();
        }





        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
       ///Delete customer details
        public ActionResult DeleteDetails(int id, Signup signup)
        {
            try
            {
                AdminRespository adminRespository = new AdminRespository();
                if (adminRespository.DeleteDetails(id))
                {
                    ViewBag.AlertMessage("User details deleted successfully");
                }
                return RedirectToAction("GetDetails");
            }
            catch
            {
                return View();
            }
        }
        /// <summary>
        /// Delete seller details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sellersignup"></param>
        /// <returns></returns>
        public ActionResult DeleteSellerDetails(int id, SellerSignup sellersignup)
        {
            try
            {
                AdminRespository adminRespository = new AdminRespository();
                if (adminRespository.DeleteSellerDetails(id))
                {
                    ViewBag.AlertMessage("User details deleted successfully");
                }
                return RedirectToAction("GetDetails");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Get messages from users
        /// </summary>
        /// <returns></returns>
        public ActionResult GetContactus()
        {
            try
            {
                AdminRespository adminRespository = new AdminRespository();
                ModelState.Clear();
                return View(adminRespository.FeedbackDetails());
            }
            catch
            {
                return View();
            }
        }

       
    }
        

}
