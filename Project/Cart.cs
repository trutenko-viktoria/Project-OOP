using System;
using System.Collections.Generic;

namespace Project
{
    internal class Cart
    {
        private List<Product> products;
        private double totalPrice;

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public double TotalPrice
        {
            get { return totalPrice; }
            private set { totalPrice = value; }
        }

        static Cart()
        {
            Console.WriteLine("Статичний конструктор Cart");
        }

        private Cart(bool isHidden)
        {
            Console.WriteLine("Закритий конструктор Cart");
        }

        public Cart()
        {
            products = new List<Product>();
            totalPrice = 0;

            Console.WriteLine("Конструктор без параметрів Cart");
        }

        public Cart(List<Product> products, double totalPrice)
        {
            this.products = products;
            this.totalPrice = totalPrice;

            Console.WriteLine("Конструктор з параметрами Cart");
        }

        public Cart(Cart other)
        {
            products = new List<Product>(other.products);
            totalPrice = other.totalPrice;

            Console.WriteLine("Конструктор копіювання Cart");
        }

        public Cart(List<Product> products) : this()
        {
            this.products = products;

            Console.WriteLine("Конструктор з викликом іншого конструктора Cart");
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine("Товар додано у корзину");
        }

        public void CalculateTotalPrice()
        {
            totalPrice = 0;

            foreach (Product product in products)
            {
                totalPrice += product.Price * product.Quantity;
            }

            Console.WriteLine($"Загальна вартість корзини: {totalPrice}");
        }

        // 3 версія
        public bool IsEmpty()
        {
            return products.Count == 0;
        }

        public bool HasExpensiveTotal()
        {
            return totalPrice > 20000;
        }
        //

        //3 версія - методи сценарію
        public bool CanCreateOrder()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Замовлення неможливо оформити, бо корзина порожня");
                return false;
            }

            Console.WriteLine("Корзина не порожня, замовлення можна оформити");
            return true;
        }
        //

        //4 версія - оператори
        //ex: збільшує прайс
        public static Cart operator ++(Cart cart)
        {
            cart.totalPrice += 100;

            return cart;
        }
        public static Cart operator --(Cart cart)
        {
            cart.totalPrice -= 100;

            return cart;
        }

        public static bool operator true(Cart cart)
        {
            return cart.totalPrice > 0;
        }

        public static bool operator false(Cart cart)
        {
            return cart.totalPrice <= 0;
        }
        //


        public void ShowCartInfo()
        {
            Console.WriteLine($"Кількість товарів у корзині: {products.Count}");
            Console.WriteLine($"Загальна вартість: {totalPrice}");
        }
    }
}
