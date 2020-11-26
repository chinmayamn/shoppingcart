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
    public class MinishopController : Controller
    {
        public MinishopController()
        {
           
        }

        // GET: Minishop
        public ActionResult Index()
        {
            Session["theme"] = "minishop";
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

        [Route("minishop/shipping_information")]
        [Route("minishop/exchange")]
        [Route("minishop/terms_conditions")]
        [Route("minishop/privacy_policy")]
        [Route("minishop/faq")]
        public ActionResult CMS()
        {
            string CurrentAction = Request.RawUrl;
            if (CurrentAction == "/minishop/shipping_information")
            {
                ViewBag.Title = "Shipping Information";
                ViewBag.text = "shipping";
            }
            else if (CurrentAction == "/minishop/exchange")
            {
                ViewBag.Title = "Return & Exchange";
                ViewBag.text = "exchange";
            }
            else if (CurrentAction == "/minishop/terms_conditions")
            {
                ViewBag.Title = "Terms & Conditions";
                ViewBag.text = "terms and conditions";
            }
            else if (CurrentAction == "/minishop/faq")
            {
                ViewBag.Title = "FAQ";
                ViewBag.text = "FAQ";
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