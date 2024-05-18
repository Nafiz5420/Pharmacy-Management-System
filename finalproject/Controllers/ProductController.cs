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
    public class ProductController : ApiController
    {
        private readonly ProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }

        [HttpPost]
        [Route("api/product/add")]
        public IHttpActionResult AddProduct([FromBody] AddProductDTO addProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _productService.AddProduct(addProductDto);
                return Ok("Product added successfully");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/product/search")]
        public IHttpActionResult SearchProducts([FromUri] string searchTerm)
        {
            try
            {
                var products = _productService.SearchProducts(searchTerm);
                return Ok(products);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/product/{productId}")]
        public IHttpActionResult GetProductById(int productId)
        {
            try
            {
                var product = _productService.GetProductById(productId);
                return Ok(product);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return InternalServerError(ex);
            }
        }
    }
}