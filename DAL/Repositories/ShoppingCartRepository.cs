using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
namespace DAL.Repositories
{
    public class ShoppingCartRepository : IRepo<CartItem, int, bool>, IShoppingCartRepository
    {
        private readonly PharmacyContext _context;

        public ShoppingCartRepository()
        {
            _context = new PharmacyContext();
        }

        public bool Create(CartItem entity)
        {
            var existingItem = _context.CartItems
                .SingleOrDefault(c => c.CustomerId == entity.CustomerId && c.ProductId == entity.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += entity.Quantity;
                _context.Entry(existingItem).State = EntityState.Modified;
            }
            else
            {
                _context.CartItems.Add(entity);
            }

            return _context.SaveChanges() > 0;
        }

        public CartItem Read(int id)
        {
            return _context.CartItems.SingleOrDefault(c => c.CartItemId == id);
        }

        public IEnumerable<CartItem> ReadAll()
        {
            return _context.CartItems.ToList();
        }

        public bool Update(CartItem entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var cartItem = _context.CartItems.Find(id);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public void AddToCart(CartItem cartItem)
        {
            var existingItem = _context.CartItems
                .SingleOrDefault(c => c.CustomerId == cartItem.CustomerId && c.ProductId == cartItem.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += cartItem.Quantity;
                _context.Entry(existingItem).State = EntityState.Modified;
            }
            else
            {
                _context.CartItems.Add(cartItem);
            }

            _context.SaveChanges();
        }

        public ShoppingCart GetCartByCustomerId(int customerId)
        {
            var cart = new ShoppingCart
            {
                CustomerId = customerId,
                CartItems = _context.CartItems
                    .Where(c => c.CustomerId == customerId)
                    .ToList()
            };

            cart.TotalAmount = cart.CartItems.Sum(c => c.Quantity * c.Price);

            return cart;
        }

        public void UpdateCart(ShoppingCart cart)
        {
            foreach (var item in cart.CartItems)
            {
                _context.Entry(item).State = EntityState.Modified;
            }

            _context.SaveChanges();
        }

        public void ClearCart(int customerId)
        {
            var cartItems = _context.CartItems.Where(c => c.CustomerId == customerId).ToList();
            _context.CartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }
    }
}
