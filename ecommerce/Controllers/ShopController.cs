﻿using System;
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
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;

namespace ecommerce.Controllers
{
    
    public class ShopController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private HttpClient client = new HttpClient();

        public ShopController()
        {
            client.BaseAddress = new Uri("http://localhost:49820/");
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(Encoding.Default.GetBytes("chinmayamn@gmail.com:Chinmaya@123")));

        }

        public ShopController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
           
            UserManager = userManager;
            SignInManager = signInManager;
          
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {

            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        
        public async Task<ActionResult> Index()
        {
            Session["theme"] = "shop";
             HttpResponseMessage res = await client.GetAsync("api/cart/gethomepageproducts");
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var empresponse = "";
            List<Products> p=new List<Models.Products>();
           if (res.IsSuccessStatusCode)
            {
                empresponse = res.Content.ReadAsStringAsync().Result;
                p = JsonConvert.DeserializeObject<List<Products>>(empresponse);
            }
            var g = GetCart();
            return View(p);
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
            else if (CurrentAction == "/shop/exchange")
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

        [HttpGet]
        [Route("shop/products/{cat}")]
        public ActionResult DirectProducts(string cat)
        {
            List<Products> pp = new List<Models.Products>();
            Products p = new Products();
            string jsonString = System.IO.File.ReadAllText(Server.MapPath("~/js/data.js"));
            List<Products> plist = JsonConvert.DeserializeObject<List<Products>>(jsonString);
            plist = plist.Where(x => x.CategoryId == Convert.ToInt32(cat)).ToList();
            return View("products",plist);
        }

        [HttpGet]
        [Route("shop/Products")]
        public async Task<ActionResult> Products()
        {
            HttpResponseMessage res = await client.GetAsync("api/cart/getproducts");
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var empresponse = "";
            ProductViewModel p = new ProductViewModel();
            if (res.IsSuccessStatusCode)
            {
                empresponse = res.Content.ReadAsStringAsync().Result;
                p = JsonConvert.DeserializeObject<ProductViewModel>(empresponse);
            }
          
            return View(p);
         
        }
     
        [Authorize]
        public ActionResult Cart()
        {
            return View(GetCart());
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public async Task<ActionResult> ProductDetail(int id)
        {
            HttpResponseMessage res = await client.GetAsync("api/cart/getproductdetail?id="+id);
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var empresponse = "";
            ProductDetailModel p = new ProductDetailModel();
            if (res.IsSuccessStatusCode)
            {
                empresponse = res.Content.ReadAsStringAsync().Result;
                p = JsonConvert.DeserializeObject<ProductDetailModel>(empresponse);
            }

            return View(p);
         
        }

        public ShoppingCart GetCart()
        {
            ShoppingCart s;
            if (User.Identity.IsAuthenticated)
            {
                var user = UserManager.FindById(User.Identity.GetUserId());
                s = JsonConvert.DeserializeObject<ShoppingCart>(user.ShopCart);
                Session["ccount"] = s.Items.Count();
            }
            else
            {
                s = new ShoppingCart(); Session["ccount"] = 0;
            }
            return s;
        }
    }
}