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

        public Manager(string fullName, int processedOrdersCount)
        : base(fullName, "Не вказано")
        {
            // Явно записуємо ім'я в protected поле базового класу
            // щоб метод ShowManagerInfo() бачив його в консолі
            this.fullName = fullName;
            this.processedOrdersCount = processedOrdersCount;
        }

        public void ControlOrders()
        {
            processedOrdersCount++;
            Console.WriteLine(Program.config.ManagerControl);
        }

        public void ReplaceProduct()
        {
            Console.WriteLine(Program.config.ManagerReplace);
        }

        // V5
        public override void ShowUserRole()
        {
            // МОДЕРНІЗОВАНО: збираємо рядок докупи з частинок у json
            Console.WriteLine($"{Program.config.ManagerAuthPrefix}{fullName}{Program.config.ManagerAuthSuffix}");
        }

        // Реалізація методу інтерфейсу IShowInfo
        public void ShowInfo()
        {
            ShowManagerInfo();
        }

        public void ShowManagerInfo()
        {
            Console.WriteLine($"{Program.config.ManagerLabel}{fullName}");
            Console.WriteLine($"{Program.config.ManagerOrdersCount}{processedOrdersCount}");
        }
    }
}