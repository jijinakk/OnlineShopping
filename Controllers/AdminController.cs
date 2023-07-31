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
            AdminRespository adminRespository = new AdminRespository();
            ModelState.Clear();
            return View(adminRespository.FeedbackDetails());
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        /// <summary>
        /// Post method to assign created value to database
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {


            AdminRespository adminRespository = new AdminRespository();
            adminRespository.AddProduct(product);
            string fileName = Path.GetFileNameWithoutExtension(product.Image.FileName);
            string extention = Path.GetExtension(product.Image.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssff") + extention;
            product.imageURL = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"));
            product.Image.SaveAs(fileName);
            return View();




        }


    }

}
