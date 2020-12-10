using System.Collections.Generic;
using ecommerce.Models;

namespace ecommerce.Repository
{
    public interface ICartUserApiRepository
    {
        List<Category> FillCategory();
        List<Products> GetHomePageProducts();
        ProductViewModel GetProducts();
        ProductDetailModel GetProductDetail(int id);
    }
}
