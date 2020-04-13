using System;
using System.Collections.Generic;
using System.Text;
using testapp.Core;

namespace testapp.Database
{
    public interface IProductAttributesData
    {
        IEnumerable<Product> ProductsByAttribute(int attributeId);
        IEnumerable<Core.Attribute> AttributesByProduct(int productId);
        ProductAttributes GetById(int id);
        bool GetByProductIdAndAttributeId(int attributeId, int productId);
        ProductAttributes Update(ProductAttributes updatedProductAttributes);
        ProductAttributes Add(ProductAttributes newProductAttributes);
        ProductAttributes Delete(int id);
        int DeleteProduct(int productId);
        int DeleteAttribute(int attributeId);
        int Commit();
    }
}
