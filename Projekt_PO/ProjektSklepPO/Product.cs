using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSklepPO
{
    public abstract class Product : IProduct
    {
        protected string name;

        protected double price;

        protected int id;

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
            
        }
        public double GetPrice()
        {
            return price;
        }

        public void SetPrice(double price)
        {
            this.price = price;

        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public void ChangePrice(Product product)
        {

        }


    }
}
