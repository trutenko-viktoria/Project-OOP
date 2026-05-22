using System;

namespace Project
{
    // Додано : IShowInfo, щоб інтерфейс використовувався в проекті
    internal class Manager : User, IShowInfo
    {
        private int processedOrdersCount;

        public Manager() : base()
        {
            processedOrdersCount = 0;
        }
        // Console.WriteLine("Конструктор без параметрів Manager");


        public Manager(string fullName, int processedOrdersCount)
        : base(fullName, "Не вказано")
        {
            // ВИПРАВЛЕНО: Явно записуємо ім'я в protected поле базового класу
            // щоб метод ShowManagerInfo() бачив його в консолі
            this.fullName = fullName;
            this.processedOrdersCount = processedOrdersCount;

            // Console.WriteLine("Конструктор з параметрами Manager");
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

        //V5
        public override void ShowUserRole()
        {
            // МОДЕРНІЗОВАНО: тепер вивід інтегрований у бізнес-процес магазину
            Console.WriteLine($"[Авторизація] Працівник {fullName} увійшов у систему з роллю: МЕНЕДЖЕР.");
        }
        //

        // Реалізація методу інтерфейсу IShowInfo
        public void ShowInfo()
        {
            ShowManagerInfo();
        }

        public void ShowManagerInfo()
        {
            Console.WriteLine($"Менеджер: {fullName}");
            Console.WriteLine($"Кількість оброблених замовлень: {processedOrdersCount}");
        }

    }
}