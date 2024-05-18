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
    public class ShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;

        public ShoppingCartService()
        {
            _shoppingCartRepository = DataAccessFactory.ShoppingCartRepo();
            _productRepository = DataAccessFactory.ProductRepo();
        }

        public void AddToCart(AddToCartDTO addToCartDto)
        {
            var product = _productRepository.GetProductById(addToCartDto.ProductId);

            if (product == null || !product.Availability)
            {
                throw new System.Exception("Product not available.");
            }

            var cartItem = new CartItem
            {
                CustomerId = addToCartDto.CustomerId,
                ProductId = addToCartDto.ProductId,
                Quantity = addToCartDto.Quantity,
                Price = product.Price
            };

            _shoppingCartRepository.AddToCart(cartItem);
        }

        public ShoppingCartDTO GetCartByCustomerId(int customerId)
        {
            var cart = _shoppingCartRepository.GetCartByCustomerId(customerId);
            var cartDto = new ShoppingCartDTO
            {
                ShoppingCartId = cart.ShoppingCartId,
                CustomerId = cart.CustomerId,
                CartItems = cart.CartItems.Select(item => new CartItemDTO
                {
                    ProductId = item.ProductId,
                    ProductName = item.Product.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    TotalPrice = item.Quantity * item.Price
                }).ToList(),
                TotalAmount = cart.TotalAmount
            };

            return cartDto;
        }

        public void Checkout(CheckoutDTO checkoutDto)
        {
            var cart = _shoppingCartRepository.GetCartByCustomerId(checkoutDto.CustomerId);

            if (cart.CartItems.Count == 0)
            {
                throw new System.Exception("Cart is empty.");
            }

            // Implement payment processing and order placement here

            _shoppingCartRepository.ClearCart(checkoutDto.CustomerId);
        }
    }
}