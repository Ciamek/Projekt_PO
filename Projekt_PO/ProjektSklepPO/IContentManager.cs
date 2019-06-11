using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSklepPO
{
    interface IContentManager
    {
        void AddProduct(Product product);

        void DeleteProduct(Product product);

        List<Product> GetListOfProducts();

    }
}
