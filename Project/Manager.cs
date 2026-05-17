using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Manager
    {
        private string managerName;

        public void ControlOrders()
        {
            Console.WriteLine("Менеджер контролює замовлення");
        }

        public void ReplaceProduct()
        {
            Console.WriteLine("Менеджер узгоджує заміну товару");
        }
    }
}
