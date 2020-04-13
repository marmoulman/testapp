using System;
using System.Collections.Generic;
using System.Text;
using testapp.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace testapp.Database
{
    public class SqlProductAttributesData : IProductAttributesData
    {
        private readonly testappDbContext db;

        public SqlProductAttributesData(testappDbContext db)
        {
            this.db = db;
        }


        public ProductAttributes Add(ProductAttributes newProductAttributes)
        {
            db.Add(newProductAttributes);
            return newProductAttributes;
        }

        public IEnumerable<Core.Attribute> AttributesByProduct(int productId)
        {
            var query = from pa in db.ProductAttributes
                        join a in db.Attributes on pa.AttributeId equals a.Id
                        where pa.ProductId == productId
                        select a;
            return query;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public ProductAttributes Delete(int id)
        {
            var productattributes = GetById(id);
            if(productattributes != null)
            {
                db.Remove(productattributes);
            }
            return productattributes;
        }

        public int DeleteProduct(int productId)
        {
            db.Database.ExecuteSqlCommand("DELETE FROM ProductAttributes WHERE productId = @p0", productId);
            return productId;
        }

        public int DeleteAttribute(int attributeId)
        {
            db.Database.ExecuteSqlCommand("DELETE FROM ProductAttributes WHERE attributeId = @p0", attributeId);
            return attributeId;
        }

        public ProductAttributes GetById(int id)
        {
            return db.ProductAttributes.Find(id);
        }

        public IEnumerable<Product> ProductsByAttribute(int AttributeId)
        {
            var query = from pa in db.ProductAttributes
                        join p in db.Products on pa.ProductId equals p.Id
                        where pa.AttributeId == AttributeId
                        select p;
            return query;
        }

        public ProductAttributes Update(ProductAttributes updatedProductAttributes)
        {
            var entity = db.ProductAttributes.Attach(updatedProductAttributes);
            entity.State = EntityState.Modified;
            return updatedProductAttributes;
        }

        public bool GetByProductIdAndAttributeId(int AttributeId, int ProductId)
        {
            var query = from pa in db.ProductAttributes
                        where pa.AttributeId == AttributeId && pa.ProductId == ProductId
                        select pa;
            if (!query.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
