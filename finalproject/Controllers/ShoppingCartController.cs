using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace finalproject.Controllers
{
    public class ShoppingCartController : ApiController
    {
        private readonly ShoppingCartService _shoppingCartService;

        public ShoppingCartController()
        {
            _shoppingCartService = new ShoppingCartService();
        }

        [HttpPost]
        [Route("api/cart/add")]
        public IHttpActionResult AddToCart([FromBody] AddToCartDTO addToCartDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _shoppingCartService.AddToCart(addToCartDto);
                return Ok("Product added to cart");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/cart/{customerId}")]
        public IHttpActionResult GetCartByCustomerId(int customerId)
        {
            try
            {
                var cart = _shoppingCartService.GetCartByCustomerId(customerId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/cart/checkout")]
        public IHttpActionResult Checkout([FromBody] CheckoutDTO checkoutDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _shoppingCartService.Checkout(checkoutDto);
                return Ok("Checkout successful");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return InternalServerError(ex);
            }
        }
    }
}
