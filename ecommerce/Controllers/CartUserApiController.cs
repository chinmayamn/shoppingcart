using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using ecommerce.Repository;

namespace ecommerce.Controllers
{
    [RoutePrefix("api/cart")]
    public class CartUserApiController : ApiController
    {
        private readonly ICartUserApiRepository _cartUserApiRepository;

        public CartUserApiController(ICartUserApiRepository cartUserApiRepository)
        {
           this._cartUserApiRepository = cartUserApiRepository;
        }

        [HttpGet]
        [Route("fillcategory")]
        public HttpResponseMessage FillCategory()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _cartUserApiRepository.FillCategory());
        }

        [HttpGet]
        [Route("GetHomePageProducts")]
        public HttpResponseMessage GetHomePageProducts()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _cartUserApiRepository.GetHomePageProducts());
        }

        [HttpGet]
        [Route("GetProducts")]
        public HttpResponseMessage GetProducts()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _cartUserApiRepository.GetProducts());
        }

        [HttpGet]
        [Route("GetProductDetail")]
        public HttpResponseMessage GetProductDetail(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _cartUserApiRepository.GetProductDetail(id));
        }
    }
}
