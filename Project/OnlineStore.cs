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

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public List<Order> Orders
        {
            get { return orders; }
            set { orders = value; }
        }

        public Manager Manager
        {
            get { return manager; }
            set { manager = value; }
        }

        static OnlineStore()
        {
           // Console.WriteLine("Статичний конструктор OnlineStore");
        }

        private OnlineStore(bool isHidden)
        {
           // Console.WriteLine("Закритий конструктор OnlineStore");
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

        public OnlineStore(OnlineStore other)
        {
            products = new List<Product>(other.products);
            orders = new List<Order>(other.orders);
            manager = new Manager(other.manager);

           // Console.WriteLine("Конструктор копіювання OnlineStore");
        }

        public OnlineStore(Manager manager) : this()
        {
            this.manager = manager;

           // Console.WriteLine("Конструктор з викликом іншого конструктора OnlineStore");
        }

        public void OpenStore()
        {
            Console.WriteLine("Інтернет-магазин працює");
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine("Товар додано до магазину");
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
            Console.WriteLine("Замовлення додано до системи");
        }

        //3 версія
        //Предикатні методи
        public bool HasProducts()
        {
            return products.Count > 0;
        }

        public bool HasOrders()
        {
            return orders.Count > 0;
        }

        //Методи сценарію

        public Product FindProductByName(string productName)
        {
            foreach (Product product in products)
            {
                if (product.Name == productName)
                {
                    return product;
                }
            }

            return null;
        }

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

        public void ShowStoreInfo()
        {
            Console.WriteLine($"Кількість товарів: {products.Count}");
            Console.WriteLine($"Кількість замовлень: {orders.Count}");

            manager.ShowManagerInfo();
        }
    }
}
