using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Product
    {
        private string name;
        private double price;
        private int quantity;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        static Product()
        {
            Console.WriteLine("Статичний конструктор Product");
        }

        private Product(bool secret)
        {
            Console.WriteLine("Закритий конструктор Product");
        }

        public Product(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;

            Console.WriteLine("Конструктор з параметрами Product");
        }

        public Product(Product other)
        {
            name = other.name;
            price = other.price;
            quantity = other.quantity;

            Console.WriteLine("Конструктор копіювання Product");
        }

        public Product(string name) : this()
        {
            this.name = name;

            Console.WriteLine("Конструктор з викликом іншого конструктора Product");
        }

        public Product()
        {
            name = "Невідомий товар";
            price = 0;
            quantity = 0;

            Console.WriteLine("Конструктор без параметрів Product");
        }

        //3 версія - булефі функції
        public bool IsAvailable()
        {
            return quantity > 0;
        }

        public bool IsExpensive()
        {
            return price > 10000;
        }
        //3 версія - методи сценарію
        public bool CanBeAddedToCart()
        {
            if (IsAvailable())
            {
                Console.WriteLine("Товар є в наявності");
                return true;
            }

            Console.WriteLine("Товар відсутній");
            return false;
        }
        //

        //4 версія - перевантаження операторів
        //ex: product1+product2=value
        public static double operator +(Product firstProduct, Product secondProduct)
        {
            return firstProduct.price + secondProduct.price;
        }

        public static bool operator ==(Product firstProduct, Product secondProduct)
        {
            return firstProduct.price == secondProduct.price;
        }

        public static bool operator !=(Product firstProduct, Product secondProduct)
        {
            return firstProduct.price != secondProduct.price;
        }

        public static bool operator >(Product firstProduct, Product secondProduct)
        {
            return firstProduct.price > secondProduct.price;
        }

        public static bool operator <(Product firstProduct, Product secondProduct)
        {
            return firstProduct.price < secondProduct.price;
        }
        //


        public void ShowProductInfo()
        {
            Console.WriteLine($"Товар: {name}");
            Console.WriteLine($"Ціна: {price}");
            Console.WriteLine($"Кількість: {quantity}");
        }
    }
}
