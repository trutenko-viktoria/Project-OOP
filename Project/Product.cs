using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Product : IShowInfo
    {
        private string name;
        private double price;
        private int quantity;

        private string description;
        private string size;
        private string color;

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

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        static Product()
        {
           // Console.WriteLine("Статичний конструктор Product");
        }

        private Product(bool secret)
        {
          //  Console.WriteLine("Закритий конструктор Product");
        }

        public Product(string name,
    double price,
    int quantity,
    string description,
    string size,
    string color)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;

            this.description = description;
            this.size = size;
            this.color = color;

           // Console.WriteLine("Конструктор з параметрами Product");
        }

        //ТИМЧАСОВА ШТУКА ДЛЯ КОМПІЛЯЦІЇ БО ВИРІШЕНО РОБИТИ КАТАЛОГ В TXT
        public Product(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;

            description = "Опис відсутній";
            size = "Не вказано";
            color = "Не вказано";

           // Console.WriteLine("Конструктор з параметрами Product");
        }

        public Product(Product other)
        {
            name = other.name;
            price = other.price;
            quantity = other.quantity;

            description = other.description;
            size = other.size;
            color = other.color;

           // Console.WriteLine("Конструктор копіювання Product");
        }

        public Product(string name) : this()
        {
            this.name = name;

           // Console.WriteLine("Конструктор з викликом іншого конструктора Product");
        }

        public Product()
        {
            name = "Невідомий товар";
            price = 0;
            quantity = 0;

            description = "Опис відсутній";
            size = "Не вказано";
            color = "Не вказано";

          //  Console.WriteLine("Конструктор без параметрів Product");
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
            if (ReferenceEquals(firstProduct, secondProduct))
            {
                return true;
            }

            if (firstProduct is null || secondProduct is null)
            {
                return false;
            }

            return firstProduct.price == secondProduct.price;
        }

        public static bool operator !=(Product firstProduct, Product secondProduct)
        {
            return !(firstProduct == secondProduct);
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

        public void ShowShortInfo() //коротка інфа для швидкого огляду асортименту
        {
            Console.WriteLine($"{name} - {price} грн");
        }

        public void DecreaseQuantity() //зменшення кількості "в наявності"
        {
            if (quantity > 0)
            {
                quantity--;
                Console.WriteLine("Кількість товару на складі зменшено");
            }
            else
            {
                Console.WriteLine("Товар відсутній на складі");
            }
        }

        //v5
        public void ShowInfo()
        {
            ShowProductInfo();
        }

        public void ShowProductInfo()
        {
            Console.WriteLine($"Назва: {name}");
            Console.WriteLine($"Опис: {description}");
            Console.WriteLine($"Розмір: {size}");
            Console.WriteLine($"Колір: {color}");
            Console.WriteLine($"Ціна: {price} грн");
            Console.WriteLine($"Кількість: {quantity}");
        }
    }
}
