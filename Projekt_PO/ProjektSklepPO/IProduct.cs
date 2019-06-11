using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSklepPO
{
    interface IProduct
    {

        string GetName();

        void SetName(string name);

        double GetPrice();

        void SetPrice(double price);

        int GetId();

        void SetId(int id);

        void ChangePrice(Product product);


    }
}
