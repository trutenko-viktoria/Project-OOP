using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json; // підключаю для роботи з json конфігом

namespace Project
{
    internal class Program
    {
        // повна моделька для зчитування нашого конфігу
       
        static string dbFile = "products.txt";
        static OnlineStore store;
        static Client client;
        public static AppConfig config;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // виклик методу завантаження json
            if (!LoadConfig())
            {
                Console.ReadLine();
                return;
            }

            ShowStudentInfo();

            // РЕЄСТРАЦІЯ КЛІЄНТА
            RegisterNewClient();

            // ІНІЦІАЛІЗАЦІЯ МАГАЗИНУ ТА МЕНЕДЖЕРА
            InitializeStore();

            // ЦИКЛ ВИБОРУ ТОВАРІВ (ІНТЕРФЕЙС КОРИСТУВАЧА)
            ShoppingLoop();

            // ОФОРМЛЕННЯ ЗАМОВЛЕННЯ ТА КОРЗИНА
            ProcessOrderAndCheckout();
        }

        // читаємо json без будь-яких дефолтних значень
        static bool LoadConfig()
        {
            string jsonPath = "config.json";
            if (File.Exists(jsonPath))
            {
                string jsonString = File.ReadAllText(jsonPath);
                config = JsonSerializer.Deserialize<AppConfig>(jsonString);
                return true;
            }
            else
            {
                Console.WriteLine("Критична помилка: Файл конфігурації config.json не знайдено!");
                return false;
            }
        }

        static void ShowStudentInfo()
        {
            Console.WriteLine("ПІБ студента: Трутенко Вікторія Миколаївна");
            Console.WriteLine("Курс: 1 | Група: ІПЗ-11 | Варіант: 45");
            Console.WriteLine(config.WelcomeMessage);
            Console.WriteLine();
        }

        static void RegisterNewClient()
        {
            Console.WriteLine(config.RegHeader);
            Console.Write(config.AskName);
            string clientName = Console.ReadLine();

            Console.Write(config.AskPhone);
            string phoneNumber = Console.ReadLine();

            Cart clientCart = new Cart(); // Створюємо пусту корзину для клієнта
            client = new Client(clientName, phoneNumber, clientCart);
            client.Register();
            client.ShowUserRole(); // Демонстрація V5 (Успадкування)
        }

        static void InitializeStore()
        {
            Manager storeManager = new Manager("Максим", 4);
            storeManager.ShowUserRole(); // Демонстрація V5

            // Створюємо порожні списки, які заповняться з "бази даних" (файлу)
            List<Product> storeProducts = new List<Product>();
            List<Order> storeOrders = new List<Order>();

            store = new OnlineStore(storeProducts, storeOrders, storeManager);
            store.OpenStore();

            // Завантажуємо актуальний склад товарів з нашої "бази даних"
            store.LoadProductsFromFile(dbFile);
        }

        // меню виводиться одним форечем
        static void ShowMenuFromFile()
        {
            foreach (string line in config.MenuLines)
            {
                Console.WriteLine(line);
            }
        }

        // розбили великий метод: цей тепер тільки крутить цикл і читає те, що ввели
        static void ShoppingLoop()
        {
            string choice;
            do
            {
                store.ShowCatalog();
                ShowMenuFromFile();
                Console.Write(config.EnterChoice);
                choice = Console.ReadLine();

                if (choice == "0") break;

                // передаємо те, що ввів користувач, у новий метод для обробки
                ProcessUserChoice(choice);

                Console.WriteLine(config.EnterToContinue);
                Console.ReadLine();
                Console.Clear();

            } while (choice != "0");
        }

        // метод займається виключно логікою — аналізує рядок і додає в кошик
        static void ProcessUserChoice(string choice)
        {
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
                            Console.WriteLine($"{config.Uvaga}'{selectedProduct.Name}'{config.NotAvailable}");
                            store.Manager.ReplaceProduct(); // Менеджер пропонує заміну (подія за умовою)
                        }
                    }
                    else
                    {
                        Console.WriteLine(config.WrongProductNum);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(config.InputError);
            }
        }

        static void ProcessOrderAndCheckout()
        {
            Console.Clear();
            client.Cart.CalculateTotalPrice();
            client.Cart.ShowCartInfo();

            if (client.Cart.IsEmpty())
            {
                Console.WriteLine(config.EmptyCartFinish);
                return;
            }

            // Перевіряємо роботу унарного оператора "true/false" з Версії 4
            if (client.Cart)
            {
                Console.WriteLine(config.PositiveBalance);
            }

            Console.WriteLine(config.CheckoutHeader);
            Console.Write(config.AskAddress);
            string deliveryAddress = Console.ReadLine();

            Console.WriteLine(config.DeliveryCostInfo);

            Cart deliveryCart = client.Cart;
            deliveryCart++; // збільшуємо вартість кошика на 100 грн!

            Console.WriteLine($"{config.FinalPriceInfo}{client.Cart.TotalPrice}{config.Grn}");

            Console.WriteLine(config.PaymentMethodHeader);
            Console.WriteLine(config.PaymentOption1);
            Console.WriteLine(config.PaymentOption2);
            Console.Write(config.EnterChoice);
            string paymentChoice = Console.ReadLine();

            string paymentType = (paymentChoice == "1") ? config.PaymentTypeCard : config.PaymentTypePost;
            Console.WriteLine($"{config.ChosenMethodInfo}{paymentType}");

            // Створюємо об'єкт оплати
            Payment payment = new Payment(client.Cart.TotalPrice, false);
            if (paymentChoice == "1")
            {
                payment.Pay(); // Одразу оплачуємо
            }
            else
            {
                Console.WriteLine(config.PostPaymentInfo);
            }

            // Створюємо та запускаємо доставку
            Delivery delivery = new Delivery(deliveryAddress, config.DeliveryStatus);
            delivery.Deliver();

            // Створюємо замовлення
            Order order = new Order(202601, payment, delivery);
            order.ConfirmOrder();

            // Реєструємо замовлення в магазині та передаємо менеджеру в контроль
            store.RegisterOrder(order);
            store.Manager.ControlOrders();

            // ЗБЕРЕЖЕННЯ ІСТОРІЇ КЛІЄНТА У ФАЙЛ
            SaveClientHistory(paymentType, payment, order, delivery);
        }

        static void SaveClientHistory(string paymentType, Payment payment, Order order, Delivery delivery)
        {
            string clientsFolder = "Clients";
            if (!Directory.Exists(clientsFolder))
            {
                Directory.CreateDirectory(clientsFolder);
            }

            string clientFileName = $"{client.FullName.Replace(" ", "_")}_history.txt";
            string clientFilePath = Path.Combine(clientsFolder, clientFileName);

            // Формуємо гарний чек, тепер повністю підтягуючи назви полів з json конфігу
            List<string> historyLines = new List<string>
            {
                config.Haxor1,
                $"{config.Haxor2}{client.FullName}",
                $"{config.Haxor3}{client.PhoneNumber}",
                $"{config.Haxor4}{DateTime.Now}",
                config.Haxor5,
                config.Haxor6
            };

            foreach (var prod in client.Cart.Products)
            {
                historyLines.Add($"- {prod.Name} | {prod.Price}{config.Grn} | {prod.Quantity}{config.Sht}");
            }

            historyLines.Add(config.Haxor5);
            historyLines.Add($"{config.Haxor7}{client.Cart.TotalPrice}{config.Grn}");
            historyLines.Add($"{config.Haxor8}{paymentType}");
            historyLines.Add($"{config.Haxor9}{(payment.IsPaid ? config.Haxor10 : config.PaymentTypePost)}");
            historyLines.Add($"{config.Haxor11}{order.TrackingNumber}");
            historyLines.Add($"{config.Haxor12}{delivery.Address}");
            historyLines.Add(config.Haxor13);
            historyLines.Add("");
            historyLines.Add("");

            File.AppendAllLines(clientFilePath, historyLines);

            Console.WriteLine();
            Console.WriteLine($"{config.SuccessHistorySave}{clientFilePath}");
            Console.WriteLine(config.SystemSuccess);
            Console.ReadLine();
        }
    }
}