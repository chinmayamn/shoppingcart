using System;
using System.Collections.Generic;
using System.Linq;
using ecommerce.Models;
using System.Data;
using Newtonsoft.Json;
namespace ecommerce.Repository
{
    public class CartRepository:ICartRepository
    {
        Category c;
        DataTable dt;
        Products p = new Products();
        List<Products> mm =new List<Models.Products>();
        admin ad;
        ProductViewModel pvm;
        
        public List<Category> FillCategory()
        {
            c = new Category();
            dt = c.fillcategory();
            List<Category> l = (from DataRow row in dt.Rows
                                select new Category
                                {
                                    Id = Convert.ToInt32(row["id"]),
                                    CategoryName = row["category"].ToString(),
                                    Parentid = Convert.ToInt32(row["parentid"] == DBNull.Value ? 0 : row["parentid"]),
                                    Visible = Convert.ToInt32(row["visible"])
                                }).ToList();
            return l;
        }

        public List<Products> GetHomePageProducts()
        {
            ad = new admin();
            dt = ad.GetHomePageProducts(8);
            List<Products> p = (from DataRow row in dt.Rows
                                select new Products
                                {
                                    Id = Convert.ToInt32(row["id"]),
                                    ProductName = row["pname"].ToString(),
                                    Image = row["image"].ToString(),
                                    ActualPrice = Convert.ToInt32(row["actual"]),
                                    Details=row["details"].ToString(),
                                    CategoryId = Convert.ToInt32(row["cid"])
                                }).Take(8).ToList();
            return p;
        }

        public ProductViewModel GetProducts()
        {
            pvm = new ProductViewModel();
            dt = new DataTable();
            pvm.CategoryList = FillCategory();
            dt = p.getproducts();
            pvm.ProductsList = (from DataRow row in dt.Rows
                                select new Products
                                {
                                    Id = Convert.ToInt32(row["id"]),
                                    ProductName = row["pname"].ToString(),
                                    Image = row["image"].ToString(),
                                    ActualPrice = Convert.ToInt32(row["actual"]),
                                    Details = row["details"].ToString(),
                                    CategoryId = Convert.ToInt32(row["cid"])
                                }).ToList();
            return pvm;
        }

        public ProductDetailModel GetProductDetail(int id)
        {
            ad = new admin();
            ProductDetailModel pdm = new ProductDetailModel();
            dt = ad.getproductsbyid(id);
            pdm.productdetail = (from DataRow row in dt.Rows
                                 select new Products
                                 {
                                     Id = Convert.ToInt32(row["id"]),
                                     ProductName = row["pname"].ToString(),
                                     Image = row["image"].ToString(),
                                     ActualPrice = Convert.ToInt32(row["actual"]),
                                     Details = row["details"].ToString(),
                                     CategoryId = Convert.ToInt32(row["cid"])
                                 }).First();
            return pdm;
        }

       
    }
}