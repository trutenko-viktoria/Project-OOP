using System;
using System.Collections.Generic;
using System.IO;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Налаштування кодування для коректного відображення української мови
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("ПІБ студента: Трутенко Вікторія Миколаївна");
            Console.WriteLine("Курс: 1 | Група: ІПЗ-11 | Варіант: 45");
            Console.WriteLine("=== Імітація роботи Інтернет-магазину (Версія 4-5-6) ===");
            Console.WriteLine();

            // 1. РЕЄСТРАЦІЯ КЛІЄНТА
            Console.WriteLine("----- Реєстрація клієнта -----");
            Console.Write("Введіть ім'я та прізвище: ");
            string clientName = Console.ReadLine();

            Console.Write("Введіть номер телефону: ");
            string phoneNumber = Console.ReadLine();

            Cart clientCart = new Cart(); // Створюємо пусту корзину для клієнта
            Client client = new Client(clientName, phoneNumber, clientCart);
            client.Register();
            client.ShowUserRole(); // Демонстрація V5 (Успадкування)

            // 2. ІНІЦІАЛІЗАЦІЯ МАГАЗИНУ ТА МЕНЕДЖЕРА
            Manager storeManager = new Manager("Максим", 4);
            storeManager.ShowUserRole(); // Демонстрація V5

            // Створюємо порожні списки, які заповняться з "бази даних" (файлу)
            List<Product> storeProducts = new List<Product>();
            List<Order> storeOrders = new List<Order>();

            OnlineStore store = new OnlineStore(storeProducts, storeOrders, storeManager);
            store.OpenStore();

            // Перевіряємо, чи існує файл бази даних, якщо ні — створюємо дефолтний
            string dbFile = "products.txt";
            if (!File.Exists(dbFile))
            {
                // Тимчасово створюємо файл, якщо його немає на диску, щоб програма не падала
                File.WriteAllLines(dbFile, new string[] {
                    "Худі;1200;5;Тепле oversize худі;M;Сірий",
                    "Сукня;1800;0;Чорна вечірня сукня;S;Чорний", // 0 штук для перевірки відсутності
                    "Джинси;1500;2;Широкі сині джинси;M;Синій"
                });
            }

            // Завантажуємо актуальний склад товарів з нашої "бази даних"
            store.LoadProductsFromFile(dbFile);

            // 3. ЦИКЛ ВИБОРУ ТОВАРІВ (ІНТЕРФЕЙС КОРИСТУВАЧА)
            string choice;
            do
            {
                store.ShowCatalog();
                Console.WriteLine("Введіть номер товару, щоб ДОДАТИ В КОШИК (наприклад: 1)");
                Console.WriteLine("Введіть номер з '+' для ПЕРЕГЛЯДУ ДЕТАЛЕЙ (наприклад: 1+)");
                Console.WriteLine("0 - Завершити покупки та перейти до оформлення");
                Console.Write("Ваш вибір: ");
                choice = Console.ReadLine();

                if (choice == "0") break;

                try
                {
                    if (choice.Contains("+"))
                    {
                        // Режим детальної інформації
                        string numberPart = choice.Replace("+", "").Trim();
                        int productIndex = Convert.ToInt32(numberPart) - 1;
                        store.ShowProductDetails(productIndex);
                    }
                    else
                    {
                        // Режим додавання в кошик
                        int productIndex = Convert.ToInt32(choice) - 1;
                        Product selectedProduct = store.GetProductByIndex(productIndex);

                        if (selectedProduct != null)
                        {
                            if (selectedProduct.IsAvailable())
                            {
                                // Використовуємо конструктор копіювання для створення товару в кошик (кількість = 1)
                                Product productForCart = new Product(selectedProduct);
                                productForCart.Quantity = 1;

                                client.AddToCart(productForCart);
                                selectedProduct.DecreaseQuantity(); // Зменшуємо на складі магазину

                                // Оновлюємо нашу текстову "базу даних", щоб зміни збереглися!
                                store.SaveProductsToFile(dbFile);
                            }
                            else
                            {
                                Console.WriteLine($"[Увага!] Товар '{selectedProduct.Name}' відсутній у наявності!");
                                store.Manager.ReplaceProduct(); // Менеджер пропонує заміну (подія за умовою)
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неправильний номер товару. Спробуйте ще раз.");
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Помилка введення даних. Очікується число або число з '+'.");
                }

                Console.WriteLine("\nНатисніть Enter для продовження...");
                Console.ReadLine();
                Console.Clear();

            } while (choice != "0");

            // 4. ОФОРМЛЕННЯ ЗАМОВЛЕННЯ ТА КОРЗИНА
            Console.Clear();
            client.Cart.CalculateTotalPrice();
            client.Cart.ShowCartInfo();

            if (client.Cart.IsEmpty())
            {
                Console.WriteLine("Ви нічого не купили. Імітацію завершено.");
                Console.WriteLine("Фініш імітації.");
                return;
            }

            // Перевіряємо роботу унарного оператора "true/false" з Версії 4
            if (client.Cart)
            {
                Console.WriteLine("[Оператор] Корзина має позитивний баланс.");
            }

            Console.WriteLine("\n----- Оформлення доставки та оплати -----");
            Console.Write("Введіть адресу доставки: ");
            string deliveryAddress = Console.ReadLine();

            Console.WriteLine("Виберіть спосіб оплати:");
            Console.WriteLine("1 - Карткою на сайті");
            Console.WriteLine("2 - Накладений платіж (при отриманні)");
            Console.Write("Ваш вибір: ");
            string paymentChoice = Console.ReadLine();

            string paymentType = (paymentChoice == "1") ? "Картка" : "Накладений платіж";
            Console.WriteLine($"Обрано спосіб: {paymentType}");

            // Створюємо об'єкт оплати
            Payment payment = new Payment(client.Cart.TotalPrice, false);
            if (paymentChoice == "1")
            {
                payment.Pay(); // Одразу оплачуємо
            }
            else
            {
                Console.WriteLine("[Оплата] Буде проведена при отриманні у відділенні.");
            }

            // Створюємо та запускаємо доставку
            Delivery delivery = new Delivery(deliveryAddress, "Оформлено");
            delivery.Deliver();

            // Створюємо замовлення
            Order order = new Order(202601, payment, delivery);
            order.ConfirmOrder();

            // Реєструємо замовлення в магазині та передаємо менеджеру в контроль
            store.RegisterOrder(order);
            store.Manager.ControlOrders();

            // 5. ЗБЕРЕЖЕННЯ ІСТОРІЇ КЛІЄНТА У ФАЙЛ
            string clientsFolder = "Clients";
            if (!Directory.Exists(clientsFolder))
            {
                Directory.CreateDirectory(clientsFolder);
            }

            string clientFileName = $"{client.FullName.Replace(" ", "_")}_history.txt";
            string clientFilePath = Path.Combine(clientsFolder, clientFileName);

            // Формуємо красивий чек для файлу історії покупця
            List<string> historyLines = new List<string>
            {
                $"=== ІСТОРІЯ ЗАМОВЛЕННЯ КЛІЄНТА ===",
                $"Клієнт: {client.FullName}",
                $"Телефон: {client.PhoneNumber}",
                $"Дата оформлення: {DateTime.Now}",
                $"---------------------------------",
                $"Товари в замовленні:"
            };

            foreach (var prod in client.Cart.Products)
            {
                historyLines.Add($"- {prod.Name} | {prod.Price} грн | {prod.Quantity} шт.");
            }

            historyLines.Add($"---------------------------------");
            historyLines.Add($"Загальна вартість: {client.Cart.TotalPrice} грн");
            historyLines.Add($"Спосіб оплати: {paymentType}");
            historyLines.Add($"Статус оплати: {(payment.IsPaid ? "Оплачено" : "Накладений платіж")}");
            historyLines.Add($"Номер ТТН доставки: {order.TrackingNumber}");
            historyLines.Add($"Адреса доставки: {delivery.Address}");
            historyLines.Add($"=================================");

            File.WriteAllLines(clientFilePath, historyLines);

            Console.WriteLine();
            Console.WriteLine($"[Успіх] Історію покупок клієнта збережено у файл: {clientFilePath}");
            Console.WriteLine("Замовлення успішно оброблено системою!");
            Console.WriteLine("Фініш імітації.");
            Console.ReadLine();
        }
    }
}