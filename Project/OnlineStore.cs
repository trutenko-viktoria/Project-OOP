using System;
using System.Collections.Generic;
using System.IO;

namespace Project
{
    internal class OnlineStore
    {
        private List<Product> products;
        private List<Order> orders;
        private Manager manager;

        public Manager Manager
        {
            get { return manager; }
            set { manager = value; }
        }

        public OnlineStore()
        {
            products = new List<Product>();
            orders = new List<Order>();
            manager = new Manager();

           // Console.WriteLine("Конструктор без параметрів OnlineStore");
        }

        public OnlineStore(List<Product> products, List<Order> orders, Manager manager)
        {
            this.products = products;
            this.orders = orders;
            this.manager = manager;

           // Console.WriteLine("Конструктор з параметрами OnlineStore");
        }

        public void OpenStore()
        {
            Console.WriteLine("Інтернет-магазин працює");
        }

        //3 версія
        //Предикатні методи
        public bool HasOrders()
        {
            return orders.Count > 0;
        }

        //Методи сценарію
        public void RegisterOrder(Order order)
        {
            if (order != null)
            {
                orders.Add(order);
                Console.WriteLine("Замовлення зареєстровано в системі магазину");
            }
            else
            {
                Console.WriteLine("Замовлення не створено");
            }
        }
        //

        //5 версія

        public void LoadProductsFromFile(string filePath)
        {
            products.Clear();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] data = line.Split(';');

                Product product = new Product(
                    data[0],
                    Convert.ToDouble(data[1]),
                    Convert.ToInt32(data[2]),
                    data[3],
                    data[4],
                    data[5]);

                products.Add(product);
            }

            Console.WriteLine("Каталог товарів завантажено з файлу");
        }

        //5
        public void SaveProductsToFile(string filePath)
        {
            List<string> lines = new List<string>();

            foreach (Product product in products)
            {
                string line =
                    $"{product.Name};" +
                    $"{product.Price};" +
                    $"{product.Quantity};" +
                    $"{product.Description};" +
                    $"{product.Size};" +
                    $"{product.Color}";

                lines.Add(line);
            }

            File.WriteAllLines(filePath, lines);

            Console.WriteLine("Каталог товарів оновлено");
        }

        public void ShowCatalog()
        {
            Console.WriteLine("===== Каталог товарів =====");

            for (int i = 0; i < products.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                products[i].ShowShortInfo();
            }

            Console.WriteLine();
        }

        //4 версія
        public void ShowProductDetails(int index)
        {
            if (index >= 0 && index < products.Count)
            {
                products[index].ShowProductInfo();
            }
            else
            {
                Console.WriteLine("Товар не знайдено");
            }
        }

        public Product GetProductByIndex(int index)
        {
            if (index >= 0 && index < products.Count)
            {
                return products[index];
            }

            return null;
        }
        //
    }
}
