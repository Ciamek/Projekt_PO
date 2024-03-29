﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSklepPO
{
    class ShopController : IShopController
    {
        //Magazyn
        private static Storage storage = new Storage();
        //Koszyk
        private static Cart cart = new Cart();
        //Rachunek
        private Checkout checkout = new Checkout(cart.GetListOfProducts());

        private char button;
        private int val;
        
        /// <summary>
        /// Podstawowe menu wyboru
        /// </summary>
        public void ChooseAction()
        {

                Console.WriteLine("Co chcesz zrobić ? \n" +
                                  "1. Zakupy \n" +
                                  "2. Zarządanie magazynem \n" +
                                  "3. Wyjście");


                //Pobiera wartość przycisku
                button = Console.ReadKey(true).KeyChar;
                val = (int)button - 48;

                switch (val)
                {
                    //Zakupy
                    case 1:
                        Console.Clear();
                        ShopChooseAction();
                    break;

                    //Zarzadzanie magazynem
                    case 2:
                        Console.Clear();
                    ChooseStorageAction();
                        break;

                    //Wyjście
                    case 3:
                    
                    break;

                    default:
                    ChooseAction();
                    break;
                }
        }


        /// <summary>
        /// Menu wyboru zakupowe
        /// </summary>
        public void ShopChooseAction()
        {


            Console.WriteLine("Co chcesz zrobić ? \n" +
                          "1. Dodaj do koszyka \n" +
                          "2. Usuń z koszyka   \n" +
                          "3. Zakończ zakupy   \n" +
                          "4. Powrót");

            button = Console.ReadKey(true).KeyChar;
            val = (int)button - 48;

            switch (val)
            {

                //Dodawanie produktu do koszyka
                case 1:
                    Console.Clear();
                    AddToCart();
                    ShopChooseAction();
                    break;

                //Usuwanie produktu z koszyka
                case 2:
                    Console.Clear();
                    DeleteFromCart();
                    ShopChooseAction();
                    break;

                //Podsumowanie rachunku
                case 3:
                    Console.Clear();
                    Checkout();

                    break;

                //Powrót
                case 4:
                    Console.Clear();
                    ChooseAction();
                    break;

                default:
                    ShopChooseAction();
                break;
            }

        }

        /// <summary>
        /// Rachunek
        /// </summary>
        public void Checkout()
        {
            
            Console.WriteLine("Lista produktów: \n");

            GetListOfCheckoutProducts();

            Console.WriteLine("\n Suma do zapłaty: " + checkout.GetSumPrice() +
                              "\n\n\n 1. Zapłać i wyjdź." +
                              "\n 2. Powrót do zakupów.");

            button = Console.ReadKey(true).KeyChar;
            val = (int)button - 48;

            switch (val)
            {
                case 1:
                    Console.Clear();


                    break;

                case 2:
                    Console.Clear();
                    ChooseAction();
                    break;
                default:
                    Checkout();
                break;
            }
        }

        /// <summary>
        /// Menu wyboru magazynu
        /// </summary>
        public void ChooseStorageAction()
        {
            Console.WriteLine("Co chcesz zrobić? \n" +
                              "1. Dodaj produkt do magazynu. \n" +
                              "2. Usuń produkt z magazynu \n" +
                              "3. Lista produktów w magazynie \n" +
                              "4. Zmień cenę produktów \n" +
                              "5. Powrót \n");

            button = Console.ReadKey(true).KeyChar;
            val = (int)button - 48;

            switch (val)
            {
                case 1:
                    AddToStorage();
                    Console.Clear();
                    ChooseStorageAction();
                    break;

                case 2:
                    DeleteFromStorage();
                    Console.Clear();
                    ChooseStorageAction();
                    break;

                case 3:
                    Console.Clear();
                    GetListOfStorageProducts();
                    break;

                case 4:
                    Console.Clear();
                    ChangePrice();
                    break;


                case 5:
                    Console.Clear();
                    ChooseAction();
                    break;
                default:
                    ChooseStorageAction();
                break;
            }
        }

        /// <summary>
        /// Metoda zmieniająca ceny
        /// </summary>
        private void ChangePrice()
        {
            Console.WriteLine("Wybierz produkt którego cenę chcesz zmienić:");

            GetListOfStorageProducts();

            Console.WriteLine("\n" + storage.GetListOfProducts().LongCount() + " Powrót");

            button = Console.ReadKey(true).KeyChar;
            val = (int)button - 48;

            if (val == storage.GetListOfProducts().LongCount())
            {
                Console.Clear();
                ChooseStorageAction();
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Podaj nową cenę:\n");
                int newPrice = int.Parse(Console.ReadLine());

                if (val < storage.GetListOfProducts().LongCount())
                {
                    storage.GetListOfProducts()[val].SetPrice(newPrice);

                }
                Console.Clear();
                ChangePrice();
            }
        }

        /// <summary>
        /// Wyświetla liste produktów w magazynie
        /// </summary>
        public void GetListOfStorageProducts()
        {
            foreach (Product product in storage.GetListOfProducts())
            {

                Console.WriteLine(storage.GetListOfProducts().IndexOf(product) + " " + product.GetName() + "  Cena: " + product.GetPrice());

            }
        }

        public void GetListOfCheckoutProducts()
        {
            foreach (Product product in checkout.GetListOfProducts())
            {

                Console.WriteLine(checkout.GetListOfProducts().IndexOf(product) + " " + product.GetName() + "  Cena: " + product.GetPrice());

            }
        }

        /// <summary>
        /// Wyświetla listę produktów w koszyku
        /// </summary>
        public void GetListOfCartProducts()
        {
            foreach (Product product in cart.GetListOfProducts())
            {

                Console.WriteLine(cart.GetListOfProducts().IndexOf(product) + " " + product.GetName() + "  Cena: " + product.GetPrice());

            }
        }

        /// <summary>
        /// Dodaje produkt do koszyka
        /// </summary>
        public void AddToCart()
        {
            Console.Clear();

            Console.WriteLine("Wybierz numer produktu:");
            Console.WriteLine("");

            GetListOfStorageProducts();

            button = Console.ReadKey(true).KeyChar;
            val = (int)button - 48;
            if (val < storage.GetListOfProducts().LongCount())
            {
                cart.AddProduct(storage.GetListOfProducts()[val]);
                storage.DeleteProduct(storage.GetListOfProducts()[val]);

            }
            GetListOfShopProducts();
        }

        /// <summary>
        /// Usuwa produkt z koszyka
        /// </summary>
        public void DeleteFromCart()
        {
            Console.Clear();

            Console.WriteLine("Wybierz numer produktu:");
            Console.WriteLine("");

            GetListOfCartProducts();

            button = Console.ReadKey(true).KeyChar;
            val = (int)button - 48;
            if (val < cart.GetListOfProducts().LongCount())
            {
                storage.AddProduct(cart.GetListOfProducts()[val]);
                cart.DeleteProduct(cart.GetListOfProducts()[val]);
            }
            GetListOfShopProducts();
        }

        /// <summary>
        /// Dodaje produkt do magazynu
        /// </summary>
        public void AddToStorage()
        {
            Console.Clear();

            Product product;

            Console.WriteLine("Wybierz kategorię \n" +
                      "1. Elektronika. \n" +
                      "2. Żywność. \n" +
                      "3. Ubrania. \n" +
                      "4. Powrót. \n");

            button = Console.ReadKey(true).KeyChar;
            val = (int)button - 48;

            switch (val)
            {
                //elektronika
                case 1:
                    Console.Clear();
                    Console.WriteLine("Podaj ID produktu:");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj nazwę produktu:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Podaj cenę produktu:");
                    double price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj markę produktu:");
                    string brand = Console.ReadLine();

                    product = new ProductElectronics(id, name, price, brand);

                    storage.AddProduct(product);
                    break;
                    //żywność
                case 2:
                    Console.Clear();
                    Console.WriteLine("Podaj ID produktu:");
                    id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj nazwę produktu:");
                    name = Console.ReadLine();
                    Console.WriteLine("Podaj cenę produktu:");
                    price = double.Parse(Console.ReadLine());

                    product = new ProductFood(id, name, price);

                    storage.AddProduct(product);
                    break;
                    //ubrania
                case 3:
                    Console.Clear();
                    Console.Clear();
                    Console.WriteLine("Podaj ID produktu:");
                    id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj nazwę produktu:");
                    name = Console.ReadLine();
                    Console.WriteLine("Podaj cenę produktu:");
                    price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj rozmiar produktu:");
                    string size = Console.ReadLine();
                    product = new ProductClothes(id, name, price, size);

                    storage.AddProduct(product);
                    break;

                    //powrót
                case 4:
                    Console.Clear();
                    ChooseAction();
                    break;

            }
        }

        /// <summary>
        /// Usuwa produkt z magazynu
        /// </summary>
        public void DeleteFromStorage()
        {
            Console.Clear();

            Console.WriteLine("Wybierz numer produktu:");
            Console.WriteLine("");

            GetListOfStorageProducts();

            button = Console.ReadKey(true).KeyChar;
            val = (int)button - 48;
            if (val < storage.GetListOfProducts().LongCount())
            {
                storage.DeleteProduct(storage.GetListOfProducts()[val]);
            }


        }

        /// <summary>
        /// Wyświetla listę produktów w koszyku i magazynie - stan sklepu
        /// </summary>
        public void GetListOfShopProducts()
        {
            Console.Clear();
            Console.WriteLine("Lista produktów w magazynie: \n");
            GetListOfStorageProducts();

            Console.WriteLine("\n \nKoszyk: \n");
            GetListOfCartProducts();

            double priceSum = 0;
            foreach (var product in cart.GetListOfProducts())
            {
                priceSum += product.GetPrice();
            }
            Console.WriteLine("\nSuma: " + priceSum + "\n \n");
        }


        

    }
}  

