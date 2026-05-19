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
        private int processedOrdersCount;

        public string ManagerName
        {
            get { return managerName; }
            set { managerName = value; }
        }

        public int ProcessedOrdersCount
        {
            get { return processedOrdersCount; }
            private set { processedOrdersCount = value; }
        }

        static Manager()
        {
            Console.WriteLine("Статичний конструктор Manager");
        }

        private Manager(bool isHidden)
        {
            Console.WriteLine("Закритий конструктор Manager");
        }

        public Manager()
        {
            managerName = "Невідомий менеджер";
            processedOrdersCount = 0;

            Console.WriteLine("Конструктор без параметрів Manager");
        }

        public Manager(string managerName, int processedOrdersCount)
        {
            this.managerName = managerName;
            this.processedOrdersCount = processedOrdersCount;

            Console.WriteLine("Конструктор з параметрами Manager");
        }

        public Manager(Manager other)
        {
            managerName = other.managerName;
            processedOrdersCount = other.processedOrdersCount;

            Console.WriteLine("Конструктор копіювання Manager");
        }

        public Manager(string managerName) : this()
        {
            this.managerName = managerName;

            Console.WriteLine("Конструктор з викликом іншого конструктора Manager");
        }

        public void ControlOrders()
        {
            processedOrdersCount++;
            Console.WriteLine("Менеджер контролює замовлення");
        }

        public void ReplaceProduct()
        {
            Console.WriteLine("Менеджер узгоджує заміну товару з клієнтом");
        }

        //3 версія
        public bool HasProcessedOrders()
        {
            return processedOrdersCount > 0;
        }

        public bool IsExperiencedManager()
        {
            return processedOrdersCount >= 5;
        }
        //

        public void ShowManagerInfo()
        {
            Console.WriteLine($"Менеджер: {managerName}");
            Console.WriteLine($"Кількість оброблених замовлень: {processedOrdersCount}");
        }

    }
}
