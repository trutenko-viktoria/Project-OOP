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

        public Payment(double amount, bool isPaid)
        {
            this.amount = amount;
            this.isPaid = isPaid;
        }

        public void Pay()
        {
            isPaid = true;
            Console.WriteLine(Program.config.PaymentDone);
        }

        public void ShowPaymentInfo()
        {
            // заміняємо весь текст на змінні з нашого json
            Console.WriteLine($"{Program.config.PaymentAmountLabel}{amount}");
            Console.WriteLine($"{Program.config.PaymentStatusLabel}{(isPaid ? Program.config.PaymentStatusPaid : Program.config.PaymentStatusNotPaid)}");
        }
    }
}