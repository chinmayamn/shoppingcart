using System.Collections.Generic;
using ecommerce.Models;

namespace ecommerce.Repository
{
    public interface ICartRepository
    {
        List<Category> FillCategory();
        List<Products> GetHomePageProducts();
    }
}
