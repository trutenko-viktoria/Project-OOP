using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Версія 1");
            Console.WriteLine("Старт імітації");

            //======================================
            Console.WriteLine("----- Перевірка класу Payment -----");

            Payment payment1 = new Payment();
            payment1.ShowPaymentInfo();

            Console.WriteLine();

            Payment payment2 = new Payment(25000, false);
            payment2.ShowPaymentInfo();
            payment2.Pay();
            payment2.ShowPaymentInfo();

            Console.WriteLine();

            Payment payment3 = new Payment(payment2);
            payment3.ShowPaymentInfo();

            Console.WriteLine();

            Payment payment4 = new Payment(15000);
            payment4.ShowPaymentInfo();

            Console.WriteLine();
            //=============================================

            Console.WriteLine("----- Перевірка класу Delivery -----");

            Delivery delivery1 = new Delivery();
            delivery1.ShowDeliveryInfo();

            Console.WriteLine();

            Delivery delivery2 = new Delivery("м. Київ, вул. Хрещатик, 1", "оформлена");
            delivery2.ShowDeliveryInfo();
            delivery2.Deliver();
            delivery2.ShowDeliveryInfo();

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

            Console.WriteLine();

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

            Console.WriteLine();

            Order order3 = new Order(order2);
            order3.ShowOrderInfo();

            Console.WriteLine();

            Order order4 = new Order(202);
            order4.ShowOrderInfo();

            Console.WriteLine();

            //=============================================

            Console.WriteLine("----- Перевірка класу OnlineStore -----");

            OnlineStore store1 = new OnlineStore();
            store1.OpenStore();
            store1.ShowStoreInfo();

            Console.WriteLine();

            List<Product> storeProducts = new List<Product>();
            storeProducts.Add(new Product("Монітор", 8000, 2));

            List<Order> storeOrders = new List<Order>();
            storeOrders.Add(order2);

            Manager storeManager = new Manager("Максим", 5);

            OnlineStore store2 = new OnlineStore(storeProducts, storeOrders, storeManager);

            store2.OpenStore();
            store2.ShowStoreInfo();

            Console.WriteLine();

            store2.AddProduct(new Product("Вебкамера", 2500, 1));
            store2.AddOrder(new Order(303));

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
