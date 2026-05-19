using System;

namespace Project
{
    internal class Client
    {
        private string fullName;
        private string phoneNumber;
        private Cart cart;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public Cart Cart
        {
            get { return cart; }
            private set { cart = value; }
        }

        static Client()
        {
            Console.WriteLine("Статичний конструктор Client");
        }

        private Client(bool isHidden)
        {
            Console.WriteLine("Закритий конструктор Client");
        }

        public Client()
        {
            fullName = "Невідомий клієнт";
            phoneNumber = "Не вказано";
            cart = new Cart();

            Console.WriteLine("Конструктор без параметрів Client");
        }

        public Client(string fullName, string phoneNumber, Cart cart)
        {
            this.fullName = fullName;
            this.phoneNumber = phoneNumber;
            this.cart = cart;

            Console.WriteLine("Конструктор з параметрами Client");
        }

        public Client(Client other)
        {
            fullName = other.fullName;
            phoneNumber = other.phoneNumber;
            cart = new Cart(other.cart);

            Console.WriteLine("Конструктор копіювання Client");
        }

        public Client(string fullName) : this()
        {
            this.fullName = fullName;

            Console.WriteLine("Конструктор з викликом іншого конструктора Client");
        }

        public void Register()
        {
            Console.WriteLine($"Клієнт {fullName} зареєструвався");
        }

        public void AddToCart(Product product)
        {
            cart.AddProduct(product);
            Console.WriteLine($"Клієнт {fullName} додав товар у корзину");
        }

        public void MakeOrder()
        {
            Console.WriteLine($"Клієнт {fullName} оформив замовлення");
        }

        public void ShowClientInfo()
        {
            Console.WriteLine($"Клієнт: {fullName}");
            Console.WriteLine($"Телефон: {phoneNumber}");
            cart.ShowCartInfo();
        }

    }
}
