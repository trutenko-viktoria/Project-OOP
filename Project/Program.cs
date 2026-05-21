using System;
using System.Collections.Generic;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("ПІБ студента: Трутенко Вікторія Миколаївна");
            Console.WriteLine("Курс: 1");
            Console.WriteLine("Група: ІПЗ-11");
            Console.WriteLine("Варіант: 45");
            Console.WriteLine("Версія 4");
            Console.WriteLine();

            Console.WriteLine("===== Інтернет-магазин одягу =====");
            Console.WriteLine();

            // Клієнт
            Cart clientCart = new Cart();

            Client client = new Client(
                "Трутенко Вікторія",
                "+380991112233",
                clientCart);

            client.Register();

            Console.WriteLine();

            // Каталог товарів
            List<Product> storeProducts = new List<Product>();

            storeProducts.Add(
                new Product(
                    "Худі",
                    1200,
                    5,
                    "Тепле oversize худі",
                    "M",
                    "Сірий"));

            storeProducts.Add(
                new Product(
                    "Сукня",
                    1800,
                    3,
                    "Чорна вечірня сукня",
                    "S",
                    "Чорний"));

            storeProducts.Add(
                new Product(
                    "Джинси",
                    1500,
                    2,
                    "Широкі сині джинси",
                    "M",
                    "Синій"));

            List<Order> storeOrders = new List<Order>();

            Manager storeManager = new Manager("Максим", 5);

            OnlineStore store = new OnlineStore(
                storeProducts,
                storeOrders,
                storeManager);

            store.OpenStore();

            Console.WriteLine();

            // Каталог
            store.ShowCatalog();

            Console.WriteLine("Введіть номер товару або номер з + для повної інформації:");

            string userChoice = Console.ReadLine();

            if (userChoice.Contains("+"))
            {
                string numberPart = userChoice.Replace("+", "");

                int productIndex = Convert.ToInt32(numberPart) - 1;

                store.ShowProductDetails(productIndex);
            }
            else
            {
                int productIndex = Convert.ToInt32(userChoice) - 1;

                Product selectedProduct = store.GetProductByIndex(productIndex);

                if (selectedProduct != null)
                {
                    client.AddToCart(selectedProduct);

                    client.Cart.CalculateTotalPrice();

                    Console.WriteLine();

                    client.Cart.ShowCartInfo();

                    Console.WriteLine();

                    client.MakeOrder();

                    Payment payment = new Payment(
                        client.Cart.TotalPrice,
                        false);

                    payment.Pay();

                    Delivery delivery = new Delivery(
                        "м. Київ, Нова пошта №5",
                        "оформлена");

                    delivery.Deliver();

                    Order order = new Order(
                        101,
                        payment,
                        delivery);

                    store.RegisterOrder(order);

                    Console.WriteLine();

                    Console.WriteLine("Замовлення успішно оформлено");
                }
            }

            Console.WriteLine();
        }
    }
}