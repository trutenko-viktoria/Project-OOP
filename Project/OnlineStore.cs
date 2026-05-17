using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class OnlineStore
    {
        private List<Product> products;
        private List<Order> orders;
        private Manager manager;

        public void OpenStore()
        {
            Console.WriteLine("Магазин працює");
        }

        public void CloseOrders()
        {
            Console.WriteLine("Вікно замовлень закрите");
        }
    }
}
