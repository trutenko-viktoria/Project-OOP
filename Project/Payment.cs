using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Payment
    {
        private double amount;
        private bool isPaid;

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public bool IsPaid
        {
            get { return isPaid; }
            private set { isPaid = value; }
        }

        static Payment()
        {
            Console.WriteLine("Статичний конструктор Payment");
        }

        private Payment(bool isHidden)
        {
            Console.WriteLine("Закритий конструктор Payment");
        }

        public Payment()
        {
            amount = 0;
            isPaid = false;

            Console.WriteLine("Конструктор без параметрів Payment");
        }

        public Payment(double amount, bool isPaid)
        {
            this.amount = amount;
            this.isPaid = isPaid;

            Console.WriteLine("Конструктор з параметрами Payment");
        }

        public Payment(Payment other)
        {
            amount = other.amount;
            isPaid = other.isPaid;

            Console.WriteLine("Конструктор копіювання Payment");
        }

        public Payment(double amount) : this()
        {
            this.amount = amount;

            Console.WriteLine("Конструктор з викликом іншого конструктора Payment");
        }

        public void Pay()
        {
            isPaid = true;
            Console.WriteLine("Товар оплачено");
        }

        //3 версія - булеві 
        public bool IsPaymentCompleted()
        {
            return isPaid;
        }

        public bool IsLargePayment()
        {
            return amount > 20000;
        }
        //3 версія - сценарію
        public void CancelPayment()
        {
            if (isPaid)
            {
                isPaid = false;
                Console.WriteLine("Оплату скасовано");
            }
            else
            {
                Console.WriteLine("Оплата ще не була виконана");
            }
        }
        //

        public void ShowPaymentInfo()
        {
            Console.WriteLine($"Сума оплати: {amount}");
            Console.WriteLine($"Статус оплати: {(isPaid ? "оплачено" : "не оплачено")}");
        }
    }
}
