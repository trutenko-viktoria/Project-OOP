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
            Console.WriteLine("Старт імітації");

            //============================================
            Console.WriteLine("----- Перевірка класу Product -----");

            Product product1 = new Product();
            product1.ShowProductInfo();

            Console.WriteLine();

            Product product2 = new Product("Ноутбук", 25000, 5);
            product2.ShowProductInfo();

            Console.WriteLine($"Товар є в наявності: {product2.IsAvailable()}");
            Console.WriteLine($"Товар дорогий: {product2.IsExpensive()}");

            Console.WriteLine();

            Product product3 = new Product(product2);
            product3.ShowProductInfo();

            Console.WriteLine();

            Product product4 = new Product("Смартфон");
            product4.ShowProductInfo();

            //4 версія - оператори
            Console.WriteLine();

            Console.WriteLine("----- Перевантаження операторів Product -----");

            double totalPrice = product2 + product4;
            Console.WriteLine($"Сума цін товарів: {totalPrice}");

            Console.WriteLine($"Товари мають однакову ціну: {product2 == product4}");
            Console.WriteLine($"Товари мають різну ціну: {product2 != product4}");

            Console.WriteLine($"Product2 дорожчий за Product4: {product2 > product4}");
            Console.WriteLine($"Product2 дешевший за Product4: {product2 < product4}");

            Console.WriteLine();
            //

            //======================================

            Console.WriteLine("----- Перевірка класу Payment -----");

            Payment payment1 = new Payment();
            payment1.ShowPaymentInfo();

            Console.WriteLine();

            Payment payment2 = new Payment(25000, false);
            payment2.ShowPaymentInfo();
            payment2.Pay();
            payment2.ShowPaymentInfo();

            //3 версія - сценарію
            payment2.CancelPayment();
            payment2.ShowPaymentInfo();

            //3 версія
            Console.WriteLine($"Оплата виконана: {payment2.IsPaymentCompleted()}");
            Console.WriteLine($"Велика сума оплати: {payment2.IsLargePayment()}");
            // 

            Console.WriteLine();

            Payment payment3 = new Payment(payment2);
            payment3.ShowPaymentInfo();

            Console.WriteLine();

            Payment payment4 = new Payment(15000);
            payment4.ShowPaymentInfo();

            //4 версія - оператори
            Console.WriteLine();

            Console.WriteLine("----- Перевантаження операторів Payment -----");

            Console.WriteLine($"Оплата не виконана: {!payment2}");

            Console.WriteLine();
            //


            //=============================================

            Console.WriteLine("----- Перевірка класу Delivery -----");

            Delivery delivery1 = new Delivery();
            delivery1.ShowDeliveryInfo();

            Console.WriteLine();

            Delivery delivery2 = new Delivery("м. Київ, вул. Хрещатик, 1", "оформлена");
            delivery2.ShowDeliveryInfo();
            delivery2.Deliver();
            delivery2.ShowDeliveryInfo();

            //3 версія - сценарію
            delivery2.CompleteDelivery();
            delivery2.ShowDeliveryInfo();

            //3 версія - булеві
            Console.WriteLine($"Доставка активна: {delivery2.IsDelivered()}");
            Console.WriteLine($"Адресу вказано: {delivery2.HasAddress()}");
            //

            Console.WriteLine();

            Delivery delivery3 = new Delivery(delivery2);
            delivery3.ShowDeliveryInfo();

            Console.WriteLine();

            Delivery delivery4 = new Delivery("м. Київ, відділення пошти №5");
            delivery4.ShowDeliveryInfo();

            Console.WriteLine();

            //==================================================

            Console.WriteLine("----- Перевірка класу Manager -----");

            Manager manager1 = new Manager();
            manager1.ShowManagerInfo();

            Console.WriteLine();

            Manager manager2 = new Manager("Олена", 3);
            manager2.ShowManagerInfo();
            manager2.ControlOrders();
            manager2.ReplaceProduct();
            manager2.ShowManagerInfo();

            // 3 версія
            Console.WriteLine($"Менеджер має оброблені замовлення: {manager2.HasProcessedOrders()}");
            Console.WriteLine($"Менеджер досвідчений: {manager2.IsExperiencedManager()}");
            //

            Console.WriteLine();

            Manager manager3 = new Manager(manager2);
            manager3.ShowManagerInfo();

            Console.WriteLine();

            Manager manager4 = new Manager("Ірина");
            manager4.ShowManagerInfo();

            Console.WriteLine();

            //===========================================

            Console.WriteLine("----- Перевірка класу Cart -----");

            Cart cart1 = new Cart();
            cart1.ShowCartInfo();

            Console.WriteLine();

            cart1.AddProduct(new Product("Ноутбук", 25000, 1));
            cart1.AddProduct(new Product("Мишка", 500, 2));
            cart1.CalculateTotalPrice();
            cart1.ShowCartInfo();

            // 3 версія
            Console.WriteLine($"Корзина порожня: {cart1.IsEmpty()}");
            Console.WriteLine($"Корзина має велику суму: {cart1.HasExpensiveTotal()}");
            //

            Console.WriteLine();

            List<Product> productList = new List<Product>();
            productList.Add(new Product("Клавіатура", 1200, 1));

            Cart cart2 = new Cart(productList, 1200);
            cart2.ShowCartInfo();

            Console.WriteLine();

            Cart cart3 = new Cart(cart1);
            cart3.ShowCartInfo();

            Console.WriteLine();

            Cart cart4 = new Cart(productList);
            cart4.CalculateTotalPrice();
            cart4.ShowCartInfo();

            //3 версія
            cart1.CanCreateOrder();
            //

            //4 версія - оператори
            Console.WriteLine();

            Console.WriteLine("----- Перевантаження операторів Cart -----");

            cart1++;
            cart1.ShowCartInfo();

            Console.WriteLine();

            cart1--;
            cart1.ShowCartInfo();

            Console.WriteLine();

            if (cart1)
            {
                Console.WriteLine("Корзина не порожня");
            }
            else
            {
                Console.WriteLine("Корзина порожня");
            }

            Console.WriteLine();
            //

            //===========================================

            Console.WriteLine("----- Перевірка класу Client -----");

            Client client1 = new Client();
            client1.ShowClientInfo();
            client1.Register();

            Console.WriteLine();

            Cart clientCart = new Cart();
            clientCart.AddProduct(new Product("Навушники", 1500, 1));

            Client client2 = new Client("Трутенко Вікторія", "+380991112233", clientCart);
            client2.ShowClientInfo();
            client2.AddToCart(new Product("Чохол для телефону", 300, 1));
            client2.Cart.CalculateTotalPrice();
            client2.MakeOrder();

            //3 версія
            Console.WriteLine($"Клієнт має корзину: {client2.HasCart()}");
            Console.WriteLine($"Клієнт вказав номер телефону: {client2.HasPhoneNumber()}");
            //

            Console.WriteLine();

            Client client3 = new Client(client2);
            client3.ShowClientInfo();

            Console.WriteLine();

            Client client4 = new Client("Анна");
            client4.ShowClientInfo();

            Console.WriteLine();

            //===========================================

            Console.WriteLine("----- Перевірка класу Order -----");

            Order order1 = new Order();
            order1.ShowOrderInfo();

            Console.WriteLine();

            Payment paymentForOrder = new Payment(32000, true);
            Delivery deliveryForOrder = new Delivery("м. Київ, вул. Шевченка, 10", "оформлена");

            Order order2 = new Order(101, paymentForOrder, deliveryForOrder);
            order2.ShowOrderInfo();
            order2.RegisterOrder();
            order2.CompleteOrder();

            //3 версія - метод сценарію
            order2.ConfirmOrder();
            //3 версія - булеві методи
            Console.WriteLine($"Замовлення оплачене: {order2.IsPaidOrder()}");
            Console.WriteLine($"Замовлення має доставку: {order2.HasDelivery()}");
            //

            Console.WriteLine();

            Order order3 = new Order(order2);
            order3.ShowOrderInfo();

            Console.WriteLine();

            Order order4 = new Order(202);
            order4.ShowOrderInfo();

            Console.WriteLine();

            //4 версія - оператори
            Console.WriteLine();

            Console.WriteLine("----- Перевантаження операторів Order -----");

            Console.WriteLine($"Order2 >= Order4: {order2 >= order4}");
            Console.WriteLine($"Order2 <= Order4: {order2 <= order4}");

            Console.WriteLine();

            //=============================================

            Console.WriteLine("----- Перевірка класу OnlineStore -----");

            OnlineStore store1 = new OnlineStore();
            store1.OpenStore();
            store1.ShowStoreInfo();

            Console.WriteLine();

            //5 версія
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
            storeOrders.Add(order2);

            Manager storeManager = new Manager("Максим", 5);

            OnlineStore store2 = new OnlineStore(storeProducts, storeOrders, storeManager);

            store2.OpenStore();

            //5
            store2.ShowCatalog();

            //4
            Console.WriteLine("Введіть номер товару або номер з + для повної інформації:");
            string userChoice = Console.ReadLine();

            if (userChoice.Contains("+"))
            {
                string numberPart = userChoice.Replace("+", "");

                int productIndex = Convert.ToInt32(numberPart) - 1;

                store2.ShowProductDetails(productIndex);
            }
            else
            {
                int productIndex = Convert.ToInt32(userChoice) - 1;

                Product selectedProduct = store2.GetProductByIndex(productIndex);

                if (selectedProduct != null)
                {
                    client2.AddToCart(selectedProduct);

                    Console.WriteLine("Товар додано у корзину");
                }
            }
            //

            store2.ShowStoreInfo();

            //3 версія - методи сценарію
            storeManager.CheckStoreOrders(store2);
            //3 версія - булеві методи
            Console.WriteLine($"Магазин має товари: {store2.HasProducts()}");
            Console.WriteLine($"Магазин має замовлення: {store2.HasOrders()}");
            //

            Console.WriteLine();

            store2.AddProduct(new Product("Вебкамера", 2500, 1));
            store2.AddOrder(new Order(303));

            // 3 версія
            Console.WriteLine("----- Сценарій пошуку товару -----");

            Product foundProduct = store2.FindProductByName("Монітор");

            if (foundProduct != null)
            {
                Console.WriteLine("Товар знайдено:");
                foundProduct.ShowProductInfo();
            }
            else
            {
                Console.WriteLine("Товар не знайдено");
            }

            Console.WriteLine();

            Console.WriteLine("----- Сценарій реєстрації замовлення -----");

            Order newOrder = new Order(404);
            store2.RegisterOrder(newOrder);
            store2.ShowStoreInfo();
            //

            Console.WriteLine();

            OnlineStore store3 = new OnlineStore(store2);
            store3.ShowStoreInfo();

            Console.WriteLine();

            OnlineStore store4 = new OnlineStore(new Manager("Олена"));
            store4.ShowStoreInfo();

            Console.WriteLine();

           //========================================================

            Console.WriteLine("Фініш імітації");
        }
    }
}
