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

        public ActionResult UserHomePage()
        {
            return View();
        }
        public ActionResult HomePage()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult MainHomePageLayout()
        {
            return View();
        }
        public ActionResult Aboutus()
        {
            return View();
        }
        public ActionResult Contactus()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contactus(Contactus contactus)
        {
            try
            {
                SignupRespository signupRepository = new SignupRespository();

                if (ModelState.IsValid)
                {


                    if (signupRepository.Contactus(contactus))
                    {

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


        public ActionResult Layout()
        {
            return View();
        }
            // GET: User/Details/5

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
            try
            {
                SignupRespository signupRepository = new SignupRespository();

                if (ModelState.IsValid)
                {


                    if (signupRepository.AddDetails(signup))
                    {

                        TempData["SuccessMessage"] = "User Details Added Successfully"; // Store message in TempData

                    }
                }


                return RedirectToAction("Signin", "Signin");
            }
            catch
            {
                return View();
            }

        }


        public ActionResult EditDetails(int? id)
        {
            try
            {
                SignupRespository signupRepository = new SignupRespository();

                return View(signupRepository.GetDetails().Find(sign => sign.id == id));
            }
            catch
            {
                return View();
            }


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

        public ActionResult GetSellerDetails()
        {
            SignupRespository signupRepository = new SignupRespository();
            ModelState.Clear();
            return View(signupRepository.GetSellerDetails());
        }
        // GET: Login

       
    }

        
 }


