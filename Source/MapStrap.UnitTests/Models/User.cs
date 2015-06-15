namespace MapStrap.UnitTests.Models
{
    internal class User
    {
        private readonly int id;

        public User(int id)
        {
            this.id = id;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }
    }
}