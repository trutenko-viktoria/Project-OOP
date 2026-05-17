using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Order
    {
        private int orderNumber;
        private Payment payment;
        private Delivery delivery;

        public void RegisterOrder()
        {
            Console.WriteLine("Замовлення зареєстроване");
        }

        public void CompleteOrder()
        {
            Console.WriteLine("Замовлення скомпоноване");
        }
    }
}
