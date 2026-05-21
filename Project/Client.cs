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

        static Client()
        {
            //  Console.WriteLine("Статичний конструктор Client");
        }

        private Client(bool isHidden)
        {
            // Console.WriteLine("Закритий конструктор Client");
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

        public Client(Client other)
        {
            fullName = other.fullName;
            phoneNumber = other.phoneNumber;
            cart = new Cart(other.cart);

            // Console.WriteLine("Конструктор копіювання Client");
        }

        public Client(string fullName) : this()
        {
            this.fullName = fullName;

            // Console.WriteLine("Конструктор з викликом іншого конструктора Client");
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
        //3 версія - методи сценарію

        public void MakeOrder()
        {
            if (cart.CanCreateOrder())
            {
                Console.WriteLine($"Клієнт {fullName} оформив замовлення");
            }
            else
            {
                Console.WriteLine($"Клієнт {fullName} не може оформити замовлення");
            }
        }
        // зміни в мейн не додаю, бо він там вже є, наразі я просто його покращую

        //3 версія - булеві
        public bool HasCart()
        {
            return cart != null;
        }

        public bool HasPhoneNumber()
        {
            return phoneNumber != "Не вказано";
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