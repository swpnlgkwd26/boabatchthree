using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.Models
{
    // Database :  Holds Temp DAta
    public class ProductInMemoryRepository : IStoreRepository
    {
        static List<Product> products = new List<Product>
        {
            new Product
            {
                ProductID=1,
                Name="Chess Board",
                Category="Chess",
                Description="Brown Chess Board",
                MfgDate =  DateTime.Now,
                Price=20.3m
            },
            new Product
            {
                ProductID=10,
                Name="Chess Board Black",
                Category="Chess",
                Description="Black Chess Board",
                MfgDate =  DateTime.Now,
                Price=20.3m
            },
             new Product
            {
                ProductID=2,
                 Name="Chess Notes",
                 Category="Chess",
                 Description="Chess Notes",
                 MfgDate =  DateTime.Now,
                 Price=210.3m
            },
              new Product
            {
                ProductID=3,
                  Name="Chess Timer",
                  Category="Chess"
                  ,Description="Chess Timer ",
                  MfgDate =  DateTime.Now
                  ,Price=10.3m
            },
            new Product
            {
                ProductID=4,Name="Ball",Category="Cricket"
                ,Description="Leather Ball",MfgDate =  DateTime.Now
                ,Price=20.3m
            },
            new Product
            {
                ProductID=15,Name="Ball Tennis",Category="Cricket"
                ,Description="TesnnisBall",MfgDate =  DateTime.Now
                ,Price=20.3m
            },
             new Product
            {
                ProductID=5,Name="Bat",MfgDate =  DateTime.Now,
                 Category="Cricket",Description="Bat with Sticket",Price=210.3m
            },
              new Product
            {
                ProductID=6,
                  Name="Stumps",
                  Category="Cricket",MfgDate =  DateTime.Now
                  ,Description="3 Stumps Along with bails"
                  ,Price=10.3m
            },
            new Product
            {
                ProductID=7,Name="Soccer Ball",Category="Soccer"
                ,Description="Soccer Ball",MfgDate =  DateTime.Now
                ,Price=20.3m
            },
             new Product
            {
                ProductID=8,Name="Soccer Cards",MfgDate =  DateTime.Now,
                 Category="Soccer",Description="Soccer Cards",Price=210.3m
            },
              new Product
            {
                ProductID=9,
                  Name="Net",
                  Category="Soccer",MfgDate =  DateTime.Now
                  ,Description="Soccer Net"
                  ,Price=10.3m
            },
        };
        public IEnumerable<Product> Products =>
           products;

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public bool DeleteProduct(int id)
        {
            // Find the Product to be deleted
            var product = products.Single(x => x.ProductID == id);
            // Pass the product to collection to delete
            products.Remove(product);
            return true;
        }

        public Product GetProduct(int id)
        {
            var product = products.Single(x => x.ProductID == id);
            return product;
        }

        public void PerformTransaction()
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(int id, Product product)
        {
            // Find the product to update
            var productToUpdate = products.Single(x => x.ProductID == id);

            // Update its properties with the new one
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            productToUpdate.Category = product.Category;
            productToUpdate.MfgDate = product.MfgDate;
            productToUpdate.Description = product.Description;

            return true;
        }
    }
}
