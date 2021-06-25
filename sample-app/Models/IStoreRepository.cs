using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Models
{
    public interface IStoreRepository
    {
        IEnumerable<Product> Products { get; } // *
        Product GetProduct(int id); //  1
        void AddProduct(Product product); // Add 
        bool DeleteProduct(int id); // Delete Existin
        bool UpdateProduct(int id, Product product); // Update
    }
}
