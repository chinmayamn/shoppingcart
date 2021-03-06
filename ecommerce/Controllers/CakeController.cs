﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ecommerce.Models;
using Newtonsoft.Json;
using System.Web.Routing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;

namespace ecommerce.Controllers
{
    public class CakeController : Controller
    {
        private HttpClient client = new HttpClient();
        public CakeController()
        {
            client.BaseAddress = new Uri("http://localhost:49820/");
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization",
            Convert.ToBase64String(Encoding.Default.GetBytes("chinmayamn@gmail.com:Chinmaya@123")));
        }

        // GET: Cake
        [Route("cake")]
        [Route("cake/index")]
        public ActionResult Index()
        {
           
            Session["theme"] = "cake";
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

        public ActionResult Cart()
        {

            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }

        [Route("cake/shop")]
        [Route("cake/category")]
        public  async Task<ActionResult> Category()
        {
          
            HttpResponseMessage res = await client.GetAsync("api/cart/fillcategory");
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var empresponse = "";
            List<Category> ll = new List<Models.Category>();
            if (res.IsSuccessStatusCode)
            {
                empresponse = res.Content.ReadAsStringAsync().Result;
                ll = JsonConvert.DeserializeObject<List<Category>>(empresponse);
             
            }
                return View(ll);
        }


        
        [Route("cake/shipping_information")]
        [Route("cake/exchange")]
        [Route("cake/terms_conditions")]
        [Route("cake/privacy_policy")]
        [Route("cake/jobs")]
        [Route("cake/community")]
        [Route("cake/lookbook")]
        [Route("cake/free_shipping")]
        [Route("cake/free_returns")]
        [Route("cake/franchise")]
        [Route("cake/conformity")]
        [Route("cake/shipping_methods")]
        [Route("cake/product_returns")]
        [Route("cake/shipping_cost")]
        [Route("cake/payment_methods")]
        public ActionResult CMS()
        {
            string CurrentAction = Request.RawUrl;
            if (CurrentAction == "/cake/shipping_information")
            {
                ViewBag.Title = "Shipping Information";
                ViewBag.text = "shipping";
            }
            else if (CurrentAction == "/cake/exchange")
            {
                ViewBag.Title = "Return & Exchange";
                ViewBag.text = "exchange";
            }
            else if (CurrentAction == "/cake/terms_conditions")
            {
                ViewBag.Title = "Terms & Conditions";
                ViewBag.text = "terms and conditions";
            }
            else if (CurrentAction == "/cake/privacy_policy")
            {
                ViewBag.Title = "Privacy Policy";
                ViewBag.text = "privacy policy";
            }
            else if (CurrentAction == "/cake/jobs")
            {
                ViewBag.Title = "Jobs";
                ViewBag.text = "Jobs";
            }
            else if (CurrentAction == "/cake/community")
            {
                ViewBag.Title = "Community";
                ViewBag.text = "Community";
            }
            else if (CurrentAction == "/cake/lookbook")
            {
                ViewBag.Title = "Lookbook";
                ViewBag.text = "Lookbook";
            }
            else if (CurrentAction == "/cake/free_shipping")
            {
                ViewBag.Title = "Free Shipping";
                ViewBag.text = "Free Shipping";
            }
            else if (CurrentAction == "/cake/free_returns")
            {
                ViewBag.Title = "Free Returns";
                ViewBag.text = "Free Returns";
            }
            else if (CurrentAction == "/cake/franchise")
            {
                ViewBag.Title = "Franchise";
                ViewBag.text = "Franchise";
            }
            else if (CurrentAction == "/cake/conformity")
            {
                ViewBag.Title = "Conformity";
                ViewBag.text = "Conformity";
            }
            else if (CurrentAction == "/cake/shipping_methods")
            {
                ViewBag.Title = "Shipping Methods";
                ViewBag.text = "Shipping Methods";
            }
            else if (CurrentAction == "/cake/product_returns")
            {
                ViewBag.Title = "Product Returns";
                ViewBag.text = "Product Returns";
            }
            else if (CurrentAction == "/cake/shipping_cost")
            {
                ViewBag.Title = "Shipping Cost";
                ViewBag.text = "Shipping Cost";
            }
            else if (CurrentAction == "/cake/payment_methods")
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

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

    }
}