using System;

namespace Project
{
    internal class Product : IShowInfo
    {
        private string name;
        private double price;
        private int quantity;

        private string description;
        private string size;
        private string color;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public Product(string name, double price, int quantity, string description, string size, string color)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;

            this.description = description;
            this.size = size;
            this.color = color;
        }

        public Product(Product other)
        {
            name = other.name;
            price = other.price;
            quantity = other.quantity;

            description = other.description;
            size = other.size;
            color = other.color;
        }

        // 3 версія - булеві функції
        public bool IsAvailable()
        {
            return quantity > 0;
        }

        // 3 версія - методи сценарію
        public bool CanBeAddedToCart()
        {
            if (IsAvailable())
            {
                Console.WriteLine(Program.config.ProductInStock);
                return true;
            }

            Console.WriteLine(Program.config.ProductOutOfStock);
            return false;
        }

        // 4 версія - перевантаження операторів
        public static bool operator ==(Product firstProduct, Product secondProduct)
        {
            if (ReferenceEquals(firstProduct, secondProduct))
            {
                return true;
            }

            if (firstProduct is null || secondProduct is null)
            {
                return false;
            }

            return firstProduct.price == secondProduct.price;
        }

        public static bool operator !=(Product firstProduct, Product secondProduct)
        {
            return !(firstProduct == secondProduct);
        }

        public void ShowShortInfo() // коротка інфа для швидкого огляду асортименту
        {
            Console.WriteLine($"{name}{Program.config.Separator}{price}{Program.config.Grn}");
        }

        public void DecreaseQuantity() // зменшення кількості "в наявності"
        {
            if (quantity > 0)
            {
                quantity--;
                Console.WriteLine(Program.config.ProductDecreased);
            }
            else
            {
                Console.WriteLine(Program.config.ProductWarehouseEmpty);
            }
        }

        // v5
        public void ShowInfo()
        {
            ShowProductInfo();
        }

        public void ShowProductInfo()
        {
            // заміняємо всі текстові назви полів на змінні з json
            Console.WriteLine($"{Program.config.LabelName}{name}");
            Console.WriteLine($"{Program.config.LabelDesc}{description}");
            Console.WriteLine($"{Program.config.LabelSize}{size}");
            Console.WriteLine($"{Program.config.LabelColor}{color}");
            Console.WriteLine($"{Program.config.LabelPrice}{price}{Program.config.Grn}");
            Console.WriteLine($"{Program.config.LabelQuantity}{quantity}");
        }
    }
}