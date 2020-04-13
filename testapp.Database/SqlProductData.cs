using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using testapp.Core;

namespace testapp.Database
{
    public class SqlProductData : IProductData
    {
        private readonly testappDbContext db;

        public SqlProductData(testappDbContext db)
        {
            this.db = db;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }


        public Product Add(Product newProduct)
        {
            db.Add(newProduct);
            return newProduct;
        }

        public Product Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                db.Products.Remove(product);
            }
            return product;
        }

        public Product GetById(int id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            var query = from p in db.Products
                        where p.Manufacturer.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby p.Manufacturer
                        select p;
            return query;
        }

        public Product Update(Product updatedProduct)
        {
            var entity = db.Products.Attach(updatedProduct);
            entity.State = EntityState.Modified;
            return updatedProduct;
        }
    }
}
