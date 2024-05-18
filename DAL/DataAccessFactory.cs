using DAL.Repositories;
using DAL.Interfaces;
using DAL.Models;

namespace DAL
{
    public static class DataAccessFactory
    {
        public static ICustomerRepository CustomerData()
        {
            return new CustomerRepository();
        }



        public static IRepo<Product, int, bool> ProductData()
        {
            return new ProductRepository();
        }

        public static IRepo<CartItem, int, bool> ShoppingCartData()
        {
            return new ShoppingCartRepository();
        }

        public static IProductRepository ProductRepo()
        {
            return new ProductRepository();
        }

        public static IShoppingCartRepository ShoppingCartRepo()
        {
            return new ShoppingCartRepository();
        }
    }
}
