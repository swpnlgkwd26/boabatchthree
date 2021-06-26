using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Models
{
    // Connect to dB
    public class ProductSQLRepository : IStoreRepository
    {
        private readonly BankOfAmericaBatchThreeContext _context;

        // Connect to dB context and ask him to perform the operations
        public ProductSQLRepository(BankOfAmericaBatchThreeContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> Products => _context.Products;

        public void AddProduct(Product product)
        {
            _context.Products.Add(product); // Add
            _context.SaveChanges();// Commit
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.Single(p => p.ProductID == id);// Find
            _context.Products.Remove(product);// Delete
            _context.SaveChanges();// Commit
            return true;
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Single(p => p.ProductID == id);
        }

        public void PerformTransaction()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                // 2 Operations
                try
                {
                    // 1. Entry into Sales Table
                    _context.Sales.Add(new Sale
                    {
                        ProductID = 2,
                        ProductName = "Samsung"
                    });
                    // 2. Reduce Quantity by -1 from Inventory
                    var inventory = _context.Inventories.Single(p => p.ProductID == 2);
                    inventory.Quantity = inventory.Quantity - 1;
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                

            }
        }

        public bool UpdateProduct(int id, Product product)
        {
            var productToUpdate = _context.Products.Single(x => x.ProductID == id); // Find

            // Update its properties with the new one
            productToUpdate.Name = product.Name; // Update
            productToUpdate.Price = product.Price;
            productToUpdate.Category = product.Category;
            productToUpdate.MfgDate = product.MfgDate;
            productToUpdate.Description = product.Description;
            _context.SaveChanges();// Commit

            return true;
        }
    }
}
