namespace MapStrap.UnitTests.Models
{
    internal class Employee
    {
        private readonly int id;

        public Employee(int id)
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