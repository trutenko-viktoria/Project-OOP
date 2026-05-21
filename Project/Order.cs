using System;

namespace Project
{
    internal class Order
    {
        private int orderNumber;
        private Payment payment;
        private Delivery delivery;
        private string trackingNumber;

        public string TrackingNumber
        {
            get { return trackingNumber; }
            set { trackingNumber = value; }
        }

        public int OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        public Payment Payment
        {
            get { return payment; }
            private set { payment = value; }
        }

        public Delivery Delivery
        {
            get { return delivery; }
            private set { delivery = value; }
        }

        static Order()
        {
          //  Console.WriteLine("Статичний конструктор Order");
        }

        private Order(bool isHidden)
        {
           // Console.WriteLine("Закритий конструктор Order");
        }

        public Order()
        {
            orderNumber = 0;
            payment = new Payment();
            delivery = new Delivery();

           // Console.WriteLine("Конструктор без параметрів Order");
        }

        public Order(int orderNumber, Payment payment, Delivery delivery)
        {
            this.orderNumber = orderNumber;
            this.payment = payment;
            this.delivery = delivery;
            trackingNumber = GenerateTrackingNumber();

            // Console.WriteLine("Конструктор з параметрами Order");
        }

        public Order(Order other)
        {
            orderNumber = other.orderNumber;
            payment = new Payment(other.payment);
            delivery = new Delivery(other.delivery);

           // Console.WriteLine("Конструктор копіювання Order");
        }

        public Order(int orderNumber) : this()
        {
            this.orderNumber = orderNumber;

           // Console.WriteLine("Конструктор з викликом іншого конструктора Order");
        }

        private string GenerateTrackingNumber()
        {
            Random random = new Random();

            return "TTN-" + random.Next(100000, 999999);
        }

        public void RegisterOrder()
        {
            Console.WriteLine($"Замовлення №{orderNumber} зареєстровано");
        }

        public void CompleteOrder()
        {
            Console.WriteLine($"Замовлення №{orderNumber} скомпоновано");
        }

        //3 версія - булеві
        public bool IsPaidOrder()
        {
            return payment.IsPaid;
        }

        public bool HasDelivery()
        {
            return delivery != null;
        }
        //3 версія - методи сценарію
        public void ConfirmOrder()
        {
            if (IsPaidOrder() && HasDelivery())
            {
                Console.WriteLine($"Замовлення №{orderNumber} підтверджено");
            }
            else
            {
                Console.WriteLine($"Замовлення №{orderNumber} не можна підтвердити");
            }
        }
        //

        //4 версія - оператори
        public static bool operator >=(Order firstOrder, Order secondOrder)
        {
            return firstOrder.orderNumber >= secondOrder.orderNumber;
        }

        public static bool operator <=(Order firstOrder, Order secondOrder)
        {
            return firstOrder.orderNumber <= secondOrder.orderNumber;
        }
        //

        public void ShowOrderInfo()
        {
            Console.WriteLine($"Номер замовлення: {orderNumber}");

            payment.ShowPaymentInfo();
            delivery.ShowDeliveryInfo();
            Console.WriteLine($"ТТН: {trackingNumber}");
        }
    }
}
