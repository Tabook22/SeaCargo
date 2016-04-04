using SeaCargo.Models;
using SeaCargo.Models.DB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeaCargo.Controllers
{
    public class HomeController : Controller
    {
        private SeaCargoDbContext db = new SeaCargoDbContext();
        public ActionResult Index()
        {
            var getImgGallery= db.tbl_articles.Where(x => x.a_loc == "3" && x.a_status == "1").ToList();

            var getHeaderBg = db.tbl_articles.Where(x => x.a_loc == "1" && x.a_status == "1").First().a_img;
            var getSiteLogo = db.tbl_articles.Where(x => x.a_loc == "2" && x.a_status == "1").First().a_img;
            ViewBag.BG = getHeaderBg; //header background
            ViewBag.SiteLogo = getSiteLogo; //Site Logo
            return View(getImgGallery);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contactus()
        {

            return View();
        }
        public ActionResult ContactusThanks()
        {

            return View();
        }
        //TODO:Add New Contact
        [HttpPost]
        public ActionResult Contactus(tbl_contact contact)
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy h:mm");
            CultureInfo us = new CultureInfo("en-US");
            CultureInfo sa = new CultureInfo("ar-SA");
            string text = date;
            string format = "dd/MM/yyyy h:mm";
            var enDate = DateTime.ParseExact(text, format, us);
            if (ModelState.IsValid)//Check for validation errors
            {
                tbl_contact myContact = new tbl_contact();
                myContact.GDate = enDate;
                myContact.GName = contact.GName;
                myContact.GAddress = contact.GAddress;
                myContact.GEmail = contact.GEmail;
                myContact.GSubject = contact.GSubject;
                myContact.GData = contact.GData;

                db.tbl_contacts.Add(myContact);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = "Thank you for contacting us. Your Message Has been sent";

              
                
            }else
            {
                ViewBag.Message = "Please Checkout the Message Contents, !!";
                return View(contact);
            }
            return View();
        }
        public ActionResult Header()
        {
           
            return View();
        }

        //public ActionResult Slider()
        //{
        //    return View();
        //}


        //public ActionResult Aboutus()
        //{
        //    return View();
        //}

        public ActionResult Services()
        {
            var getImgGallery = db.tbl_articles.Where(x => x.a_loc == "3" && x.a_status == "1").ToList();
            return View(getImgGallery);
        }

        //public ActionResult ProductList()
        //{
        //    return View();
        //}

        //public  ActionResult Subscripe()
        //{
        //    return View();
        //}



        //public ActionResult Footer()
        //{
        //    return View();
        //}
    }
}