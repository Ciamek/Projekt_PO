using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSklepPO
{
    class Storage : IContentManager
    {

        private List<Product> storageList = new List<Product>();

        

        public Storage()
        {
            Product konsola = new ProductElectronics(1,"konsola PS4",1000,"sony");
            
            Product marchewka = new ProductFood(2,"marchewka", 2.5);
            

            Product spodnie = new ProductClothes(3, "buty", 120 , "42");

            Product jeansy = new ProductClothes(4, "spodnie", 220 ,"XL" );

            Product dresy = new ProductClothes(5, "kurtka" , 350, "M");
            
            storageList.Add(konsola);

            storageList.Add(marchewka);

            storageList.Add(spodnie);

            storageList.Add(jeansy);

            storageList.Add(dresy);

        }


        public void AddProduct(Product product)
        {
            storageList.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            storageList.Remove(product);
        }

        public List<Product> GetListOfProducts()
        {
            return storageList;
        }

        

    }
}
