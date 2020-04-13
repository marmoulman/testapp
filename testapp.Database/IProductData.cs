using System.Collections.Generic;
using testapp.Core;

namespace testapp.Database
{

    public interface IProductData
    {
        IEnumerable<Product> GetProductsByName(string name);
        Product GetById(int id);
        Product Update(Product updatedProduct);
        Product Add(Product newProduct);
        Product Delete(int id);
        int Commit();
    }


}
