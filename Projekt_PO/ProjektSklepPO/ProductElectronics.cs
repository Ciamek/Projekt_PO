using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSklepPO
{
    public class ProductElectronics : Product
    {
        string brand;

        

        public ProductElectronics(int id, string name, double price, string brand)
            {
            this.id = id;

            this.name = name;

            this.price = price;

            this.brand = brand;

            }

    }
}
