using System;
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
using System.Web.Http.Owin;
using Newtonsoft.Json;
using System.Web.Http.Routing;

namespace ecommerce.Controllers
{
    [Authorize]
    [RoutePrefix("api/cart")]
    public class CartController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

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



        }
}
