namespace Project
{
    internal abstract class User
    {
        protected string fullName;
        protected string phoneNumber;

        public User()
        {
            fullName = "Невідомий користувач";
            phoneNumber = "Не вказано";
        }

        public User(string fullName, string phoneNumber)
        {
            this.fullName = fullName;
            this.phoneNumber = phoneNumber;
        }

        public abstract void ShowUserRole();
    }
}