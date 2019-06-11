using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSklepPO
{
    interface IShopController 
    {
        
        void ChooseAction();

        void GetListOfShopProducts();

        void AddToCart();

        void DeleteFromCart();

        void AddToStorage();

        void DeleteFromStorage();

        void Checkout();

        
    }
}
