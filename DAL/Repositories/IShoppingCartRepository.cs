using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;
namespace DAL.Repositories
{
    public interface IShoppingCartRepository : IRepo<CartItem, int, bool>
    {
        void AddToCart(CartItem cartItem);
        ShoppingCart GetCartByCustomerId(int customerId);
        void UpdateCart(ShoppingCart cart);
        void ClearCart(int customerId);
    }
}
