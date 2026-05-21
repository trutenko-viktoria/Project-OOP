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

            Console.WriteLine("Реєстрація клієнта");

            Console.Write("Введіть ім'я та прізвище: ");
            string clientName = Console.ReadLine();

            Console.Write("Введіть номер телефону: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Введіть адресу доставки: ");
            string deliveryAddress = Console.ReadLine();

            Cart clientCart = new Cart();

            Client client = new Client(
                clientName,
                phoneNumber,
                clientCart);

            client.Register();

            //v5
            client.ShowUserRole();

            Console.WriteLine();

            List<Product> storeProducts = new List<Product>();

            storeProducts.Add(new Product("Худі", 1200, 5, "Тепле oversize худі", "M", "Сірий"));
            storeProducts.Add(new Product("Сукня", 1800, 3, "Чорна вечірня сукня", "S", "Чорний"));
            storeProducts.Add(new Product("Джинси", 1500, 2, "Широкі сині джинси", "M", "Синій"));

            List<Order> storeOrders = new List<Order>();
            Manager storeManager = new Manager("Максим", 5);

            //5
            storeManager.ShowUserRole();

            OnlineStore store = new OnlineStore(
                storeProducts,
                storeOrders,
                storeManager);

            store.OpenStore();

            string choice;

            do
            {
                Console.WriteLine();
                store.ShowCatalog();

                Console.WriteLine("Введіть номер товару для додавання в корзину");
                Console.WriteLine("або номер з + для повної інформації, наприклад 1+");
                Console.WriteLine("0 - завершити вибір товарів");

                choice = Console.ReadLine();

                if (choice == "0")
                {
                    break;
                }

                if (choice.Contains("+"))
                {
                    string numberPart = choice.Replace("+", "");
                    int productIndex = Convert.ToInt32(numberPart) - 1;

                    store.ShowProductDetails(productIndex);
                }
                else
                {
                    int productIndex = Convert.ToInt32(choice) - 1;

                    Product selectedProduct = store.GetProductByIndex(productIndex);

                    if (selectedProduct != null && selectedProduct.IsAvailable())
                    {
                        Product productForCart = new Product(
                            selectedProduct.Name,
                            selectedProduct.Price,
                            1,
                            selectedProduct.Description,
                            selectedProduct.Size,
                            selectedProduct.Color);

                        client.AddToCart(productForCart);
                        selectedProduct.DecreaseQuantity();
                    }
                    else
                    {
                        Console.WriteLine("Товар відсутній або вибрано неправильний номер");
                    }
                }

            } while (choice != "0");

            Console.WriteLine();

            client.Cart.CalculateTotalPrice();
            client.Cart.ShowCartInfo();

            Console.WriteLine();

            client.MakeOrder();

            Payment payment = new Payment(client.Cart.TotalPrice, false);
            payment.Pay();

            Delivery delivery = new Delivery(deliveryAddress, "оформлена");
            delivery.Deliver();

            Order order = new Order(101, payment, delivery);
            store.RegisterOrder(order);

            Console.WriteLine();

            Console.WriteLine("Замовлення успішно оформлено");
            Console.WriteLine("Фініш імітації");

            Console.WriteLine();
        }
    }
}