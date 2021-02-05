using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ecommerce.Models;
using Newtonsoft.Json;
using System.IO;
using System.Data;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Net.Http;

namespace ecommerce.Controllers
{
    public class EstoreController : Controller
    {
        public EstoreController()
        {
            
        }
        // GET: Estore
        public ActionResult Index()
        {
            Session["theme"] = "estore";
            return View();
        }

        public ActionResult About()
        {


            return View();
        }

        public ActionResult MyOrders()
        {


            return View();
        }

        [Route("shop/shipping_information")]
        [Route("shop/exchange")]
        [Route("shop/terms_conditions")]
        [Route("shop/privacy_policy")]
        public ActionResult CMS()
        {
            string CurrentAction = Request.RawUrl;
            if (CurrentAction == "/shop/shipping_information")
            {
                ViewBag.Title = "Shipping Information";
                ViewBag.text = "shipping";
            }
            else if (CurrentAction == "/shop/eecommxchange")
            {
                ViewBag.Title = "Return & Exchange";
                ViewBag.text = "exchange";
            }
            else if (CurrentAction == "/shop/terms_conditions")
            {
                ViewBag.Title = "Terms & Conditions";
                ViewBag.text = "terms and conditions";
            }
            else
            {
                ViewBag.Title = "Privacy Policy";
                ViewBag.text = "privacy policy";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}