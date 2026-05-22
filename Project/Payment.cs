using System;

namespace Project
{
    internal class Payment
    {
        private double amount;
        private bool isPaid;

        public bool IsPaid
        {
            get { return isPaid; }
            private set { isPaid = value; }
        }

        public Payment()
        {
            amount = 0;
            isPaid = false;

           // Console.WriteLine("Конструктор без параметрів Payment");
        }

        public Payment(double amount, bool isPaid)
        {
            this.amount = amount;
            this.isPaid = isPaid;

           // Console.WriteLine("Конструктор з параметрами Payment");
        }

        public Payment(Payment other)
        {
            amount = other.amount;
            isPaid = other.isPaid;

           // Console.WriteLine("Конструктор копіювання Payment");
        }

        public void Pay()
        {
            isPaid = true;
            Console.WriteLine("Товар оплачено");
        }

        public void ShowPaymentInfo()
        {
            Console.WriteLine($"Сума оплати: {amount}");
            Console.WriteLine($"Статус оплати: {(isPaid ? "оплачено" : "не оплачено")}");
        }
    }
}
