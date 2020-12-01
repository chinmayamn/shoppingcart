﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ecommerce.Models;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using System.Data;
using ecommerce.Repository;

namespace ecommerce.Controllers
{  
   // [Authorize]
    [RoutePrefix("api/cart")]
    public class CartController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        Category c;
        DataTable dt;
        private readonly ICartRepository _cartRepository;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
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
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //public CartController()
        //{
        
        //}

        public CartController(ICartRepository cartRepo)
        {
            _cartRepository = cartRepo;
        }
        [HttpGet]
        public string GetCart()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return user.ShopCart;
        }

        [HttpPost]
        [Route("AddItemtoCart")]
        public string AddItemtoCart(object s)
        {
            CartItem c = JsonConvert.DeserializeObject<CartItem>(s.ToString());
            var user = UserManager.FindById(User.Identity.GetUserId());
            ShoppingCart s1;
            if(user.ShopCart !=null)
            {
                 s1 = JsonConvert.DeserializeObject<ShoppingCart>(user.ShopCart);
                
            }
            else
            {
                 s1 = new ShoppingCart();
            }
           
            s1.Insert(c.ProductId, c.ProductName, c.ProductImageUrl, c.price, c.quantity, c.discount); 
            user.ShopCart = JsonConvert.SerializeObject(s1);
            UserManager.Update(user);
            return "success";
        }

        [HttpGet]
        [Route("singleitemadd")]
        public HttpResponseMessage AddSingleItem(int? id)
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            ShoppingCart s1;
            if (user.ShopCart != null)
            {
                s1 = JsonConvert.DeserializeObject<ShoppingCart>(user.ShopCart);

            }
            else
            {
                s1 = new ShoppingCart();
            }
            List<Products> pp = new List<Models.Products>();
            Products p = new Products();
            string jsonString = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/js/data.js"));
            List<Products> plist = JsonConvert.DeserializeObject<List<Products>>(jsonString);
            p = plist.Find(x => x.Id == Convert.ToInt32(id));

            s1.Insert(p.Id, p.ProductName, p.Image, p.ActualPrice,1, p.Discount);
            user.ShopCart = JsonConvert.SerializeObject(s1);
            UserManager.Update(user);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK,"success");
            return response;
        }

        [HttpPost]
        [Route("QuantityUpdate")]
        public string IncrementQty(object s)
        {
            CartItem c = JsonConvert.DeserializeObject<CartItem>(s.ToString());
            var user = UserManager.FindById(User.Identity.GetUserId());
            ShoppingCart s1; 
            if (user.ShopCart != null)
            {
                s1 = JsonConvert.DeserializeObject<ShoppingCart>(user.ShopCart);

            }
            else
            {
                s1 = new ShoppingCart();
            }

            s1.QuantityUpdate(c.RowId, c.ProductId, c.quantity);
            user.ShopCart = JsonConvert.SerializeObject(s1);
            UserManager.Update(user);
            return user.ShopCart;
        }

        [HttpPost]
        [Route("DeleteItem")]
        public string DeleteItem(object s)
        {
            CartItem c = JsonConvert.DeserializeObject<CartItem>(s.ToString());
            var user = UserManager.FindById(User.Identity.GetUserId());
            ShoppingCart s1;
            if (user.ShopCart != null)
            {
                s1 = JsonConvert.DeserializeObject<ShoppingCart>(user.ShopCart);

            }
            else
            {
                s1 = new ShoppingCart();
            }
            int search_row_id = s1.Items.FindIndex(m=>m.ProductId == c.ProductId); //get row id by product id and delete it from list
            s1.DeleteItem(search_row_id);
            user.ShopCart = JsonConvert.SerializeObject(s1);
            UserManager.Update(user);
            return user.ShopCart;
        }

        [HttpGet]
        [Route("fillcategory")]
        public HttpResponseMessage FillCategory()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _cartRepository.FillCategory());
        }

        [HttpGet]
        [Route("GetHomePageProducts")]
        public HttpResponseMessage GetHomePageProducts()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _cartRepository.GetHomePageProducts());
        }

    }
}
