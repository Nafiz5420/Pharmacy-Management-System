using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
namespace DAL.Repositories
{
    public interface IProductRepository : IRepo<Product, int, bool>
    {
        bool AddProduct(Product product);
        List<Product> SearchProducts(string searchTerm);
        Product GetProductById(int productId);
    }
}
