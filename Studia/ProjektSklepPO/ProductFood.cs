using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSklepPO
{
    class ProductFood : Product
    {


        public ProductFood(int id, string name, double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            

        }
    }
}
