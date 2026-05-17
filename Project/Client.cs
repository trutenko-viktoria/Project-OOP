using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Client
    {
        private string fullName;
        private string phoneNumber;
        private Cart cart;

        public void Register()
        {
            Console.WriteLine("Клієнт зареєструвався");
        }

        public void AddToCart()
        {
            Console.WriteLine("Товар додано у корзину");
        }

        public void MakeOrder()
        {
            Console.WriteLine("Замовлення оформлено");
        }
    }
}
