using OnlineShopping.Models;
using OnlineShopping.Respository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OnlineShopping.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Layout()
        {
            return View();
        }
        public ActionResult GetDetails()
        {
            SignupRespository signupRepository = new SignupRespository();
            ModelState.Clear();
            return View(signupRepository.GetDetails());
        }
        /// <summary>
        /// Get method to view Creating  a record
        /// </summary>
        /// <returns></returns>
        public ActionResult AddDetail()
        {
            return View();
        }

        /// <summary>
        /// Post method to assign created value to database
        /// </summary>
        /// <param name="signup"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddDetail(Signup signup)
        {


            SignupRespository signupRepository = new SignupRespository();

            if (ModelState.IsValid)
            {


                if (signupRepository.AddDetails(signup))
                {

                    ViewBag.Message = "User Details Added Successfully";

                }
            }


            return RedirectToAction("GetDetails");

        }


        public ActionResult EditDetails(int? id)
        {
            SignupRespository signupRepository = new SignupRespository();

            return View(signupRepository.GetDetails().Find(sign => sign.id == id));

        }
        /// <summary>
        /// Editing the record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="signup"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public ActionResult EditDetails(int? id, Signup signup)
        {

            SignupRespository signupRepository = new SignupRespository();
            try
            {

                signupRepository.Edit(signup);
                return RedirectToAction("GetDetails");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult DeleteDetails(int id, Signup signup)
        {
            try
            {
                SignupRespository signupRepository = new SignupRespository();
                if (signupRepository.DeleteDetails(id))
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

        public ActionResult AddSellerDetails()
        {
            return View();
        }

        /// <summary>
        /// Post method to assign created value to database
        /// </summary>
        /// <param name="signup"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddSellerDetails(SellerSignup sellersignup)
        {
            try
            {
                SignupRespository signupRepository = new SignupRespository();

                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(sellersignup.usertype))
                    {
                        sellersignup.usertype = "customer";
                        signupRepository.AddSellerDetails(sellersignup);
                        ViewBag.Message = "User Details Added Successfully";
                    }
                }
                return View();

            }
            catch
            {
                return View();
            }
        }
        // GET: Login

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
                    SignupRespository signupRepository = new SignupRespository();
                    bool isValidUser = signupRepository.ValidateUser(signin.Username, signin.Password);

                    if (isValidUser)
                    {
                        // User is authenticated, you can add code to set authentication cookies or session variables
                        ViewBag.Message = "Login successful";
                        return RedirectToAction("GetDetails"); // Redirect to the home page after successful login
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