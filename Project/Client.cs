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

        public Client(string fullName, string phoneNumber, Cart cart)
         : base(fullName, phoneNumber)
        {
            // дані пишуться в локальні поля, щоб не було NullReferenceException
            this.fullName = fullName;
            this.phoneNumber = phoneNumber;
            this.cart = cart;
        }

        public void Register()
        {
        }

        // 3 версія - покращення даного методу сцеенарію у зв'язку з покращенням класу Product
        public void AddToCart(Product product)
        {
            if (product.CanBeAddedToCart())
            {
                cart.AddProduct(product);
                // витягуємо фразу успішного додавання з конфігу
                Console.WriteLine($"{Program.config.Grn} '{fullName}' {Program.config.ClientAdded}");
            }
            else
            {
                // витягуємо фразу помилки додавання з конфігу
                Console.WriteLine($"{Program.config.Grn} '{fullName}' {Program.config.ClientFailedAdd}");
            }
        }

        public override void ShowUserRole()
        {
            // роль беремо з json
            Console.WriteLine(Program.config.ClientRole);
        }

        // V5
        public void ShowInfo()
        {
            ShowClientInfo();
        }

        public void ShowClientInfo()
        {
            // повна заміна тексту на змінні з json
            Console.WriteLine($"{Program.config.ClientLabel}{fullName}");
            Console.WriteLine($"{Program.config.PhoneLabel}{phoneNumber}");
            cart.ShowCartInfo();
        }
    }
}