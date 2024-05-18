using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;
using DAL;
using DAL.Models;
using DAL.Repositories;
namespace BLL.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = DataAccessFactory.ProductRepo();
        }

        public void AddProduct(AddProductDTO addProductDto)
        {
            var product = new Product
            {
                Name = addProductDto.Name,
                Description = addProductDto.Description,
                Price = addProductDto.Price,
                Availability = addProductDto.Availability
            };

            _productRepository.AddProduct(product);
        }

        public List<ProductDTO> SearchProducts(string searchTerm)
        {
            var products = _productRepository.SearchProducts(searchTerm);
            var productDtos = new List<ProductDTO>();

            foreach (var product in products)
            {
                productDtos.Add(new ProductDTO
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Availability = product.Availability
                });
            }

            return productDtos;
        }

        public ProductDTO GetProductById(int productId)
        {
            var product = _productRepository.GetProductById(productId);

            if (product == null)
            {
                throw new System.Exception("Product not found.");
            }

            return new ProductDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Availability = product.Availability
            };
        }
    }
}