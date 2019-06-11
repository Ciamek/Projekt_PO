using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSklepPO
{
    class ProductClothes : Product
    {

        private string size;

        public ProductClothes(int id, string name, double price, string size)
        {
            this.id = id;

            this.name = name;

            this.price = price;

            this.size = size;
        }

        
    }
}
