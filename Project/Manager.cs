using System;

namespace Project
{
    internal class Manager : User
    {
        private int processedOrdersCount;

        public int ProcessedOrdersCount
        {
            get { return processedOrdersCount; }
            private set { processedOrdersCount = value; }
        }

        static Manager()
        {
         //   Console.WriteLine("Статичний конструктор Manager");
        }

        private Manager(bool isHidden)
        {
           // Console.WriteLine("Закритий конструктор Manager");
        }

        public Manager() : base()
        {
            processedOrdersCount = 0;
        }
        // Console.WriteLine("Конструктор без параметрів Manager");


        public Manager(string fullName, int processedOrdersCount)
        : base(fullName, "Не вказано")
        {
            this.processedOrdersCount = processedOrdersCount;

           // Console.WriteLine("Конструктор з параметрами Manager");
        }

        public Manager(Manager other)
        {
            managerName = other.managerName;
            processedOrdersCount = other.processedOrdersCount;

           // Console.WriteLine("Конструктор копіювання Manager");
        }

        public Manager(string managerName) : this()
        {
            this.managerName = managerName;

           // Console.WriteLine("Конструктор з викликом іншого конструктора Manager");
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

        //3 версія - булеві
        public bool HasProcessedOrders()
        {
            return processedOrdersCount > 0;
        }

        public bool IsExperiencedManager()
        {
            return processedOrdersCount >= 5;
        }

        //3 версія - методи сценарію
        public void CheckStoreOrders(OnlineStore store)
        {
            if (store.HasOrders())
            {
                Console.WriteLine("Менеджер перевірив замовлення магазину");
            }
            else
            {
                Console.WriteLine("У магазині немає замовлень");
            }
        }
        //

        //V5
        public override void ShowUserRole()
        {
            Console.WriteLine("Роль: Менеджер");
        }
        //

        public void ShowManagerInfo()
        {
            Console.WriteLine($"Менеджер: {fullName}");
            Console.WriteLine($"Кількість оброблених замовлень: {processedOrdersCount}");
        }

    }
}
