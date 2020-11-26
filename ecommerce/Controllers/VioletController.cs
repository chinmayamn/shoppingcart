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
    public class VioletController : Controller
    {
        // GET: Violet
        public VioletController()
        {
            
        }

        public ActionResult Index()
        {
            Session["theme"] = "violet";
            return View();
        }

       

        public ActionResult MyOrders()
        {


            return View();
        }
        public ActionResult Gallery()
        {


            return View();
        }
        public ActionResult Search()
        {


            return View();
        }

        [Route("violet/about")]
        [Route("violet/shipping_information")]
        [Route("violet/exchange")]
        [Route("violet/terms_conditions")]
        [Route("violet/privacy_policy")]
        [Route("violet/jobs")]
        [Route("violet/community")]
        [Route("violet/lookbook")]
        [Route("violet/free_shipping")]
        [Route("violet/free_returns")]
        [Route("violet/franchise")]
        [Route("violet/conformity")]
        [Route("violet/shipping_methods")]
        [Route("violet/product_returns")]
        [Route("violet/shipping_cost")]
        [Route("violet/payment_methods")]
        public ActionResult CMS()
        {
            string CurrentAction = Request.RawUrl;
            if (CurrentAction == "/violet/shipping_information")
            {
                ViewBag.Title = "Shipping Information";
                ViewBag.text = "shipping";
            }
            else if (CurrentAction == "/violet/exchange")
            {
                ViewBag.Title = "Return & Exchange";
                ViewBag.text = "exchange";
            }
            else if (CurrentAction == "/violet/terms_conditions")
            {
                ViewBag.Title = "Terms & Conditions";
                ViewBag.text = "terms and conditions";
            }
            else if(CurrentAction == "/violet/privacy_policy")
            {
                ViewBag.Title = "Privacy Policy";
                ViewBag.text = "privacy policy";
            }
            else if (CurrentAction == "/violet/jobs")
            {
                ViewBag.Title = "Jobs";
                ViewBag.text = "Jobs";
            }
            else if (CurrentAction == "/violet/community")
            {
                ViewBag.Title = "Community";
                ViewBag.text = "Community";
            }
            else if (CurrentAction == "/violet/lookbook")
            {
                ViewBag.Title = "Lookbook";
                ViewBag.text = "Lookbook";
            }
            else if (CurrentAction == "/violet/free_shipping")
            {
                ViewBag.Title = "Free Shipping";
                ViewBag.text = "Free Shipping";
            }
            else if (CurrentAction == "/violet/free_returns")
            {
                ViewBag.Title = "Free Returns";
                ViewBag.text = "Free Returns";
            }
            else if (CurrentAction == "/violet/franchise")
            {
                ViewBag.Title = "Franchise";
                ViewBag.text = "Franchise";
            }
            else if (CurrentAction == "/violet/conformity")
            {
                ViewBag.Title = "Conformity";
                ViewBag.text = "Conformity";
            }
            else if (CurrentAction == "/violet/shipping_methods")
            {
                ViewBag.Title = "Shipping Methods";
                ViewBag.text = "Shipping Methods";
            }
            else if (CurrentAction == "/violet/product_returns")
            {
                ViewBag.Title = "Product Returns";
                ViewBag.text = "Product Returns";
            }
            else if (CurrentAction == "/violet/shipping_cost")
            {
                ViewBag.Title = "Shipping Cost";
                ViewBag.text = "Shipping Cost";
            }
            else if (CurrentAction == "/violet/payment_methods")
            {
                ViewBag.Title = "Payment Methods";
                ViewBag.text = "Payment Methods";
            }
            else
            {
                ViewBag.Title = "About Us";
                ViewBag.text = "About Us";
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