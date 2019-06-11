using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSklepPO
{
    class Checkout : IContentManager
    {
        protected List<Product> productList;

        public Checkout(List<Product> productList)
        {
            this.productList = productList;
        }

        public double GetSumPrice()
        {
            double sum = 0;
            foreach (Product product in productList)
            {
                sum += product.GetPrice();
            }
            return sum;
        }

        public void AddProduct(Product product)
        {
            
        }

        public void DeleteProduct(Product product)
        {

        }

        public List<Product> GetListOfProducts()
        {
            return productList;
        }

    }
}
