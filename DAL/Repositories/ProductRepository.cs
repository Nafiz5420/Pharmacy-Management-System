using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Interfaces;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class ProductRepository : IRepo<Product, int, bool>, IProductRepository
    {
        private readonly PharmacyContext _context;

        public ProductRepository()
        {
            _context = new PharmacyContext();
        }

        public bool Create(Product entity)
        {
            _context.Products.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public Product Read(int id)
        {
            return _context.Products.SingleOrDefault(p => p.ProductId == id);
        }

        public IEnumerable<Product> ReadAll()
        {
            return _context.Products.ToList();
        }

        public bool Update(Product entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public List<Product> SearchProducts(string searchTerm)
        {
            return _context.Products
                .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
                .ToList();
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.SingleOrDefault(p => p.ProductId == productId);
        }

        public bool AddProduct(Product product)
        {
            _context.Products.Add(product);
            return _context.SaveChanges() > 0;
        }
    }
}