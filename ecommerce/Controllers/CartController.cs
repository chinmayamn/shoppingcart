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
using System.Data;

namespace ecommerce.Controllers
{
    //[Authorize]
    
    [RoutePrefix("api/cart")]
    public class CartController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        Category c;
        DataTable dt;

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
            List<Product> pp = new List<Models.Product>();
            Product p = new Product();
            string jsonString = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/js/data.js"));
            List<Product> plist = JsonConvert.DeserializeObject<List<Product>>(jsonString);
            p = plist.Find(x => x.Id == Convert.ToInt32(id));

            s1.Insert(p.Id, p.Name, p.Image, p.Price,1, p.Discount);
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
            c = new Category();
            dt = c.fillcategory();
            List<Category> l = (from DataRow row in dt.Rows select new Category {
                Id = Convert.ToInt32(row["id"]),
                CategoryName = row["category"].ToString(),
                Parentid = Convert.ToInt32(row["parentid"]==DBNull.Value ? 0 :row["parentid"]),
                Visible =Convert.ToInt32(row["visible"])
            }).ToList();
                
                return Request.CreateResponse(HttpStatusCode.OK, l);
        }


    }
}
