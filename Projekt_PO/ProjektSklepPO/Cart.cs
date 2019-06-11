using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSklepPO
{
    class Cart : IContentManager
    {
        private List<Product> cartList = new List<Product>();


        public void AddProduct(Product product)
        {
            cartList.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            cartList.Remove(product);
        }

        public List<Product> GetListOfProducts()
        {
            return cartList;
        }
    }
}
