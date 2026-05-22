using System;

namespace Project
{
    internal class Client : User
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

        public Client()
        {
            fullName = "Невідомий клієнт";
            phoneNumber = "Не вказано";
            cart = new Cart();

            // Console.WriteLine("Конструктор без параметрів Client");
        }

        public Client(string fullName, string phoneNumber, Cart cart)
         : base(fullName, phoneNumber)
        {
            // ВИПРАВЛЕНО: тепер дані записуються і в локальні поля класу Client,
            // щоб уникнути помилки NullReferenceException в Program.cs
            this.fullName = fullName;
            this.phoneNumber = phoneNumber;
            this.cart = cart;

            // Console.WriteLine("Конструктор з параметрами Client");
        }

        public void Register()
        {
            //  Console.WriteLine($"Клієнт {fullName} зареєструвався");
        }

        //3 версія - покращення даного методу сцеенарію у зв'язку з покращенням класу Product
        public void AddToCart(Product product)
        {
            if (product.CanBeAddedToCart())
            {
                cart.AddProduct(product);
                Console.WriteLine($"Клієнт {fullName} додав товар у корзину");
            }
            else
            {
                Console.WriteLine($"Клієнт {fullName} не зміг додати товар");
            }
        }
        //
        
        public override void ShowUserRole()
        {
            Console.WriteLine($"[Система авторизації] Користувач увійшов у профіль як: КЛІЄНТ.");
        }

        //V5
        public void ShowInfo()
        {
            ShowClientInfo();
        }

        public void ShowClientInfo()
        {
            Console.WriteLine($"Клієнт: {fullName}");
            Console.WriteLine($"Телефон: {phoneNumber}");
            cart.ShowCartInfo();
        }

    }
}